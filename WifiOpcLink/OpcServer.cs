using Newtonsoft.Json;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WifiOpcLink
{
    public enum ServerState
    {
        Disconnected,
        Connected,
        ConnectedWithErrors
    }

    public enum DataFlowMode
    {
        DongleControlled,
        SendAllData,
        SendChangedData
    }

    public partial class OpcServer : Component
    {
        [Category("OPC Settings")]
        [Description("Name of opc server to be linked to the IoT devices.")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string ServerName { get; set; }

        [Category("OPC Settings")]
        [Description("Node name of OPC Server.")]
        public string NodeName { get; set; }

        [Category("OPC Settings")]
        [Description("Update rate of exchanged data.")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int UpdateRate { get; set; } = 1000;

        [Category("OPC Settings")]
        [Description("Define data flow mode of opc link.")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public DataFlowMode DataFlowMode { get; set; }

        [Category("OPC Status")]
        [Description("Status of Server Connection.")]
        public ServerState ServerState
        {
            get => server?.ServerState == 1 ? ServerState.Connected : ServerState.Disconnected;
        }

        [Category("OPC Objects")]
        [Description("Items to be linked to wifi opc dongle.")]
        public OpcItem[] OpcItems { get; set; }

        [Category("OPC Objects")]
        [Description("Dongle linked to this OPC Server.")]
        public OpcWifiDongle Dongle { get; set; }

        [Category("OPC Status")]
        [JsonIgnore]
        public bool Error { get; set; }

        [Category("OPC Status")]
        [JsonIgnore]
        public string Log { get; set; }

        public event EventHandler LogUpdated;

        private OPCServer server;
        private bool allDataRequested;
        private OPCGroup group;
        private List<WifiOpcLink.OpcItem> changedItems;

        public OpcServer()
        {
            InitializeComponent();
            Dongle = new OpcWifiDongle();
            Dongle.LogUpdated += Dongle_LogUpdated;
            changedItems = new List<WifiOpcLink.OpcItem>();
        }

        public OpcServer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Dongle = new OpcWifiDongle();
            Dongle.LogUpdated += Dongle_LogUpdated;
            changedItems = new List<WifiOpcLink.OpcItem>();
        }

        public void Connect()
        {
            try
            {
                server = new OPCAutomation.OPCServer();
            }
            catch (Exception)
            {
                Log = "Error on client instance creation." +
                    "Try x86 version of application.";
                LogUpdated?.Invoke(this, null);
                return;
            }

            try
            {
                server.Connect(ServerName, NodeName);
            }
            catch (Exception)
            {
                Log = $"Connection to server {ServerName} failed";
                LogUpdated?.Invoke(this, null);
                MessageBox.Show($"Connection to server {ServerName} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OpcItems != null)
            {
                group = server.OPCGroups.Add("NewGroup");
                group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(Group_DataChange);
                group.UpdateRate = UpdateRate;
                group.IsSubscribed = group.IsActive;
                group.OPCItems.DefaultIsActive = true;

                Error = false;

                int idx = 1;
                foreach (var item in OpcItems)
                {
                    try
                    {
                        group.OPCItems.AddItem(item.Id, idx);
                        item.Status = OpcItemStatus.Good;
                    }
                    catch (Exception ex)
                    {
                        Error = true;
                        item.Status = OpcItemStatus.Bad;
                        Log = $"Error trying to add {item.Id} to opc link.";
                        LogUpdated?.Invoke(this, null);
                        Log = ex.Message;
                        LogUpdated?.Invoke(this, null);
                    }
                    idx++;
                }
            }
        }

        public void Disconnect()
        {
            server.Disconnect();
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            changedItems.Clear();
            for (int i = 1; i <= NumItems; i++)
            {
                var itId = Convert.ToInt32(ClientHandles.GetValue(i));
                if (OpcItems != null)
                {
                    var value = ItemValues.GetValue(i);
                    OpcItems[itId - 1].Value = value;
                    changedItems.Add(OpcItems[itId - 1]);
                }
            }

            SendData();
        }

        private void Dongle_LogUpdated(object sender, EventArgs e)
        {
            allDataRequested = true;
        }

        private void SendData()
        {
            switch (DataFlowMode)
            {
                case DataFlowMode.DongleControlled:
                    if (allDataRequested)
                    {
                        allDataRequested = false;
                        SendAllData();
                    }
                    else
                    {
                        SendChangedData();
                    }
                    break;
                case DataFlowMode.SendAllData:
                    SendAllData();
                    break;
                case DataFlowMode.SendChangedData:
                    SendChangedData();
                    break;
                default:
                    break;
            }
        }

        private void SendChangedData()
        {
            for (int i = 0; i < changedItems.Count; i++)
            {
                OpcItem item = changedItems[i];
                var tag = ConvertToTag(ref item);
                var data = JsonConvert.SerializeObject(tag);
                Dongle.SendData(data);
            }
        }

        private void SendAllData()
        {
            for (int i = 0; i < OpcItems.Length; i++)
            {
                OpcItem item = OpcItems[i];
                var tag = ConvertToTag(ref item);
                var data = JsonConvert.SerializeObject(tag);
                Dongle.SendData(data);
            }
        }

        private Tag ConvertToTag(ref WifiOpcLink.OpcItem item)
        {
            var tag = new Tag();
            tag.Name = item.Tag;
            if (item.GetBit > -1)
            {
                tag.Value = ((int)item.Value & (1 << item.GetBit)) != 0;
                item.Value = tag.Value;
            }
            tag.Value = item.Reverse ? !(bool)item.Value : item.Value;
            return tag;
        }
    }
}
