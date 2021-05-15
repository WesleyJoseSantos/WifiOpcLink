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
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Log = serialPort.ReadExisting();
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
                if (r == "Yes")
                {
                    MessageBox.Show("Device connected");
                    return;
                }
                else
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                serialPort.Close();
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
                Console.WriteLine(data);
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
