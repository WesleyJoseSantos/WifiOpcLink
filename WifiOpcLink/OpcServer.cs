using Newtonsoft.Json;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WifiOpcLink
{
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

        [Category("OPC Status")]
        [Description("Status of Server Connection.")]
        public string ServerState
        {
            get => server?.ServerState == 1 ? "Connected" : "Disconnected";
        }

        [Category("OPC Objects")]
        [Description("Items to be linked to wifi opc dongle.")]
        public OpcItem[] OpcItems { get; set; }

        [Category("OPC Objects")]
        [Description("Dongle linked to this OPC Server.")]
        public OpcWifiDongle Dongle { get; set; }


        private OPCServer server;
        OPCGroup group;

        public OpcServer()
        {
            InitializeComponent();
            Dongle = new OpcWifiDongle();

        }

        public OpcServer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Dongle = new OpcWifiDongle();

        }

        public void Connect()
        {
            server = new OPCAutomation.OPCServer();
            try
            {
                server.Connect(ServerName, NodeName);
            }
            catch (Exception)
            {
                MessageBox.Show($"Connection to server {ServerName} failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (OpcItems != null)
            {
                group = server.OPCGroups.Add("NewGroup");
                group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(Group_DataChange);
                group.UpdateRate = UpdateRate;
                group.IsSubscribed = group.IsActive;

                int idx = 1;
                foreach (var item in OpcItems)
                {
                    group.OPCItems.DefaultIsActive = true;
                    group.OPCItems.AddItem(item.Id, idx);
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
            var changedTags = new List<Tag>();
            for (int i = 1; i <= NumItems; i++)
            {
                var itId = Convert.ToInt32(ClientHandles.GetValue(i));
                if (OpcItems != null)
                {
                    var value = ItemValues.GetValue(i);
                    OpcItems[itId - 1].Value = value;
                    changedTags.Add(new Tag() {
                        Name = OpcItems[itId - 1].Tag,
                        Value = OpcItems[itId - 1].Value
                    });;
                }
            }
            Dongle.SendData(JsonConvert.SerializeObject(changedTags));
        }

    }
}
