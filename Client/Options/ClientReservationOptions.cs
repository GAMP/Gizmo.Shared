#nullable enable

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Reservation options.
    /// </summary>
    public sealed class ClientReservationOptions
    {
        /// <summary>
        /// Gets or sets enable login block.
        /// </summary>
        public bool EnableLoginBlock { get; set; }

        /// <summary>
        /// Gets or sets login block time.
        /// </summary>
        public int LoginBlockTime { get; set; }

        /// <summary>
        /// Gets or sets enable login unblock.
        /// </summary>
        public bool EnableLoginUnblock { get; set; }

        /// <summary>
        /// Gets or sets login unblock time.
        /// </summary>
        public int LoginUnblockTime { get; set; }
    }
}
