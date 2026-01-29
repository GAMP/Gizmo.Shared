
namespace Gizmo.Client.Options
{
    [MessagePack.MessagePackObject()]
    public sealed class NotificationOption
    {
        /// <summary>
        /// Notification type.
        /// </summary>
        [MessagePack.Key(0)]
        public int Type { get; set; }

        /// <summary>
        /// Focus type.
        /// </summary>
        [MessagePack.Key(1)]
        public int FocusType { get; set; }

        /// <summary>
        /// Notification minute.
        /// </summary>
        [MessagePack.Key(2)]
        public int Minute { get; set; }

        /// <summary>
        /// Optional notification message.
        /// </summary>
        [MessagePack.Key(3)]
        public string? Message { get; set; }
    }
}
