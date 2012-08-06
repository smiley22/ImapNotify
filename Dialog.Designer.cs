namespace ImapNotify
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextMenuConfigure = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuReconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.labelImapServer = new System.Windows.Forms.Label();
			this.labelServerPort = new System.Windows.Forms.Label();
			this.labelUsername = new System.Windows.Forms.Label();
			this.textPassword = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.labelURL = new System.Windows.Forms.Label();
			this.tipURL = new System.Windows.Forms.ToolTip(this.components);
			this.autoRun = new System.Windows.Forms.CheckBox();
			this.textURL = new System.Windows.Forms.TextBox();
			this.useSSL = new System.Windows.Forms.CheckBox();
			this.playSound = new System.Windows.Forms.CheckBox();
			this.textServerPort = new System.Windows.Forms.TextBox();
			this.textUsername = new System.Windows.Forms.TextBox();
			this.textImapServer = new System.Windows.Forms.TextBox();
			this.useGmail = new System.Windows.Forms.CheckBox();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "ImapNotify";
			this.notifyIcon.Visible = true;
			this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuConfigure,
            this.contextMenuReconnect,
            this.contextMenuQuit});
			this.contextMenu.Name = "contextMenuStrip1";
			this.contextMenu.Size = new System.Drawing.Size(131, 70);
			// 
			// contextMenuConfigure
			// 
			this.contextMenuConfigure.Name = "contextMenuConfigure";
			this.contextMenuConfigure.Size = new System.Drawing.Size(130, 22);
			this.contextMenuConfigure.Text = "Configure";
			this.contextMenuConfigure.Click += new System.EventHandler(this.contextMenuConfigure_Click);
			// 
			// contextMenuReconnect
			// 
			this.contextMenuReconnect.Name = "contextMenuReconnect";
			this.contextMenuReconnect.Size = new System.Drawing.Size(130, 22);
			this.contextMenuReconnect.Text = "Reconnect";
			this.contextMenuReconnect.Click += new System.EventHandler(this.contextMenuReconnect_Click);
			// 
			// contextMenuQuit
			// 
			this.contextMenuQuit.Name = "contextMenuQuit";
			this.contextMenuQuit.Size = new System.Drawing.Size(130, 22);
			this.contextMenuQuit.Text = "Quit";
			this.contextMenuQuit.Click += new System.EventHandler(this.contextMenuQuit_Click);
			// 
			// labelImapServer
			// 
			this.labelImapServer.AutoSize = true;
			this.labelImapServer.Location = new System.Drawing.Point(12, 36);
			this.labelImapServer.Name = "labelImapServer";
			this.labelImapServer.Size = new System.Drawing.Size(67, 13);
			this.labelImapServer.TabIndex = 2;
			this.labelImapServer.Text = "IMAP Server";
			// 
			// labelServerPort
			// 
			this.labelServerPort.AutoSize = true;
			this.labelServerPort.Location = new System.Drawing.Point(12, 62);
			this.labelServerPort.Name = "labelServerPort";
			this.labelServerPort.Size = new System.Drawing.Size(60, 13);
			this.labelServerPort.TabIndex = 3;
			this.labelServerPort.Text = "Server Port";
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(9, 128);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(55, 13);
			this.labelUsername.TabIndex = 5;
			this.labelUsername.Text = "Username";
			// 
			// textPassword
			// 
			this.textPassword.Location = new System.Drawing.Point(85, 151);
			this.textPassword.Name = "textPassword";
			this.textPassword.PasswordChar = '*';
			this.textPassword.Size = new System.Drawing.Size(117, 20);
			this.textPassword.TabIndex = 6;
			this.textPassword.TextChanged += new System.EventHandler(this.text_TextChanged);
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(9, 154);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(53, 13);
			this.labelPassword.TabIndex = 7;
			this.labelPassword.Text = "Password";
			// 
			// buttonApply
			// 
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(135, 224);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 8;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 60000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// labelURL
			// 
			this.labelURL.AutoSize = true;
			this.labelURL.Location = new System.Drawing.Point(12, 88);
			this.labelURL.Name = "labelURL";
			this.labelURL.Size = new System.Drawing.Size(29, 13);
			this.labelURL.TabIndex = 13;
			this.labelURL.Text = "URL";
			// 
			// tipURL
			// 
			this.tipURL.AutomaticDelay = 0;
			this.tipURL.ShowAlways = true;
			this.tipURL.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// autoRun
			// 
			this.autoRun.AutoSize = true;
			this.autoRun.Checked = global::ImapNotify.Properties.Settings.Default.AutoRun;
			this.autoRun.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ImapNotify.Properties.Settings.Default, "AutoRun", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.autoRun.Location = new System.Drawing.Point(12, 201);
			this.autoRun.Name = "autoRun";
			this.autoRun.Size = new System.Drawing.Size(156, 17);
			this.autoRun.TabIndex = 14;
			this.autoRun.Text = "Automatically run on startup";
			this.autoRun.UseVisualStyleBackColor = true;
			this.autoRun.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
			// 
			// textURL
			// 
			this.textURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ImapNotify.Properties.Settings.Default, "URL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textURL.Location = new System.Drawing.Point(85, 85);
			this.textURL.Name = "textURL";
			this.textURL.Size = new System.Drawing.Size(117, 20);
			this.textURL.TabIndex = 4;
			this.textURL.Text = global::ImapNotify.Properties.Settings.Default.URL;
			this.textURL.TextChanged += new System.EventHandler(this.text_TextChanged);
			this.textURL.Enter += new System.EventHandler(this.textURL_Enter);
			// 
			// useSSL
			// 
			this.useSSL.AutoSize = true;
			this.useSSL.Checked = global::ImapNotify.Properties.Settings.Default.UseSSL;
			this.useSSL.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useSSL.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ImapNotify.Properties.Settings.Default, "UseSSL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.useSSL.Location = new System.Drawing.Point(136, 62);
			this.useSSL.Name = "useSSL";
			this.useSSL.Size = new System.Drawing.Size(66, 17);
			this.useSSL.TabIndex = 3;
			this.useSSL.Text = "use SSL";
			this.useSSL.UseVisualStyleBackColor = true;
			this.useSSL.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
			// 
			// playSound
			// 
			this.playSound.AutoSize = true;
			this.playSound.Checked = global::ImapNotify.Properties.Settings.Default.PlaySound;
			this.playSound.CheckState = System.Windows.Forms.CheckState.Checked;
			this.playSound.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ImapNotify.Properties.Settings.Default, "PlaySound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.playSound.Location = new System.Drawing.Point(12, 178);
			this.playSound.Name = "playSound";
			this.playSound.Size = new System.Drawing.Size(146, 17);
			this.playSound.TabIndex = 7;
			this.playSound.Text = "Play sound on new e-mail";
			this.playSound.UseVisualStyleBackColor = true;
			this.playSound.CheckedChanged += new System.EventHandler(this.checkBoxChanged);
			// 
			// textServerPort
			// 
			this.textServerPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ImapNotify.Properties.Settings.Default, "ServerPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textServerPort.Location = new System.Drawing.Point(85, 59);
			this.textServerPort.Name = "textServerPort";
			this.textServerPort.Size = new System.Drawing.Size(40, 20);
			this.textServerPort.TabIndex = 2;
			this.textServerPort.Text = global::ImapNotify.Properties.Settings.Default.ServerPort;
			this.textServerPort.TextChanged += new System.EventHandler(this.text_TextChanged);
			// 
			// textUsername
			// 
			this.textUsername.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ImapNotify.Properties.Settings.Default, "Username", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textUsername.Location = new System.Drawing.Point(85, 125);
			this.textUsername.Name = "textUsername";
			this.textUsername.Size = new System.Drawing.Size(117, 20);
			this.textUsername.TabIndex = 5;
			this.textUsername.Text = global::ImapNotify.Properties.Settings.Default.Username;
			this.textUsername.TextChanged += new System.EventHandler(this.text_TextChanged);
			// 
			// textImapServer
			// 
			this.textImapServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ImapNotify.Properties.Settings.Default, "ImapServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textImapServer.Location = new System.Drawing.Point(85, 33);
			this.textImapServer.Name = "textImapServer";
			this.textImapServer.Size = new System.Drawing.Size(117, 20);
			this.textImapServer.TabIndex = 1;
			this.textImapServer.Text = global::ImapNotify.Properties.Settings.Default.ImapServer;
			this.textImapServer.TextChanged += new System.EventHandler(this.text_TextChanged);
			// 
			// useGmail
			// 
			this.useGmail.AutoSize = true;
			this.useGmail.Checked = global::ImapNotify.Properties.Settings.Default.UseGmail;
			this.useGmail.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useGmail.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ImapNotify.Properties.Settings.Default, "UseGmail", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.useGmail.Location = new System.Drawing.Point(12, 12);
			this.useGmail.Name = "useGmail";
			this.useGmail.Size = new System.Drawing.Size(113, 17);
			this.useGmail.TabIndex = 0;
			this.useGmail.Text = "Use Gmail settings";
			this.useGmail.UseVisualStyleBackColor = true;
			this.useGmail.CheckedChanged += new System.EventHandler(this.useGmail_CheckedChanged);
			// 
			// Dialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(222, 257);
			this.Controls.Add(this.autoRun);
			this.Controls.Add(this.labelURL);
			this.Controls.Add(this.textURL);
			this.Controls.Add(this.useSSL);
			this.Controls.Add(this.textPassword);
			this.Controls.Add(this.playSound);
			this.Controls.Add(this.textServerPort);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.textUsername);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.labelServerPort);
			this.Controls.Add(this.labelImapServer);
			this.Controls.Add(this.textImapServer);
			this.Controls.Add(this.useGmail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Dialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ImapNotify";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dialog_FormClosed);
			this.Load += new System.EventHandler(this.Dialog_Load);
			this.Resize += new System.EventHandler(this.Dialog_Resize);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox useGmail;
        private System.Windows.Forms.TextBox textImapServer;
        private System.Windows.Forms.Label labelImapServer;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.TextBox textServerPort;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuQuit;
        private System.Windows.Forms.ToolStripMenuItem contextMenuConfigure;
		private System.Windows.Forms.ToolStripMenuItem contextMenuReconnect;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox playSound;
		private System.Windows.Forms.CheckBox useSSL;
		private System.Windows.Forms.Label labelURL;
		private System.Windows.Forms.TextBox textURL;
		private System.Windows.Forms.ToolTip tipURL;
		private System.Windows.Forms.CheckBox autoRun;
    }
}

