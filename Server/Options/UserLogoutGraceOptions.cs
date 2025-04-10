using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERLOGOUTGRACE")]
    [StoreOptionsGroup("USER_LOGOUT_GRACE")]
    [MessagePack.MessagePackObject()]
    public sealed class UserLogoutGraceOptions : IStoreOptions
    {
        [Name("Logout enabled")]
        [ExtendedDescription("Specifies if age is mandatory for all age restrictions")]
        [StoreOptionKey("ENABLED")]
        [MessagePack.Key(0)]
        public bool IsEnabled { get; init; }

        [Name("Logout time")]
        [ExtendedDescription("Specifies logout grace period time")]
        [StoreOptionKey("TIME")]
        [MessagePack.Key(1)]
        public int Time { get; init; }
    }
}
