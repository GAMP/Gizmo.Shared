using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("TOPUP")]
    [StoreOptionsGroup("TOP_UP")]
    [MessagePack.MessagePackObject()]
    public sealed class TopUpOptions : IStoreOptions
    {
        [Name("Allow custom top up value", "SERVER_OPTION_TOP_UP_ALLOW_CUSTOM_VALUE_NAME")]
        [ExtendedDescription("Specifies custom top up value is allowed", "SERVER_OPTION_TOP_UP_ALLOW_CUSTOM_VALUE_NAME_DESCRIPTION")]
        [StoreOptionKey("ALLOW_CUSTOM_VALUE")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool IsCustomValueAllowed { get; init; }

        [Name("Minimum value", "SERVER_OPTION_TOP_UP_MINIMUM_VALUE_NAME")]
        [ExtendedDescription("Specifies top up minimum value", "SERVER_OPTION_TOP_UP_MINIMUM_VALUE_DESCRIPTION")]
        [StoreOptionKey("MINIMUM_VALUE")]
        [DefaultValue(0)]
        [MessagePack.Key(1)]
        public decimal MinimumValue { get; init; }
    }
}
