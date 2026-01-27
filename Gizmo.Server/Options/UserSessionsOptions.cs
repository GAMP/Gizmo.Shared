using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("USERSESSIONS")]
    [StoreOptionsGroup("USER_SESSIONS")]
    [MessagePack.MessagePackObject()]
    public sealed class UserSessionsOptions : IStoreOptions
    {
        [Name("Terminate pending", "SERVER_OPTION_USER_SESSIONS_TERMINATE_PENDING_NAME")]
        [DefaultValue(false)]
        [StoreOptionKey("TERMINATE_PENDING")]
        [MessagePack.Key(0)]
        public bool TerminatePending
        {
            get;init;
        }

        [Name("Logout disconnected", "SERVER_OPTION_USER_SESSIONS_LOGOUT_DISCONNECTED_NAME")]
        [DefaultValue(false)]
        [StoreOptionKey("LOGOUT_DISCONNECTED")]
        [MessagePack.Key(1)]
        public bool LogoutDisconnected
        {
            get;init;
        }

        [Name("Pending session timeout", "SERVER_OPTION_USER_SESSIONS_PENDING_TIMEOUT_NAME")]
        [DefaultValue(180)]
        [StoreOptionKey("PENDING_TIMEOUT")]
        [MessagePack.Key(2)]
        public int PendingTimeout
        {
            get;init;
        }
    }
}
