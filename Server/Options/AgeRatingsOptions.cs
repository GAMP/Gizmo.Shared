using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Age ratings options.
    /// </summary>
    [OptionsConfigurationSection("AGERATINGS")]
    [StoreOptionsGroup("AGE_RATINGS")]
    public sealed class AgeRatingsOptions : IStoreOptions
    {
        [Name("Enable age ratings", "SERVER_OPTION_AGE_RATINGS_ENABLED_NAME")]
        [ExtendedDescription("Specifies if age ratings are enabled", "SERVER_OPTION_AGE_RATINGS_ENABLED_DESCRIPTION")]
        [StoreOptionKey("ENABLED")]
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool IsEnabled { get; init; }

        [Name("Enable age ratings login restrictions", "SERVER_OPTION_AGE_RATINGS_LOGIN_RESTRICTIONS_ENABLED_NAME")]
        [ExtendedDescription("Specifies if age ratings login restrictions are enabled", "SERVER_OPTION_AGE_RATINGS_LOGIN_RESTRICTIONS_ENABLED_DESCRIPTION")]
        [StoreOptionKey("LOGIN_RESTRICTIONS_ENABLED")]
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsLoginRestrictionEnabled { get; init; }
    }
}
