using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("WAITINGLINES")]
    [StoreOptionsGroup("WAITING_LINES")]
    [MessagePack.MessagePackObject()]
    public sealed class WaitingLinesOptions : IStoreOptions
    {
        [Name("Enable logout grace period", "SERVER_OPTION_WAITING_LINES_LOGOUT_GRACE_PERIOD_ENABLED_NAME")]
        [ExtendedDescription("Specifies if logout grace period is enabled", "SERVER_OPTION_WAITING_LINES_LOGOUT_GRACE_PERIOD_ENABLED_DESCRIPTION")]
        [StoreOptionKey("LOGOUT_GRACE_PERIOD_ENABLED")]    
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool IsLogoutGracePeriodEnabled { get; init; }

        [Name("Grace period time", "SERVER_OPTION_WAITING_LINES_LOGOUT_GRACE_PERIOD_TIME_NAME")]
        [ExtendedDescription("Specifies logout grace period time", "SERVER_OPTION_WAITING_LINES_LOGOUT_GRACE_PERIOD_TIME_DESCRIPTION")]
        [StoreOptionKey("LOGOUT_GRACE_PERIOD_TIME")]     
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [MessagePack.Key(1)]
        public int LogoutGracePeriodTime { get;init; }

        [Name("Enable remove from all waiting lines on login", "SERVER_OPTION_WAITING_LINES_LOGIN_REMOVE_FROM_ALL_NAME")]
        [ExtendedDescription("Specifies user should be removed from all waiting lines on login", "SERVER_OPTION_WAITING_LINES_LOGIN_REMOVE_FROM_ALL_DESCRIPTION")]
        [StoreOptionKey("LOGIN_REMOVE_FROM_ALL")]
        [DefaultValue(true)]
        [MessagePack.Key(2)]
        public bool IsRemoveFromAllEnabled { get; init; }

        [Name("Next in line time", "SERVER_OPTION_WAITING_LINES_NEXT_IN_LINE_TIME_NAME")]
        [ExtendedDescription("Specifies next in line time", "SERVER_OPTION_WAITING_LINES_NEXT_IN_LINE_TIME_DESCRIPTION")]
        [StoreOptionKey("NEXT_IN_LINE_TIME")]
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [MessagePack.Key(3)]
        public int NextInLineTime { get;init; }

        [Name("Remove time", "SERVER_OPTION_WAITING_LINES_REMOVE_TIME_NAME")]
        [ExtendedDescription("Specifies remove time", "SERVER_OPTION_WAITING_LINES_REMOVE_TIME_DESCRIPTION")]
        [StoreOptionKey("REMOVE_TIME")]        
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [MessagePack.Key(4)]
        public int RemoveTime { get;init; }
    }
}
