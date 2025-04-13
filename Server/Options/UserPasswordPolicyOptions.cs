using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERPASSWORDPOLICY")]
    [StoreOptionsGroup("USER_PASSWORD_POLICY")]
    [MessagePack.MessagePackObject()]
    public sealed class UserPasswordPolicyOptions : IStoreOptions
    {
        [Name("Minimum length")]
        [ExtendedDescription("Specifies user password minimum length")]
        [StoreOptionKey("MINIMUM_LENGTH")]
        [MessagePack.Key(0)]
        [DefaultValue(4)]
        public int MinimumLength { get; init; }

        [Name("Maximum length")]
        [ExtendedDescription("Specifies user password minimum length")]
        [StoreOptionKey("MAXIMUM_LENGTH")]
        [MessagePack.Key(1)]
        [DefaultValue(24)]
        public int MaximumLength { get; init; }

        [Name("Require lowercase")]
        [ExtendedDescription("Specifies if lower case characters are required")]
        [StoreOptionKey("REQUIRE_LOWERCASE")]
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool RequireLowerCase { get; init; }

        [Name("Require uppercase")]
        [ExtendedDescription("Specifies if upper case characters are required")]
        [StoreOptionKey("REQUIRE_UPERCASE")]
        [MessagePack.Key(3)]
        [DefaultValue(false)]
        public bool RequireUpperCase { get; init; }

        [Name("Require numbers")]
        [ExtendedDescription("Specifies if numbers are required")]
        [StoreOptionKey("REQUIRE_NUMBERS")]
        [DefaultValue(false)]
        [MessagePack.Key(4)]
        public bool RequireNumbers { get; init; }
    }
}
