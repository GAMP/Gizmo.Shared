#nullable enable

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
        [DefaultValue(HttpProtocols.Http)]
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
    }
}
