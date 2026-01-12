#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gizmo.Client.Options;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Reservation options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class ClientReservationOptions
    {
        /// <summary>
        /// Gets or sets enable login block.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool EnableLoginBlockBefore { get; set; }

        /// <summary>
        /// Gets or sets login block time.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        public int LoginBlockBeforeTime { get; set; }

        /// <summary>
        /// Gets or sets enable login block after.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool EnableLoginBlockAfter { get; set; }

        /// <summary>
        /// Gets or sets login block after time.
        /// </summary>
        [MessagePack.Key(3)]    
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        public int LoginUnblockAfterTime { get; set; }

        /// <summary>
        /// Reservation alert time.
        /// </summary>
        [MessagePack.Key(4)]
        public int? AlertBeforeTime { get; set; }

        /// <summary>
        /// Reservation notifications.
        /// </summary>
        [MessagePack.Key(5)]
        public IEnumerable<NotificationOption> Notifications { get; set; } = Enumerable.Empty<NotificationOption>();
    }
}
