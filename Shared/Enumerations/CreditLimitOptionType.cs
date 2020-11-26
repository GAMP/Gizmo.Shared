using System;

namespace Gizmo
{
    /// <summary>
    /// Credit limit options.
    /// </summary>
    [Flags]
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
    }
}
