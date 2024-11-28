using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Age restrictions options.
    /// </summary>
    [OptionsConfigurationSection("AGERESTRICTIONS")]
    [StoreOptionsGroup("AGE_RESTRICTIONS")]
    [MessagePack.MessagePackObject()]
    public sealed class AgeRestrictionsOptions : IStoreOptions
    {
        [Name("Enable age restrictions for applications", "SERVER_OPTION_AGE_RESTRICTIONS_APPLICATIONS_ENABLED_NAME")]
        [ExtendedDescription("Specifies if age restrictions enabled for applications", "SERVER_OPTION_AGE_RESTRICTIONS_APPLICATIONS_ENABLED_DESCRIPTION")]
        [StoreOptionKey("APPLICATIONS_ENABLED")]
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool IsApplicationsEnabled { get; init; }

        [Name("Enable age restrictions for login", "SERVER_OPTION_AGE_RESTRICTIONS_LOGIN_ENABLED_NAME")]
        [ExtendedDescription("Specifies if age restrictions enabled for login", "SERVER_OPTION_AGE_RESTRICTIONS_LOGIN_ENABLED_DESCRIPTION")]
        [StoreOptionKey("LOGIN_ENABLED")]
        [MessagePack.Key(1)]
        [DefaultValue(false)]
        public bool IsLoginEnabled { get; init; }

        /// <summary>
        /// Deny login for users with unknown age.
        /// </summary>
        /// <remarks>
        /// This option depends on <see cref="IsLoginEnabled"/>.
        /// </remarks>
        [Name("Enable unknow age login deny", "SERVER_OPTION_AGE_RESTRICTIONS_REQUIRE_AGE_FOR_LOGIN_NAME")]
        [ExtendedDescription("Specifies if login should be denied for users with unknown age", "SERVER_OPTION_AGE_RESTRICTIONS_REQUIRE_AGE_FOR_LOGIN_DESCRIPTION")]
        [StoreOptionKey("REQUIRE_AGE_FOR_LOGIN")]
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool RequireAgeForLogin { get; init; }
    }
}
