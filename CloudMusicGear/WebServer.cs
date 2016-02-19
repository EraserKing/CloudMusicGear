using System;
using System.Net;
using System.Text;
using System.Threading;

namespace CloudMusicGear
{
    // https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server.aspx
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        public WebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
            {
                throw new NotSupportedException("Needs Windows XP SP2, Server 2003 or later.");
            }

            if (prefixes == null || prefixes.Length == 0)
            {
                throw new ArgumentException("Invalid prefix");
            }

            if (method == null)
            {
                throw new ArgumentException("Invalid method");
            }

            foreach (string s in prefixes)
            {
                _listener.Prefixes.Add(s);
            }

            _responderMethod = method;
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes) : this(prefixes, method)
        {
        }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                string rstr = _responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            {
                            } // suppress any exceptions
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch
                {
                } // suppress any exceptions
            });
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            return "function FindProxyForURL(url, host) { if (host == \"music.163.com\") return \"PROXY 127.0.0.1:" +
                   Config.Port + "\"; else return \"DIRECT\"; }";
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
}