
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("CLIENTNOTIFICATIONS")]
    [StoreOptionsGroup("CLIENT_NOTIFICATIONS")]
    [MessagePack.MessagePackObject()]
    public sealed class ClientNotificationOptions : IStoreOptions
    {
        [Name("Remaining time notification message", "SERVER_OPTION_CLIENT_NOTIFICATION_OPTIONS_NAME")]
        [ExtendedDescription("Specifies remaining time notification message", "SERVER_OPTION_CLIENT_NOTIFICATION_OPTIONS_DESCRIPTION")]
        [StoreOptionKey("REMAINING_TIME_NOTIFICATION_MESSAGE")]
        [MessagePack.Key(0)]
        public string? RemainingTimeNotificationMessage { get; init; }

        [Name("Reservation time notification message", "SERVER_OPTION_RESERVATION_NOTIFICATION_OPTIONS_NAME")]
        [ExtendedDescription("Specifies reservation time notification message", "SERVER_OPTION_RESERVATION_NOTIFICATION_OPTIONS_DESCRIPTION")]
        [StoreOptionKey("RESERVATION_TIME_NOTIFICATION_MESSAGE")]
        [MessagePack.Key(1)]
        public string? ReservationTimeNotificationMessage { get; init; }
    }
}
