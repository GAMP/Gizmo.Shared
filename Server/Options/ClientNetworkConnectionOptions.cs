using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("CLIENTNETWORKCONNECTION")]
    [StoreOptionsGroup("CLIENT_NETWORK_CONNECTION")]
    [MessagePack.MessagePackObject()]
    public sealed class ClientNetworkConnectionOptions : IStoreOptions
    {
        [Name("Registered only", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_REGISTERED_ONLY_NAME")]
        [ExtendedDescription("Enable or disable connection of unregister clients", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_REGISTERED_ONLY_DESCRIPTION")]
        [StoreOptionKey("REGISTERED_ONLY")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool RegisteredOnly { get; init; }

        [Name("Auto discovery", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_AUTO_DISCOVERY_NAME")]
        [ExtendedDescription("Enable or disable clients auto discovery", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_AUTO_DISCOVERY_DESCRIPTION")]
        [StoreOptionKey("AUTO_DISCOVERY")]
        [DefaultValue(false)]
        [MessagePack.Key(1)]
        public bool AutoDiscovery {  get; set; }

        [Name("Restore host names", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_RESTORE_HOST_NAME_NAME")]
        [ExtendedDescription("Enable or disable clients hostname restoration", "SERVER_OPTION_CLIENT_NETWORK_CONNECTION_RESTORE_HOST_NAME_DESCRIPTION")]
        [StoreOptionKey("RESTORE_HOST_NAME")]
        [DefaultValue(false)]
        [MessagePack.Key(2)]
        public bool RestoreHostName { get; set; }
    }
}
