#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public bool EnableLoginBlock { get; set; }

        /// <summary>
        /// Gets or sets login block time.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        public int LoginBlockTime { get; set; }

        /// <summary>
        /// Gets or sets enable login unblock.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(false)]
        public bool EnableLoginUnblock { get; set; }

        /// <summary>
        /// Gets or sets login unblock time.
        /// </summary>
        [MessagePack.Key(3)]    
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        public int LoginUnblockTime { get; set; }
    }
}
