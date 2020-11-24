using System;

namespace Gizmo
{
    /// <summary>
    /// Stock options.
    /// </summary>
    [Flags]
    public enum StockOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable stock.
        /// </summary>
        EnableStock = 1,
        /// <summary>
        /// Disallow out of stock sale.
        /// </summary>
        DisallowSaleIfOutOfStock = 2,
        /// <summary>
        /// Alert out of stock.
        /// </summary>
        Alert = 4,
        /// <summary>
        /// Target different product.
        /// </summary>
        TargetDifferentProduct = 8,
    }
}
