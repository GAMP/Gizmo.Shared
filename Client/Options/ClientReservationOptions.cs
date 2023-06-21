#nullable enable

using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Reservation options.
    /// </summary>
    [MessagePackObject()]
    public sealed class ClientReservationOptions
    {
        /// <summary>
        /// Gets or sets enable login block.
        /// </summary>
        [Key(0)]
        public bool EnableLoginBlock { get; set; }

        /// <summary>
        /// Gets or sets login block time.
        /// </summary>
        [Key(1)]
        public int LoginBlockTime { get; set; }

        /// <summary>
        /// Gets or sets enable login unblock.
        /// </summary>
        [Key(2)]
        public bool EnableLoginUnblock { get; set; }

        /// <summary>
        /// Gets or sets login unblock time.
        /// </summary>
        [Key(3)]
        public int LoginUnblockTime { get; set; }
    }
}
