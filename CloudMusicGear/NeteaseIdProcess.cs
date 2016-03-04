using Newtonsoft.Json.Linq;
using System;
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
        /// <summary>
        /// Get song url from original song ID.
        /// </summary>
        /// <param name="songId">Song ID.</param>
        /// <param name="nQuality">Quality. Accepts: bMusic, lMusic, mMusic, hMusic.</param>
        /// <returns>Song URL.</returns>
        public static string GetUrl(string songId, string nQuality)
        {
            string dfsId = GetDfsId(Utility.GetPage($"http://music.163.com/api/song/detail?id={songId}&ids=[{songId}]"), nQuality);
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
            return $"http://m{DateTime.Now.Second % 2 + 1}.music.126.net/{GetEncId(dfsId)}/{dfsId}.mp3";
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

            if (nQuality == "hMusic" && !root["songs"][0]["hMusic"].HasValues)
            {
                nQuality = "mMusic";
            }
            if (nQuality == "mMusic" && !root["songs"][0]["mMusic"].HasValues)
            {
                nQuality = "lMusic";
            }
            if (nQuality == "lMusic" && !root["songs"][0]["lMusic"].HasValues)
            {
                nQuality = "bMusic";
            }

            if (nQuality == "bMusic" && !root["songs"][0]["bMusic"].HasValues)
            {
            }

            return root["songs"][0][nQuality]["dfsId"].Value<string>();
        }
    }
}