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
            this.chooseIPButton = new System.Windows.Forms.Button();
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
            this.groupOptions.Controls.Add(this.chooseIPButton);
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
            this.groupOptions.Location = new System.Drawing.Point(13, 13);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(683, 110);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // chooseIPButton
            // 
            this.chooseIPButton.Location = new System.Drawing.Point(125, 49);
            this.chooseIPButton.Name = "chooseIPButton";
            this.chooseIPButton.Size = new System.Drawing.Size(75, 20);
            this.chooseIPButton.TabIndex = 12;
            this.chooseIPButton.Text = "Choose IP";
            this.chooseIPButton.UseVisualStyleBackColor = true;
            this.chooseIPButton.Click += new System.EventHandler(this.chooseIPButton_Click);
            // 
            // forceIp
            // 
            this.forceIp.AutoSize = true;
            this.forceIp.Location = new System.Drawing.Point(7, 52);
            this.forceIp.Name = "forceIp";
            this.forceIp.Size = new System.Drawing.Size(111, 17);
            this.forceIp.TabIndex = 6;
            this.forceIp.Text = "Override server IP";
            this.forceIp.UseVisualStyleBackColor = true;
            this.forceIp.CheckedChanged += new System.EventHandler(this.forceIp_CheckedChanged);
            // 
            // proxyAddress
            // 
            this.proxyAddress.Enabled = false;
            this.proxyAddress.Location = new System.Drawing.Point(65, 80);
            this.proxyAddress.Name = "proxyAddress";
            this.proxyAddress.Size = new System.Drawing.Size(608, 20);
            this.proxyAddress.TabIndex = 11;
            this.proxyAddress.TextChanged += new System.EventHandler(this.proxyAddress_TextChanged);
            // 
            // useProxy
            // 
            this.useProxy.AutoSize = true;
            this.useProxy.Location = new System.Drawing.Point(7, 82);
            this.useProxy.Name = "useProxy";
            this.useProxy.Size = new System.Drawing.Size(52, 17);
            this.useProxy.TabIndex = 10;
            this.useProxy.Text = "Proxy";
            this.useProxy.UseVisualStyleBackColor = true;
            this.useProxy.CheckedChanged += new System.EventHandler(this.useProxy_CheckedChanged);
            // 
            // pacPortNum
            // 
            this.pacPortNum.Enabled = false;
            this.pacPortNum.Location = new System.Drawing.Point(552, 50);
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
            this.pacPortNum.Size = new System.Drawing.Size(67, 20);
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
            this.pacPort.Location = new System.Drawing.Point(496, 54);
            this.pacPort.Name = "pacPort";
            this.pacPort.Size = new System.Drawing.Size(49, 13);
            this.pacPort.TabIndex = 8;
            this.pacPort.Text = "PAC port";
            // 
            // usePac
            // 
            this.usePac.AutoSize = true;
            this.usePac.Location = new System.Drawing.Point(398, 53);
            this.usePac.Name = "usePac";
            this.usePac.Size = new System.Drawing.Size(83, 17);
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
            this.downloadQuality.Location = new System.Drawing.Point(552, 21);
            this.downloadQuality.Name = "downloadQuality";
            this.downloadQuality.Size = new System.Drawing.Size(121, 21);
            this.downloadQuality.TabIndex = 5;
            this.downloadQuality.SelectedIndexChanged += new System.EventHandler(this.downloadQuality_SelectedIndexChanged);
            // 
            // forceDownload
            // 
            this.forceDownload.AutoSize = true;
            this.forceDownload.Location = new System.Drawing.Point(398, 23);
            this.forceDownload.Name = "forceDownload";
            this.forceDownload.Size = new System.Drawing.Size(148, 17);
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
            this.playbackQuality.Location = new System.Drawing.Point(271, 21);
            this.playbackQuality.Name = "playbackQuality";
            this.playbackQuality.Size = new System.Drawing.Size(121, 21);
            this.playbackQuality.TabIndex = 3;
            this.playbackQuality.SelectedIndexChanged += new System.EventHandler(this.playbackQuality_SelectedIndexChanged);
            // 
            // forcePlayback
            // 
            this.forcePlayback.AutoSize = true;
            this.forcePlayback.Location = new System.Drawing.Point(120, 23);
            this.forcePlayback.Name = "forcePlayback";
            this.forcePlayback.Size = new System.Drawing.Size(145, 17);
            this.forcePlayback.TabIndex = 2;
            this.forcePlayback.Text = "Override playback quality";
            this.forcePlayback.UseVisualStyleBackColor = true;
            this.forcePlayback.CheckedChanged += new System.EventHandler(this.forcePlayback_CheckedChanged);
            // 
            // portNum
            // 
            this.portNum.Location = new System.Drawing.Point(38, 22);
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
            this.portNum.Size = new System.Drawing.Size(67, 20);
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
            this.portLabel.Location = new System.Drawing.Point(6, 24);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "Port";
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 129);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(684, 304);
            this.log.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(540, 439);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(621, 439);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(12, 440);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(75, 23);
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
            this.autoStart.Location = new System.Drawing.Point(93, 444);
            this.autoStart.Name = "autoStart";
            this.autoStart.Size = new System.Drawing.Size(124, 17);
            this.autoStart.TabIndex = 4;
            this.autoStart.Text = "Start when launched";
            this.autoStart.UseVisualStyleBackColor = true;
            this.autoStart.CheckedChanged += new System.EventHandler(this.autoStart_CheckedChanged);
            // 
            // autoMinimize
            // 
            this.autoMinimize.AutoSize = true;
            this.autoMinimize.Location = new System.Drawing.Point(223, 444);
            this.autoMinimize.Name = "autoMinimize";
            this.autoMinimize.Size = new System.Drawing.Size(142, 17);
            this.autoMinimize.TabIndex = 5;
            this.autoMinimize.Text = "Minimize when launched";
            this.autoMinimize.UseVisualStyleBackColor = true;
            this.autoMinimize.CheckedChanged += new System.EventHandler(this.autoMinimize_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 474);
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
        private System.Windows.Forms.CheckBox forceIp;
        private System.Windows.Forms.Button chooseIPButton;
    }
}

