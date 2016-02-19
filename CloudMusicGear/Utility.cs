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
    }
}