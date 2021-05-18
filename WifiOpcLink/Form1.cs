using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WifiOpcLink
{
    public partial class Form1 : Form
    {
        public WifiOpcLinkApp App { get; }

        public Form1()
        {
            InitializeComponent();
            App = new WifiOpcLinkApp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = App.Project.Server;
            App.Project.Server.LogUpdated += Server_LogUpdated;
            App.Project.Server.Dongle.LogUpdated += Dongle_LogUpdated;
        }

        private void Server_LogUpdated(object sender, EventArgs e)
        {
            consoleServer.AppendText(App.Project.Server.Log);
        }

        private void Dongle_LogUpdated(object sender, EventArgs e)
        {
            consoleDongle.Invoke((MethodInvoker)delegate
            {
                consoleDongle.AppendText(App.Project.Server.Dongle.Log);
            });
        }


        private void propertyGrid1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void menuProjectNew_Click(object sender, EventArgs e)
        {
            App.Project.New();
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void menuProjectOpen_Click(object sender, EventArgs e)
        {
            var project = App.Project.Open();
            if (project != null) App.Project = project;
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void menuProjectSave_Click(object sender, EventArgs e)
        {
            App.Project.Save();
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void menuProjectExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuServerConnect_Click(object sender, EventArgs e)
        {
            App.SaveDefaultFile();
            App.Project.Server.Connect();
            var state = App.Project.Server.ServerState;
            timer1.Enabled = state == ServerState.Connected;
            statusOPC.Text = state.ToString();
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void menuServerDisconnect_Click(object sender, EventArgs e)
        {
            App.SaveDefaultFile();
            App.Project.Server.Disconnect();
            var state = App.Project.Server.ServerState;
            timer1.Enabled = state == ServerState.Connected;
            statusOPC.Text = state.ToString();
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusDongle.Text = "Searching...";
            App.Project.Server.Dongle.SearchDevice();

            statusDongle.Text = App.Project.Server.Dongle.Connected 
                ? "Connected" : "Disconnected";
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Project.Server.Dongle.Connect();
            statusDongle.Text = App.Project.Server.Dongle.Connected
                ? "Connected" : "Disconnected";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var r = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            e.Cancel = r == DialogResult.No;

            App.SaveDefaultFile();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = App.Project.Server;
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = App.Project.Server.Dongle;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Project.Server.Dongle.Disconnect();
        }

        private void menuProjectSaveAs_Click(object sender, EventArgs e)
        {
            App.Project.SaveAs();
        }

        private void sendSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            consoleServer.Text = "";
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consoleDongle.Text = "";
        }
    }
}
