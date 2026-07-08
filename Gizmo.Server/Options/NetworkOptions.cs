
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("NETWORK")]
    [StoreOptionsGroup("NETWORK")]
    [MessagePack.MessagePackObject()]
    public sealed class NetworkOptions : IStoreOptions
    {
        [Name("Protocols", "SERVER_OPTION_NETWORK_HTTP_PROTOCOLS_NAME")]
        [StoreOptionKey("HTTP_PROTOCOLS")]
        [DefaultValue(HttpProtocols.HttpHttps)]
        [MessagePack.Key(0)]
        public HttpProtocols HttpProtocols {  get; set; } 

        [Name("Http port", "SERVER_OPTION_NETWORK_HTTP_PORT_NAME")]
        [StoreOptionKey("HTTP_PORT")]
        [Range(1, 65535)]
        [MessagePack.Key(1)]
        public int? HttpPort { get; set; }

        [Name("Https port", "SERVER_OPTION_NETWORK_HTTPS_PORT_NAME")]
        [StoreOptionKey("HTTPS_PORT")]
        [Range(1, 65535)]
        [MessagePack.Key(2)]
        public int? HttpsPort { get; set; }

        [Name("Host name", "SERVER_OPTION_NETWORK_HOST_NAME_NAME")]
        [StoreOptionKey("HOST_NAME")]
        [Required()]
        [MessagePack.Key(3)]
        public string? HostName { get; init; }

        /// <summary>
        /// Gets or sets whether the server runs behind a TLS-terminating reverse proxy.
        /// </summary>
        /// <remarks>
        /// When enabled the server trusts the X-Forwarded-Proto / X-Forwarded-Host headers set by the
        /// upstream proxy so that generated URLs (e.g. the remote control viewer URL) reflect the scheme
        /// and host the client actually used, rather than the plain-HTTP connection between the proxy and
        /// this server. Enable this ONLY when the server is always fronted by a trusted proxy, since it
        /// causes the forwarded headers to be trusted from any immediate caller.
        /// </remarks>
        [Name("Behind reverse proxy", "SERVER_OPTION_NETWORK_BEHIND_REVERSE_PROXY_NAME")]
        [StoreOptionKey("BEHIND_REVERSE_PROXY")]
        [DefaultValue(false)]
        [MessagePack.Key(4)]
        public bool BehindReverseProxy { get; set; }
    }
}
