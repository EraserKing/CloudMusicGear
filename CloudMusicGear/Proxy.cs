using Fiddler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace CloudMusicGear
{
    public static class Proxy
    {
        private static readonly Regex RexPl = new Regex("\"pl\":\\d+", RegexOptions.Compiled);
        private static readonly Regex RexDl = new Regex("\"dl\":\\d+", RegexOptions.Compiled);
        private static readonly Regex RexSt = new Regex("\"st\":-?\\d+", RegexOptions.Compiled);
        private static readonly Regex RexSubp = new Regex("\"subp\":\\d+", RegexOptions.Compiled);

        private static WebServer _ws;

        public static Action<string> LogEntry { private get; set; }

        private static void NeedBufferResponse(Session s)
        {
            // We just need to hack APIs and so let other HTTP requests pass directly. API responses must be fully buffered (and then modified).
            s.bBufferResponse = s.fullUrl.Contains("http://music.163.com/eapi/");
        }

        private static void NeedSetProxy(Session s)
        {
            s["X-OverrideGateway"] = Config.ProxyAddress;
        }

        private static void NeedSetIp(Session s)
        {
            if (s.fullUrl.EndsWith(".mp3"))
            {
                s["X-OverrideHost"] = Config.IpAddress;
            }
        }

        public static void Start()
        {
            LogEntry("Starting proxy...");
            FiddlerCoreStartupFlags fcsf = FiddlerCoreStartupFlags.None;
            FiddlerApplication.Startup((int)Config.Port, fcsf);

            FiddlerApplication.BeforeRequest += NeedBufferResponse;
            if (Config.UseProxy)
            {
                FiddlerApplication.BeforeRequest += NeedSetProxy;
            }
            if (Config.ForceIp)
            {
                FiddlerApplication.BeforeRequest += NeedSetIp;
            }
            FiddlerApplication.BeforeResponse += OnResponse;
            LogEntry($"Proxy started, listening at port {Config.Port}");

            if (Config.UsePac)
            {
                LogEntry("Starting PAC Server...");
                string pacUrl = $"http://localhost:{Config.PacPort}/pac/";
                _ws = new WebServer(WebServer.SendResponse, pacUrl);
                _ws.Run();
                LogEntry($"PAC Server started. Please set system proxy to {pacUrl}");
            }
        }

        public static void Stop()
        {
            LogEntry("Stopping proxy...");

            FiddlerApplication.BeforeRequest -= NeedBufferResponse;
            if (Config.UseProxy)
            {
                FiddlerApplication.BeforeRequest -= NeedSetProxy;
            }
            if (Config.ForceIp)
            {
                FiddlerApplication.BeforeRequest -= NeedSetIp;
            }
            FiddlerApplication.BeforeResponse -= OnResponse;
            FiddlerApplication.Shutdown();

            LogEntry("Proxy stopped");

            if (Config.UsePac)
            {
                LogEntry("Stopping PAC Server...");
                _ws?.Stop();
                LogEntry("PAC Server stopped");
            }
        }

        private static void OnResponse(Session s)
        {
            int responseStatusCode = s.responseCode;
            string responseContentType = s.ResponseHeaders["Content-Type"].Trim().ToLower();
            string url = s.fullUrl;

            if (responseStatusCode == 200)
            {
                // Most APIs are returned in text/plain but searching songs page is returned in JSON. Don't forget this!
                if (responseContentType.Contains("text/plain") || responseContentType.Contains("application/json"))
                {
                    LogEntry($"Accessing URL {url}");

                    // It should include album / playlist / artist / search pages.
                    if (url.Contains("/eapi/v3/song/detail/") || url.Contains("/eapi/v1/album/") || url.Contains("/eapi/v3/playlist/detail") ||
                        url.Contains("/eapi/batch") || url.Contains("/eapi/cloudsearch/pc") || url.Contains("/eapi/v1/artist") ||
                        url.Contains("/eapi/v1/search/get") || url.Contains("/eapi/song/enhance/privilege"))
                    {
                        string modified = ModifyDetailApi(s.GetResponseBodyAsString());
                        s.utilSetResponseBody(modified);
                    }
                    // This is called when player tries to get the URL for a song.
                    else if (url.Contains("/eapi/song/enhance/player/url"))
                    {
                        string bitrate = GetPlaybackBitrateFromApi(s.GetResponseBodyAsString());
                        // Whatever current playback bitrate is, it's overriden.
                        if (Config.ForcePlaybackQuality)
                        {
                            bitrate = ConvertQuality(Config.PlaybackQuality, "Bitrate");
                            LogEntry($"Plackback bitrate is forced set to {bitrate}");
                        }
                        // We receive a wrong bitrate...
                        else if (bitrate == "0")
                        {
                            bitrate = Config.ForcePlaybackQuality ? ConvertQuality(Config.PlaybackQuality, "Bitrate") : "320000";
                            LogEntry($"Plackback bitrate is restored to {bitrate} as the given bitrate is not valid.");
                        }
                        // If we received an unexpected bitrate...
                        else if (bitrate != ConvertQuality(Config.PlaybackQuality, "Bitrate"))
                        {
                            LogEntry($"Plackback bitrate is switched to {bitrate} from {ConvertQuality(Config.PlaybackQuality, "Bitrate")}");
                        }
                        Config.PlaybackQuality = ConvertQuality(bitrate, "Full");
                        string modified = ModifyPlayerApi(s.GetResponseBodyAsString());
                        s.utilSetResponseBody(modified);
                    }

                    // When we try to download a song, the API tells whether it exceeds the limit. Of course no!
                    else if (url.Contains("/eapi/song/download/limit"))
                    {
                        string modified = ModifyDownloadLimitApi();
                        s.utilSetResponseBody(modified);
                    }

                    // Similar to the player URL API, but used for download.
                    else if (url.Contains("/eapi/song/enhance/download/url"))
                    {
                        string bitrate = GetDownloadBitrate(s.GetResponseBodyAsString());

                        // Whatever current download bitrate is, it's overriden.
                        if (Config.ForceDownloadQuality)
                        {
                            bitrate = ConvertQuality(Config.DownloadQuality, "Bitrate");
                            LogEntry($"Download bitrate is forced set to {bitrate}");
                        }
                        // We receive a wrong bitrate...
                        else if (bitrate == "0")
                        {
                            bitrate = Config.ForceDownloadQuality ? ConvertQuality(Config.DownloadQuality, "Bitrate") : "320000";
                            LogEntry($"Download bitrate is forced set to {bitrate} as the given bitrate is not valid.");
                        }
                        else if (bitrate != ConvertQuality(Config.DownloadQuality, "Bitrate"))
                        {
                            LogEntry($"Download bitrate is switched to {bitrate} from {ConvertQuality(Config.DownloadQuality, "Bitrate")}");
                        }
                        Config.DownloadQuality = ConvertQuality(bitrate, "Full");

                        string modified = ModifyDownloadApi(s.GetResponseBodyAsString());
                        s.utilSetResponseBody(modified);
                    }
                }
            }
        }

        /// <summary>
        /// Get current playback bitrate from API result.
        /// </summary>
        /// <param name="apiResult">API result containing playback bitrate.</param>
        /// <returns>Current playback bitrate.</returns>
        private static string GetPlaybackBitrateFromApi(string apiResult)
        {
            JObject root = JObject.Parse(apiResult);
            string bitrate = root["data"][0]["br"].Value<string>();
            return bitrate;
        }

        /// <summary>
        /// Get current download bitrate from API result.
        /// </summary>
        /// <param name="apiResult">API result containing download bitrate.</param>
        /// <returns>Current download bitrate.</returns>
        private static string GetDownloadBitrate(string apiResult)
        {
            JObject root = JObject.Parse(apiResult);
            string bitrate = root["data"]["br"].Value<string>();
            return bitrate;
        }

        /// <summary>
        /// Hack the result of download limit API.
        /// </summary>
        /// <returns>Just return a normal status.</returns>
        private static string ModifyDownloadLimitApi()
        {
            return "{\"overflow\":false,\"code\":200}";
        }

        /// <summary>
        /// Hack the result of download API and redirects it to the new URL.
        /// </summary>
        /// <param name="originalContent">The original API result.</param>
        /// <returns>The modified API result.</returns>
        private static string ModifyDownloadApi(string originalContent)
        {
            LogEntry("Hack download API");

            JObject root = JObject.Parse(originalContent);
            string songId = root["data"]["id"].Value<string>();
            string newUrl = NeteaseIdProcess.GetUrl(songId, ConvertQuality(Config.DownloadQuality, "nQuality"));
            LogEntry($"New URL is {newUrl}");
            root["data"]["url"] = newUrl;
            root["data"]["br"] = ConvertQuality(Config.DownloadQuality, "Bitrate");
            root["data"]["code"] = "200";

            return root.ToString(Formatting.None);
        }

        /// <summary>
        /// Hack the result of song / album / playlist API and treat the client to let it work as the song is not disabled.
        /// </summary>
        /// <param name="originalContent">The original API result.</param>
        /// <returns>The modified API result.</returns>
        private static string ModifyDetailApi(string originalContent)
        {
            LogEntry("Hack detail API");

            string modified = originalContent;
            //Playback bitrate
            modified = RexPl.Replace(modified, $"\"pl\":{ConvertQuality(Config.PlaybackQuality, "Bitrate")}");

            //Download bitrate
            modified = RexDl.Replace(modified, $"\"dl\":{ConvertQuality(Config.DownloadQuality, "Bitrate")}");

            //Disabled
            modified = RexSt.Replace(modified, "\"st\":0");

            //Can favorite
            modified = RexSubp.Replace(modified, "\"subp\":1");
            return modified;
        }

        /// <summary>
        /// Hack the result of player getting song URL and redirects it to the new URL.
        /// </summary>
        /// <param name="originalContent">The original API result.</param>
        /// <returns>The modified API result.</returns>
        private static string ModifyPlayerApi(string originalContent)
        {
            LogEntry("Hack player API");

            JObject root = JObject.Parse(originalContent);
            string songId = root["data"][0]["id"].Value<string>();
            string newUrl = NeteaseIdProcess.GetUrl(songId, ConvertQuality(Config.PlaybackQuality, "nQuality"));
            LogEntry($"New URL is {newUrl}");
            root["data"][0]["url"] = newUrl;
            root["data"][0]["br"] = ConvertQuality(Config.PlaybackQuality, "Bitrate");
            root["data"][0]["code"] = "200";

            return root.ToString(Formatting.None);
        }

        private static string ConvertQuality(string quality, string mode)
        {
            string fullQuality;
            switch (quality)
            {
                case "HQ / 320000":
                case "MQ / 192000":
                case "LQ / 128000":
                case "BQ / 96000":
                    fullQuality = quality;
                    break;

                case "HQ":
                case "320000":
                    fullQuality = "HQ / 320000";
                    break;

                case "MQ":
                case "192000":
                    fullQuality = "MQ / 192000";
                    break;

                case "LQ":
                case "128000":
                    fullQuality = "LQ / 128000";
                    break;

                case "BQ":
                case "96000":
                    fullQuality = "BQ / 96000";
                    break;

                default:
                    throw new ArgumentException($"Quality source = {quality}");
            }

            switch (mode)
            {
                case "Quality":
                    return fullQuality.Substring(0, 2);

                case "Bitrate":
                    return fullQuality.Substring(5);

                case "nQuality":
                    return fullQuality.Substring(0, 1).ToLower() + "Music";

                case "Full":
                    return fullQuality;

                default:
                    throw new ArgumentException($"Mode = {mode}");
            }
        }
    }
}