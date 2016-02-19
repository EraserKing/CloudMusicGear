namespace CloudMusicGear
{
    internal static class Config
    {
        public static void LoadConfiguration()
        {
            Port = Properties.Settings.Default.Port;
            ForcePlaybackQuality = Properties.Settings.Default.ForcePlaybackQuality;
            PlaybackQuality = Properties.Settings.Default.PlaybackQuality;
            ForceDownloadQuality = Properties.Settings.Default.ForceDownloadQuality;
            DownloadQuality = Properties.Settings.Default.DownloadQuality;
            UseOverseas = Properties.Settings.Default.UseOverseas;
            UseOverseasCdn = Properties.Settings.Default.UseOverseasCdn;
            OverseasCdnAddress = Properties.Settings.Default.OverseasCdnAddress;
            UsePac = Properties.Settings.Default.UsePac;
            PacPort = Properties.Settings.Default.PacPort;
            UseProxy = Properties.Settings.Default.UseProxy;
            ProxyAddress = Properties.Settings.Default.ProxyAddress;
            AutoStart = Properties.Settings.Default.AutoStart;
            AutoMinimize = Properties.Settings.Default.AutoMinimize;
        }

        public static void SaveConfiguration()
        {
            Properties.Settings.Default.Port = Port;
            Properties.Settings.Default.ForcePlaybackQuality = ForcePlaybackQuality;
            Properties.Settings.Default.PlaybackQuality = PlaybackQuality;
            Properties.Settings.Default.ForceDownloadQuality = ForceDownloadQuality;
            Properties.Settings.Default.DownloadQuality = DownloadQuality;
            Properties.Settings.Default.UseOverseas = UseOverseas;
            Properties.Settings.Default.UseOverseasCdn = UseOverseasCdn;
            Properties.Settings.Default.OverseasCdnAddress = OverseasCdnAddress;
            Properties.Settings.Default.UsePac = UsePac;
            Properties.Settings.Default.PacPort = PacPort;
            Properties.Settings.Default.UseProxy = UseProxy;
            Properties.Settings.Default.ProxyAddress = ProxyAddress;
            Properties.Settings.Default.AutoStart = AutoStart;
            Properties.Settings.Default.AutoMinimize = AutoMinimize;
            Properties.Settings.Default.Save();
        }

        public static decimal Port = 3412;

        public static bool ForcePlaybackQuality { get; set; } = false;
        public static string PlaybackQuality { get; set; } = string.Empty;

        public static bool ForceDownloadQuality { get; set; } = false;
        public static string DownloadQuality { get; set; } = string.Empty;

        public static bool UseOverseas { get; set; } = false;
        public static bool UseOverseasCdn { get; set; } = false;
        public static string OverseasCdnAddress { get; set; } = string.Empty;

        public static bool UsePac { get; set; } = false;
        public static decimal PacPort = 3413;

        public static bool UseProxy { get; set; } = false;
        public static string ProxyAddress { get; set; } = string.Empty;

        public static bool AutoStart { get; set; } = false;
        public static bool AutoMinimize { get; set; } = false;
    }
}