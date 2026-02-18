
using System.Collections.Generic;
using System.Linq;

namespace Gizmo.Client.Options
{
    /// <summary>
    /// Reservation options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientReservationOptions
    {
        /// <summary>
        /// Reservation alert time.
        /// </summary>
        [MessagePack.Key(0)]
        public int? AlertBeforeTime { get; set; }

        /// <summary>
        /// Login block after time.
        /// </summary>
        [MessagePack.Key(1)]
        public int? LoginBlockAfterTime { get; set; }

        /// <summary>
        /// Reservation notifications.
        /// </summary>
        [MessagePack.Key(2)]
        public IEnumerable<NotificationOption> Notifications { get; set; } = Enumerable.Empty<NotificationOption>();
    }
}
