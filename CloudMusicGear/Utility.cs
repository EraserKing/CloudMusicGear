using System;
using System.IO;
using System.Net;
using System.Text;

namespace CloudMusicGear
{
    public static class Utility
    {
        /// <summary>
        /// Require the content of a URL via GET method.
        /// </summary>
        /// <param name="url">URL to get.</param>
        /// <returns>Content.</returns>
        public static string GetPage(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(url);
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// Require the content of a URL via POST method.
        /// </summary>
        /// <param name="url">URL to post.</param>
        /// <param name="data">data to post</param>
        /// <returns></returns>
        public static string Post(string url, string data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Cookie", "os=pc");

                var bytes = Encoding.UTF8.GetBytes(data);
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(url);
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}