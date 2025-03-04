using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERLOGIN")]
    [StoreOptionsGroup("USER_LOGIN")]
    [MessagePack.MessagePackObject()]
    public sealed class UserLoginOptions : IStoreOptions
    {
        [Name("User automatic re-login", "SERVER_OPTION_USER_LOGIN_USER_RE_LOGIN_NAME")]
        [StoreOptionKey("USER_RE_LOGIN")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool UserReLogin { get; init; }

        [Name("Guest automatic re-login", "SERVER_OPTION_USER_LOGIN_GUEST_RE_LOGIN_NAME")]
        [StoreOptionKey("GUEST_RE_LOGIN")]
        [DefaultValue(false)]
        [MessagePack.Key(1)]
        public bool GuestReLogin { get; init; }
    }
}
