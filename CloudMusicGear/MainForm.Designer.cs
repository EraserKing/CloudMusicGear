namespace CloudMusicGear
{
    partial class MainForm
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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.ipAddress = new System.Windows.Forms.ComboBox();
            this.forceIp = new System.Windows.Forms.CheckBox();
            this.proxyAddress = new System.Windows.Forms.TextBox();
            this.useProxy = new System.Windows.Forms.CheckBox();
            this.pacPortNum = new System.Windows.Forms.NumericUpDown();
            this.pacPort = new System.Windows.Forms.Label();
            this.usePac = new System.Windows.Forms.CheckBox();
            this.downloadQuality = new System.Windows.Forms.ComboBox();
            this.forceDownload = new System.Windows.Forms.CheckBox();
            this.playbackQuality = new System.Windows.Forms.ComboBox();
            this.forcePlayback = new System.Windows.Forms.CheckBox();
            this.portNum = new System.Windows.Forms.NumericUpDown();
            this.portLabel = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearLog = new System.Windows.Forms.Button();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.autoStart = new System.Windows.Forms.CheckBox();
            this.autoMinimize = new System.Windows.Forms.CheckBox();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pacPortNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.ipAddress);
            this.groupOptions.Controls.Add(this.forceIp);
            this.groupOptions.Controls.Add(this.proxyAddress);
            this.groupOptions.Controls.Add(this.useProxy);
            this.groupOptions.Controls.Add(this.pacPortNum);
            this.groupOptions.Controls.Add(this.pacPort);
            this.groupOptions.Controls.Add(this.usePac);
            this.groupOptions.Controls.Add(this.downloadQuality);
            this.groupOptions.Controls.Add(this.forceDownload);
            this.groupOptions.Controls.Add(this.playbackQuality);
            this.groupOptions.Controls.Add(this.forcePlayback);
            this.groupOptions.Controls.Add(this.portNum);
            this.groupOptions.Controls.Add(this.portLabel);
            this.groupOptions.Location = new System.Drawing.Point(13, 12);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(683, 102);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // ipAddress
            // 
            this.ipAddress.Enabled = false;
            this.ipAddress.FormattingEnabled = true;
            this.ipAddress.Items.AddRange(new object[]
            {
                "103.4.200.196",
                "103.4.200.226",
                "115.231.158.44",
                "115.231.171.46",
                "122.226.182.76",
                "122.226.182.77",
                "122.226.213.107",
                "123.58.180.105",
                "123.58.180.106",
                "180.153.126.29",
                "180.97.180.71",
                "183.131.161.29",
                "183.131.161.44",
                "183.131.82.15",
                "222.186.160.173",
                "222.186.160.183",
                "49.79.232.58",
                "58.220.2.78",
                "58.220.2.95",
                "61.153.56.132",
                "61.160.243.142",
                "61.160.243.143",
                "61.160.243.144",
                "61.160.243.145",
                "61.160.243.176",
                "61.160.243.177",
                "61.160.243.182",
                "61.160.243.183",
                "61.160.243.184",
                "61.160.243.185",
                "111.161.66.70",
                "111.47.243.70",
                "111.47.243.71",
                "112.25.57.4",
                "112.90.222.30",
                "113.207.34.208",
                "117.177.240.83",
                "117.177.240.84",
                "117.177.240.85",
                "117.177.240.86",
                "117.177.240.87",
                "120.192.200.52",
                "120.192.200.53",
                "120.192.200.54",
                "120.192.249.76",
                "123.138.188.131",
                "123.150.52.162",
                "123.150.53.8",
                "123.159.202.138",
                "124.239.198.199",
                "124.239.198.200",
                "124.67.23.15",
                "163.177.135.198",
                "163.177.135.199",
                "163.177.135.206",
                "163.177.135.207",
                "163.177.169.204",
                "163.177.169.205",
                "163.177.169.221",
                "183.95.153.10",
                "210.76.57.7",
                "218.24.18.8",
                "218.29.229.200",
                "221.181.207.175",
                "221.194.130.200",
                "221.194.130.202",
                "221.194.130.203",
                "60.6.196.135"
            });
            this.ipAddress.Location = new System.Drawing.Point(136, 46);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(121, 20);
            this.ipAddress.TabIndex = 7;
            this.ipAddress.Text = "111.161.66.70";
            this.ipAddress.SelectedIndexChanged += new System.EventHandler(this.ipAddress_SelectedIndexChanged);
            // 
            // forceIp
            // 
            this.forceIp.AutoSize = true;
            this.forceIp.Location = new System.Drawing.Point(7, 48);
            this.forceIp.Name = "forceIp";
            this.forceIp.Size = new System.Drawing.Size(132, 16);
            this.forceIp.TabIndex = 6;
            this.forceIp.Text = "Override server IP";
            this.forceIp.UseVisualStyleBackColor = true;
            this.forceIp.CheckedChanged += new System.EventHandler(this.forceIp_CheckedChanged);
            // 
            // proxyAddress
            // 
            this.proxyAddress.Enabled = false;
            this.proxyAddress.Location = new System.Drawing.Point(65, 74);
            this.proxyAddress.Name = "proxyAddress";
            this.proxyAddress.Size = new System.Drawing.Size(608, 21);
            this.proxyAddress.TabIndex = 11;
            this.proxyAddress.TextChanged += new System.EventHandler(this.proxyAddress_TextChanged);
            // 
            // useProxy
            // 
            this.useProxy.AutoSize = true;
            this.useProxy.Location = new System.Drawing.Point(7, 76);
            this.useProxy.Name = "useProxy";
            this.useProxy.Size = new System.Drawing.Size(54, 16);
            this.useProxy.TabIndex = 10;
            this.useProxy.Text = "Proxy";
            this.useProxy.UseVisualStyleBackColor = true;
            this.useProxy.CheckedChanged += new System.EventHandler(this.useProxy_CheckedChanged);
            // 
            // pacPortNum
            // 
            this.pacPortNum.Enabled = false;
            this.pacPortNum.Location = new System.Drawing.Point(552, 46);
            this.pacPortNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.pacPortNum.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.pacPortNum.Name = "pacPortNum";
            this.pacPortNum.Size = new System.Drawing.Size(67, 21);
            this.pacPortNum.TabIndex = 9;
            this.pacPortNum.Value = new decimal(new int[] {
            3413,
            0,
            0,
            0});
            this.pacPortNum.ValueChanged += new System.EventHandler(this.pacPortNum_ValueChanged);
            // 
            // pacPort
            // 
            this.pacPort.AutoSize = true;
            this.pacPort.Location = new System.Drawing.Point(496, 50);
            this.pacPort.Name = "pacPort";
            this.pacPort.Size = new System.Drawing.Size(53, 12);
            this.pacPort.TabIndex = 8;
            this.pacPort.Text = "PAC port";
            // 
            // usePac
            // 
            this.usePac.AutoSize = true;
            this.usePac.Location = new System.Drawing.Point(398, 49);
            this.usePac.Name = "usePac";
            this.usePac.Size = new System.Drawing.Size(84, 16);
            this.usePac.TabIndex = 8;
            this.usePac.Text = "Enable PAC";
            this.usePac.UseVisualStyleBackColor = true;
            this.usePac.CheckedChanged += new System.EventHandler(this.usePac_CheckedChanged);
            // 
            // downloadQuality
            // 
            this.downloadQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.downloadQuality.Enabled = false;
            this.downloadQuality.FormattingEnabled = true;
            this.downloadQuality.Items.AddRange(new object[] {
            "HQ / 320000",
            "MQ / 192000",
            "LQ / 128000",
            "BQ / 96000"});
            this.downloadQuality.Location = new System.Drawing.Point(552, 19);
            this.downloadQuality.Name = "downloadQuality";
            this.downloadQuality.Size = new System.Drawing.Size(121, 20);
            this.downloadQuality.TabIndex = 5;
            this.downloadQuality.SelectedIndexChanged += new System.EventHandler(this.downloadQuality_SelectedIndexChanged);
            // 
            // forceDownload
            // 
            this.forceDownload.AutoSize = true;
            this.forceDownload.Location = new System.Drawing.Point(398, 21);
            this.forceDownload.Name = "forceDownload";
            this.forceDownload.Size = new System.Drawing.Size(174, 16);
            this.forceDownload.TabIndex = 4;
            this.forceDownload.Text = "Override download quality";
            this.forceDownload.UseVisualStyleBackColor = true;
            this.forceDownload.CheckedChanged += new System.EventHandler(this.forceDownload_CheckedChanged);
            // 
            // playbackQuality
            // 
            this.playbackQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playbackQuality.Enabled = false;
            this.playbackQuality.FormattingEnabled = true;
            this.playbackQuality.Items.AddRange(new object[] {
            "HQ / 320000",
            "MQ / 192000",
            "LQ / 128000",
            "BQ / 96000"});
            this.playbackQuality.Location = new System.Drawing.Point(271, 19);
            this.playbackQuality.Name = "playbackQuality";
            this.playbackQuality.Size = new System.Drawing.Size(121, 20);
            this.playbackQuality.TabIndex = 3;
            this.playbackQuality.SelectedIndexChanged += new System.EventHandler(this.playbackQuality_SelectedIndexChanged);
            // 
            // forcePlayback
            // 
            this.forcePlayback.AutoSize = true;
            this.forcePlayback.Location = new System.Drawing.Point(120, 21);
            this.forcePlayback.Name = "forcePlayback";
            this.forcePlayback.Size = new System.Drawing.Size(174, 16);
            this.forcePlayback.TabIndex = 2;
            this.forcePlayback.Text = "Override playback quality";
            this.forcePlayback.UseVisualStyleBackColor = true;
            this.forcePlayback.CheckedChanged += new System.EventHandler(this.forcePlayback_CheckedChanged);
            // 
            // portNum
            // 
            this.portNum.Location = new System.Drawing.Point(38, 20);
            this.portNum.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNum.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.portNum.Name = "portNum";
            this.portNum.Size = new System.Drawing.Size(67, 21);
            this.portNum.TabIndex = 1;
            this.portNum.Value = new decimal(new int[] {
            3412,
            0,
            0,
            0});
            this.portNum.ValueChanged += new System.EventHandler(this.portNum_ValueChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(6, 22);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 12);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 119);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(684, 281);
            this.log.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(540, 405);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 21);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(621, 405);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 21);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(12, 406);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 21);
            this.clearLog.TabIndex = 3;
            this.clearLog.Text = "Clear";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // ni
            // 
            this.ni.BalloonTipText = "Double click to restore";
            this.ni.BalloonTipTitle = "Cloud Music Gear";
            this.ni.Text = "Cloud Music Gear";
            this.ni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ni_MouseDoubleClick);
            // 
            // autoStart
            // 
            this.autoStart.AutoSize = true;
            this.autoStart.Location = new System.Drawing.Point(93, 410);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(138, 16);
            this.autoStart.TabIndex = 4;
            this.autoStart.Text = "Start when launched";
            this.autoStart.UseVisualStyleBackColor = true;
            this.autoStart.CheckedChanged += new System.EventHandler(this.autoStart_CheckedChanged);
            // 
            // autoMinimize
            // 
            this.autoMinimize.AutoSize = true;
            this.autoMinimize.Location = new System.Drawing.Point(223, 410);
            this.autoMinimize.Name = "autoMinimize";
            this.autoMinimize.Size = new System.Drawing.Size(156, 16);
            this.autoMinimize.TabIndex = 5;
            this.autoMinimize.Text = "Minimize when launched";
            this.autoMinimize.UseVisualStyleBackColor = true;
            this.autoMinimize.CheckedChanged += new System.EventHandler(this.autoMinimize_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 439);
            this.Controls.Add(this.autoMinimize);
            this.Controls.Add(this.autoStart);
            this.Controls.Add(this.clearLog);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.log);
            this.Controls.Add(this.groupOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CloudMusicGear";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pacPortNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.NumericUpDown pacPortNum;
        private System.Windows.Forms.Label pacPort;
        private System.Windows.Forms.CheckBox usePac;
        private System.Windows.Forms.ComboBox downloadQuality;
        private System.Windows.Forms.CheckBox forceDownload;
        private System.Windows.Forms.ComboBox playbackQuality;
        private System.Windows.Forms.CheckBox forcePlayback;
        private System.Windows.Forms.NumericUpDown portNum;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox proxyAddress;
        private System.Windows.Forms.CheckBox useProxy;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.CheckBox autoStart;
        private System.Windows.Forms.CheckBox autoMinimize;
        private System.Windows.Forms.ComboBox ipAddress;
        private System.Windows.Forms.CheckBox forceIp;
    }
}

