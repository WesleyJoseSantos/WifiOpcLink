using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WifiOpcLink
{
    public class OpcWifiDongle : Component
    {
        private SerialPort serialPort;

        public bool Connected { get => serialPort.IsOpen; }

        public string Port { get => serialPort.PortName; set => serialPort.PortName = value; }

        [JsonIgnore]
        public string Log { get; set; }

        public event EventHandler LogUpdated;

        public OpcWifiDongle()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
            serialPort.ReadTimeout = 800;
            serialPort.WriteTimeout = 800;
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Log = serialPort.ReadExisting();
            }
            catch (Exception)
            {
            }
            LogUpdated?.Invoke(sender, e);
        }

        public void Connect()
        {
            try
            {
                if (!serialPort.IsOpen) serialPort.PortName = Port;
                serialPort.Open();
                serialPort.WriteLine("WifiOpcDongle?");
                var r = serialPort.ReadLine();
                if (r == "Yes" || r == "Yes\r")
                {
                    MessageBox.Show("Device connected!", "Info");
                    return;
                }
                else
                {
                    serialPort.Close();
                    MessageBox.Show("Connection failed!", "Info");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SearchDevice()
        {
            var ports = SerialPort.GetPortNames();

            foreach (var port in ports)
            {
                if (serialPort.IsOpen) serialPort.Close();
                serialPort.PortName = port;
                try
                {
                    serialPort.Open();
                    serialPort.WriteLine("WifiOpcDongle?");
                    var r = serialPort.ReadLine();
                    if (r == "Yes\r")
                    {
                        MessageBox.Show("Device connected!", "Info");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            serialPort.Close();
            MessageBox.Show("Device not founded.", "Error");
        }

        public void SendData(string data)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine(data);
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
