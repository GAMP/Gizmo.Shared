using System;

namespace Gizmo
{
    /// <summary>
    /// Credit limit options.
    /// </summary>
    [Flags()]
    public enum CreditLimitOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable per user credit limit.
        /// </summary>
        EnablePerUserCreditLimit = 2,
        /// <summary>
        /// Enables sales credit limit.
        /// </summary>
        SalesCreditLimited = 4,
        /// <summary>
        /// Enables unlimited sales credit limit.
        /// </summary>
        SalesCreditUnlimited = 8,
        /// <summary>
        /// Enables time credit limit.
        /// </summary>
        TimeCreditLimited = 16,
        /// <summary>
        /// Enables unlimitied time credit limit.
        /// </summary>
        TimeCreditUnlimited = 32,
    }
}
