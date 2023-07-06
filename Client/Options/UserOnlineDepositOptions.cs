#nullable enable

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Online deposit options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class UserOnlineDepositOptions
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
        /// Defines maximum amount for an online deposit.
        /// </summary>
        /// <remarks>
        /// This amount is used to limit the amount user deposits manually witout using any defined deposit presets.
        /// </remarks>
        [MessagePack.Key(1)]
        [DefaultValue(typeof(decimal), "100000")]
        [Range(typeof(decimal), "1", "100000")]
        public decimal MaximumAmount { get; set; }
    }
}
