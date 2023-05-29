using System;

namespace Gizmo
{
    /// <summary>
    /// Order options.
    /// </summary>
    [Flags()]
    public enum OrderOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Client order disallowed.
        /// </summary>
        DisallowAllowOrder = 1,
        /// <summary>
        /// Disallow ability of order for non users.
        /// </summary>
        RestrictNonCustomers = 2,
        /// <summary>
        /// Restricts product sale.
        /// </summary>
        RestrictSale = 4,
        /// <summary>
        /// If the product is service.
        /// </summary>
        IsService = 8
    }
}
