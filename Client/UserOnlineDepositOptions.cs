#nullable enable

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Online deposit options.
    /// </summary>
    public sealed class UserOnlineDepositOptions
    {
        public bool ShowUserOnlineDeposit { get; set; }
        public decimal MaximumAmount { get; set; }
    }
}