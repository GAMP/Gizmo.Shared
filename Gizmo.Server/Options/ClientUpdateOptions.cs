using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("CLIENTUPDATE")]
    [StoreOptionsGroup("CLIENT_UPDATE")]
    [MessagePack.MessagePackObject()]
    public sealed class ClientUpdateOptions : IStoreOptions
    {
        [Name("Enable client auto-update", "SERVER_OPTION_CLIENT_UPDATE_AUTO_UPDATE_ENABLED_NAME")]
        [StoreOptionKey("AUTO_UPDATE_ENABLED")]
        [DefaultValue(true)]
        [MessagePack.Key(0)]
        public bool UpdateEnabled { get; init; }

        [Name("Enable client auto-downgrade", "SERVER_OPTION_CLIENT_UPDATE_AUTO_DOWNGRADE_ENABLED_NAME")]
        [StoreOptionKey("AUTO_DOWNGRADE_ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(1)]
        public bool DownGradeEnabled { get; init; }
    }
}
