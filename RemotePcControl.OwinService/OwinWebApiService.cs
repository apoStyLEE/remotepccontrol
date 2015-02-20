using System;
using Microsoft.Owin.Hosting;

namespace RemotePcControl.OwinService
{
    public class OwinWebApiService
    {
        private readonly string _url;
        private IDisposable _server;

        public OwinWebApiService(string url)
        {
            _url = url;
        }

        public void Start()
        {
            _server = WebApp.Start<Startup>(_url);
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}