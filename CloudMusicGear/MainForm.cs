using CloudMusicGear.Properties;
using System;
using System.Windows.Forms;

namespace CloudMusicGear
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void portNum_ValueChanged(object sender, EventArgs e)
        {
            Config.Port = portNum.Value;
        }

        private void forcePlayback_CheckedChanged(object sender, EventArgs e)
        {
            playbackQuality.Enabled = forcePlayback.Checked;
            Config.ForcePlaybackQuality = forcePlayback.Checked;
        }

        private void playbackQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.PlaybackQuality = playbackQuality.Text;
        }

        private void forceDownload_CheckedChanged(object sender, EventArgs e)
        {
            downloadQuality.Enabled = forceDownload.Checked;
            Config.ForceDownloadQuality = forceDownload.Checked;
        }

        private void downloadQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.DownloadQuality = downloadQuality.Text;
        }

        private void useOverseas_CheckedChanged(object sender, EventArgs e)
        {
            useOverseasCdn.Enabled = useOverseas.Checked;
            overseasCdnAddress.Enabled = useOverseas.Checked;
            Config.UseOverseas = useOverseas.Checked;
        }

        private void useOverseasCdn_CheckedChanged(object sender, EventArgs e)
        {
            overseasCdnAddress.Enabled = useOverseasCdn.Checked;
            Config.UseOverseasCdn = useOverseasCdn.Checked;
        }

        private void overseasCdnAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.OverseasCdnAddress = overseasCdnAddress.Text;
        }

        private void usePac_CheckedChanged(object sender, EventArgs e)
        {
            pacPortNum.Enabled = usePac.Checked;
            Config.UsePac = usePac.Checked;
        }

        private void pacPortNum_ValueChanged(object sender, EventArgs e)
        {
            Config.PacPort = pacPortNum.Value;
        }

        private void useProxy_CheckedChanged(object sender, EventArgs e)
        {
            proxyAddress.Enabled = useProxy.Checked;
            Config.UseProxy = useProxy.Checked;
        }

        private void proxyAddress_TextChanged(object sender, EventArgs e)
        {
            Config.ProxyAddress = proxyAddress.Text;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.key_icon;
            ni.Icon = Resources.key_icon;
            Config.LoadConfiguration();
            RefreshOptions();

            if (autoStart.Checked)
            {
                startButton.PerformClick();
            }

            if (autoMinimize.Checked)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.SaveConfiguration();
        }

        private void RefreshOptions()
        {
            portNum.Value = Config.Port;

            forcePlayback.Checked = Config.ForcePlaybackQuality;
            playbackQuality.Text = Config.PlaybackQuality;

            forceDownload.Checked = Config.ForceDownloadQuality;
            downloadQuality.Text = Config.DownloadQuality;

            useOverseas.Checked = Config.UseOverseas;
            useOverseasCdn.Checked = Config.UseOverseasCdn;
            overseasCdnAddress.Enabled = Config.UseOverseas && Config.UseOverseasCdn;
            overseasCdnAddress.Text = Config.OverseasCdnAddress;

            usePac.Checked = Config.UsePac;
            pacPortNum.Value = Config.PacPort;

            useProxy.Checked = Config.UseProxy;
            proxyAddress.Text = Config.ProxyAddress;

            autoStart.Checked = Config.AutoStart;
            autoMinimize.Checked = Config.AutoMinimize;
        }

        private void LogEntry(string text)
        {
            if (log.InvokeRequired)
            {
                LogEntryCallBack cb = LogEntry;
                Invoke(cb, text);
            }
            else
            {
                log.AppendText($"[{DateTime.Now.ToLongTimeString()}]: {text}");
                log.AppendText("\r\n");
            }
        }

        private delegate void LogEntryCallBack(string text);

        private void clearLog_Click(object sender, EventArgs e)
        {
            log.Clear();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            groupOptions.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;
            Proxy.LogEntry = LogEntry;
            Proxy.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            groupOptions.Enabled = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            Proxy.Stop();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ni.Visible = true;
                ShowInTaskbar = false;
            }
        }

        private void ni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            ni.Visible = false;
        }

        private void autoStart_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoStart = autoStart.Checked;
        }

        private void autoMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Config.AutoMinimize = autoMinimize.Checked;
        }
    }
}