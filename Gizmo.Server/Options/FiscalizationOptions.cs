
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Regional options.
    /// </summary>
    [OptionsConfigurationSection("FISCALIZATION")]
    [StoreOptionsGroup("FISCALIZATION")]
    [MessagePack.MessagePackObject()]
    public sealed class FiscalizationOptions : IStoreOptions
    {
        /// <summary>
        /// Gets or sets whether fiscalization is enabled.
        /// </summary>
        [Name("Enable fiscalization", "SERVER_OPTION_FISCALIZATION_ENABLED_NAME")]
        [ExtendedDescription("Specifies if fiscalization is enabled", "SERVER_OPTION_FISCALIZATION_ENABLED_DESCRIPTION")]
        [StoreOptionKey("ENABLED")]
        [MessagePack.Key(0)]
        public bool IsEnabled { get; init; }
    }
}
