using System;
using System.Net;

namespace Hamster_Key_Generator
{
    class Socks5ProxyClient : IWebProxy
    {
        private readonly Uri _proxyUri;

        public Socks5ProxyClient(string proxyUri)
        {
            _proxyUri = new Uri(proxyUri);
        }

        public ICredentials Credentials { get; set; }

        public Uri GetProxy(Uri destination) => _proxyUri;

        public bool IsBypassed(Uri host) => false;
    }
}
