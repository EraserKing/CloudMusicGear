using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CloudMusicGear
{
    /// <summary>
    /// Get song url from song id.
    /// It works as this flow: extract song id from original page -> get dfs ID -> call another API to get URL -> replace the original result with the new URL.
    /// </summary>
    public static class NeteaseIdProcess
    {
        private static readonly Dictionary<string, string> SongDetailHeader = new Dictionary<string, string>()
        {
            { "cookie", "os=pc" }
        };

        /// <summary>
        /// Get song url from original song ID.
        /// </summary>
        /// <param name="songId">Song ID.</param>
        /// <param name="nQuality">Quality. Accepts: b, l, m, h.</param>
        /// <returns>Song URL.</returns>
        public static string GetUrl(string songId, string nQuality)
        {
            string data = $@"c=[{{""id"":""{songId}"",""v"":0}}]";
            string page = Utility.PostPage("http://music.163.com/api/v2/song/detail", data, SongDetailHeader);
            string dfsId = GetDfsId(page, nQuality);
            return GenerateUrl(dfsId);
        }

        /// <summary>
        /// Calculate enc ID from dfs ID.
        /// </summary>
        /// <param name="dfsId">dfs ID.</param>
        /// <returns>enc ID.</returns>
        private static string GetEncId(string dfsId)
        {
            byte[] magicBytes = new ASCIIEncoding().GetBytes("3go8&$8*3*3h0k(2)2");
            byte[] songId = new ASCIIEncoding().GetBytes(dfsId);
            for (int i = 0; i < songId.Length; i++)
            {
                songId[i] = (byte)(songId[i] ^ magicBytes[i % magicBytes.Length]);
            }
            byte[] hash = MD5.Create().ComputeHash(songId);
            return Convert.ToBase64String(hash).Replace('/', '_').Replace('+', '-');
        }

        /// <summary>
        /// Generate final URL with dfsId.
        /// </summary>
        /// <param name="dfsId"></param>
        /// <returns></returns>
        private static string GenerateUrl(string dfsId)
        {
            return $"http://m1.music.126.net/{GetEncId(dfsId)}/{dfsId}.mp3";
        }

        /// <summary>
        /// Extract dfs ID from the original API return value.
        /// </summary>
        /// <param name="pageContent">The original API return value.</param>
        /// <param name="nQuality">Quality. Accepts: bMusic, lMusic, mMusic, hMusic.</param>
        /// <returns>dfs ID.</returns>
        private static string GetDfsId(string pageContent, string nQuality)
        {
            JObject root = JObject.Parse(pageContent);

            // Downgrade if we don't have higher quality...

            if (nQuality == "h" && !root["songs"][0]["h"].HasValues)
            {
                nQuality = "m";
            }
            if (nQuality == "m" && !root["songs"][0]["m"].HasValues)
            {
                nQuality = "l";
            }
            if (nQuality == "l" && !root["songs"][0]["l"].HasValues)
            {
                nQuality = "b";
            }

            if (nQuality == "b" && !root["songs"][0]["b"].HasValues)
            {
            }

            return root["songs"][0][nQuality]["fid"].Value<string>();
        }
    }
}