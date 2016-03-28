using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CloudMusicGear
{
    public static class Utility
    {
        /// <summary>
        /// Require the content of a URL via GET method.
        /// </summary>
        /// <param name="url">URL to get.</param>
        /// <returns>Content.</returns>
        public static string GetPage(string url, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    request.Headers[key] = headers[key];
                }
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
        }

        /// <summary>
        /// Require the content of a URL via POST method.
        /// </summary>
        /// <param name="url">URL to post.</param>
        /// <param name="data">data to post</param>
        /// <returns></returns>
        public static string PostPage(string url, string data, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    request.Headers[key] = headers[key];
                }
            }

            var bytes = Encoding.UTF8.GetBytes(data);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
        }
    }
}