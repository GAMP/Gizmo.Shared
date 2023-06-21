#nullable enable

using System.ComponentModel;
using MessagePack;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Online deposit options.
    /// </summary>
    [MessagePackObject()]
    public sealed class UserOnlineDepositOptions
    {
        /// <summary>
        /// Defines if the online deposits should be disabled.
        /// </summary>
        /// <remarks>
        /// This will override default functionality where online depoists are available to the user if at leas one online payment method is configured.
        /// </remarks>
        [Key(0)]
        [DefaultValue(false)]
        public bool ShowUserOnlineDeposit { get; set; }

        /// <summary>
        /// Defines maximum amount for an online deposit.
        /// </summary>
        /// <remarks>
        /// This amount is used to limit the amount user deposits manually witout using any defined deposit presets.
        /// </remarks>
        [Key(1)]
        [DefaultValue(0)]
        public decimal MaximumAmount { get; set; }
    }
}
