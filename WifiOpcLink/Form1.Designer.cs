
namespace WifiOpcLink
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectExit = new System.Windows.Forms.ToolStripMenuItem();
            this.servidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServerConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServerDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcDongleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusOPC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDongle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.consoleServer = new System.Windows.Forms.TextBox();
            this.tabPageDongle = new System.Windows.Forms.TabPage();
            this.consoleDongle = new System.Windows.Forms.TextBox();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageServer.SuspendLayout();
            this.tabPageDongle.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 24);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(381, 335);
            this.propertyGrid.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.servidorToolStripMenuItem,
            this.opcDongleToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(381, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProjectNew,
            this.menuProjectOpen,
            this.menuProjectSave,
            this.menuProjectSaveAs,
            this.menuProjectExit});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.arquivoToolStripMenuItem.Text = "Project";
            // 
            // menuProjectNew
            // 
            this.menuProjectNew.Name = "menuProjectNew";
            this.menuProjectNew.Size = new System.Drawing.Size(114, 22);
            this.menuProjectNew.Text = "New";
            this.menuProjectNew.Click += new System.EventHandler(this.menuProjectNew_Click);
            // 
            // menuProjectOpen
            // 
            this.menuProjectOpen.Name = "menuProjectOpen";
            this.menuProjectOpen.Size = new System.Drawing.Size(114, 22);
            this.menuProjectOpen.Text = "Open";
            this.menuProjectOpen.Click += new System.EventHandler(this.menuProjectOpen_Click);
            // 
            // menuProjectSave
            // 
            this.menuProjectSave.Name = "menuProjectSave";
            this.menuProjectSave.Size = new System.Drawing.Size(114, 22);
            this.menuProjectSave.Text = "Save";
            this.menuProjectSave.Click += new System.EventHandler(this.menuProjectSave_Click);
            // 
            // menuProjectSaveAs
            // 
            this.menuProjectSaveAs.Name = "menuProjectSaveAs";
            this.menuProjectSaveAs.Size = new System.Drawing.Size(114, 22);
            this.menuProjectSaveAs.Text = "Save As";
            this.menuProjectSaveAs.Click += new System.EventHandler(this.menuProjectSaveAs_Click);
            // 
            // menuProjectExit
            // 
            this.menuProjectExit.Name = "menuProjectExit";
            this.menuProjectExit.Size = new System.Drawing.Size(114, 22);
            this.menuProjectExit.Text = "Exit";
            this.menuProjectExit.Click += new System.EventHandler(this.menuProjectExit_Click);
            // 
            // servidorToolStripMenuItem
            // 
            this.servidorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuServerConnect,
            this.menuServerDisconnect,
            this.settingsToolStripMenuItem,
            this.clearLogToolStripMenuItem1});
            this.servidorToolStripMenuItem.Name = "servidorToolStripMenuItem";
            this.servidorToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.servidorToolStripMenuItem.Text = "Server";
            // 
            // menuServerConnect
            // 
            this.menuServerConnect.Name = "menuServerConnect";
            this.menuServerConnect.Size = new System.Drawing.Size(133, 22);
            this.menuServerConnect.Text = "Connect";
            this.menuServerConnect.Click += new System.EventHandler(this.menuServerConnect_Click);
            // 
            // menuServerDisconnect
            // 
            this.menuServerDisconnect.Name = "menuServerDisconnect";
            this.menuServerDisconnect.Size = new System.Drawing.Size(133, 22);
            this.menuServerDisconnect.Text = "Disconnect";
            this.menuServerDisconnect.Click += new System.EventHandler(this.menuServerDisconnect_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // opcDongleToolStripMenuItem
            // 
            this.opcDongleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.sendSettingsToolStripMenuItem,
            this.settingsToolStripMenuItem1,
            this.clearLogToolStripMenuItem});
            this.opcDongleToolStripMenuItem.Name = "opcDongleToolStripMenuItem";
            this.opcDongleToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.opcDongleToolStripMenuItem.Text = "Dongle";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // sendSettingsToolStripMenuItem
            // 
            this.sendSettingsToolStripMenuItem.Name = "sendSettingsToolStripMenuItem";
            this.sendSettingsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sendSettingsToolStripMenuItem.Text = "Send Settings";
            this.sendSettingsToolStripMenuItem.Click += new System.EventHandler(this.sendSettingsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusOPC,
            this.toolStripStatusLabel2,
            this.statusDongle});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(381, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(34, 17);
            this.toolStripStatusLabel1.Text = "OPC:";
            // 
            // statusOPC
            // 
            this.statusOPC.Name = "statusOPC";
            this.statusOPC.Size = new System.Drawing.Size(79, 17);
            this.statusOPC.Text = "Disconnected";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel2.Text = "Dongle:";
            // 
            // statusDongle
            // 
            this.statusDongle.Name = "statusDongle";
            this.statusDongle.Size = new System.Drawing.Size(79, 17);
            this.statusDongle.Text = "Disconnected";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageServer);
            this.tabControl1.Controls.Add(this.tabPageDongle);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 359);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 100);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageServer
            // 
            this.tabPageServer.Controls.Add(this.consoleServer);
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(373, 74);
            this.tabPageServer.TabIndex = 0;
            this.tabPageServer.Text = "Servidor";
            this.tabPageServer.UseVisualStyleBackColor = true;
            // 
            // consoleServer
            // 
            this.consoleServer.BackColor = System.Drawing.Color.White;
            this.consoleServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleServer.Location = new System.Drawing.Point(3, 3);
            this.consoleServer.Multiline = true;
            this.consoleServer.Name = "consoleServer";
            this.consoleServer.ReadOnly = true;
            this.consoleServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleServer.Size = new System.Drawing.Size(367, 68);
            this.consoleServer.TabIndex = 4;
            // 
            // tabPageDongle
            // 
            this.tabPageDongle.Controls.Add(this.consoleDongle);
            this.tabPageDongle.Location = new System.Drawing.Point(4, 22);
            this.tabPageDongle.Name = "tabPageDongle";
            this.tabPageDongle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDongle.Size = new System.Drawing.Size(373, 77);
            this.tabPageDongle.TabIndex = 1;
            this.tabPageDongle.Text = "Dongle";
            this.tabPageDongle.UseVisualStyleBackColor = true;
            // 
            // consoleDongle
            // 
            this.consoleDongle.BackColor = System.Drawing.Color.White;
            this.consoleDongle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleDongle.Location = new System.Drawing.Point(3, 3);
            this.consoleDongle.Multiline = true;
            this.consoleDongle.Name = "consoleDongle";
            this.consoleDongle.ReadOnly = true;
            this.consoleDongle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleDongle.Size = new System.Drawing.Size(367, 71);
            this.consoleDongle.TabIndex = 5;
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem1
            // 
            this.clearLogToolStripMenuItem1.Name = "clearLogToolStripMenuItem1";
            this.clearLogToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.clearLogToolStripMenuItem1.Text = "Clear Log";
            this.clearLogToolStripMenuItem1.Click += new System.EventHandler(this.clearLogToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 481);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WiFi OPC Link";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageServer.ResumeLayout(false);
            this.tabPageServer.PerformLayout();
            this.tabPageDongle.ResumeLayout(false);
            this.tabPageDongle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuProjectNew;
        private System.Windows.Forms.ToolStripMenuItem menuProjectOpen;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSave;
        private System.Windows.Forms.ToolStripMenuItem menuProjectExit;
        private System.Windows.Forms.ToolStripMenuItem servidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuServerConnect;
        private System.Windows.Forms.ToolStripMenuItem menuServerDisconnect;
        private System.Windows.Forms.ToolStripMenuItem opcDongleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusOPC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusDongle;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuProjectSaveAs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageServer;
        private System.Windows.Forms.TextBox consoleServer;
        private System.Windows.Forms.TabPage tabPageDongle;
        private System.Windows.Forms.TextBox consoleDongle;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
    }
}

