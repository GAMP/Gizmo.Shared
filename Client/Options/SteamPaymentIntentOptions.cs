using System.ComponentModel;

namespace Gizmo.Shared.Client.Options
{
    /// <summary>
    /// Steam payment intent options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class SteamPaymentIntentOptions
    {
        /// <summary>
        /// Defines if the online deposits should be disabled.
        /// </summary>
        /// <remarks>
        /// This will override default functionality where online depoists are available to the user if at leas one online payment method is configured.
        /// </remarks>
        [MessagePack.Key(0)]
        [DefaultValue(false)]
        public bool Disabled { get; set; }
        
        /// <summary>
        /// Minimum amount
        /// </summary>
        [MessagePack.Key(1)]
        public decimal MinimumAmount { get; set; }
        
        /// <summary>
        /// Maximum amount
        /// </summary>
        [MessagePack.Key(2)]
        public decimal MaximumAmount { get; set; }
    }
}
