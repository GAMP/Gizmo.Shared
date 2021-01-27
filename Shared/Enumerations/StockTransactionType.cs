namespace Gizmo
{
    /// <summary>
    /// Stock transaction type.
    /// </summary>
    public enum StockTransactionType
    {
        /// <summary>
        /// Add.
        /// </summary>
        [Localized("STOCK_TRANSACTION_ADD")]
        Add = 0,

        /// <summary>
        /// Remove.
        /// </summary>
        [Localized("STOCK_TRANSACTION_REMOVE")]
        Remove = 1,

        /// <summary>
        /// Sale.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SALE")]
        Sale = 2,

        /// <summary>
        /// Set.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SET")]
        Set = 3,

        /// <summary>
        /// Return.
        /// </summary>
        [Localized("STOCK_TRANSACTION_RETURN")]
        Return = 4,
    }
}