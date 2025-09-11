using System.ComponentModel.DataAnnotations;

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
        [Name("Add", "STOCK_TRANSACTION_TYPE_ADD")]
        Add = 0,

        /// <summary>
        /// Remove.
        /// </summary>
        [Localized("STOCK_TRANSACTION_REMOVE")]
        [Name("Remove", "STOCK_TRANSACTION_TYPE_REMOVE")]
        Remove = 1,

        /// <summary>
        /// Sale.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SALE")]
        [Name("Sale", "STOCK_TRANSACTION_TYPE_SALE")]
        Sale = 2,

        /// <summary>
        /// Set.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SET")]
        [Name("Set", "STOCK_TRANSACTION_TYPE_SET")]
        Set = 3,

        /// <summary>
        /// Return.
        /// </summary>
        [Localized("STOCK_TRANSACTION_RETURN")]
        [Name("Return", "STOCK_TRANSACTION_TYPE_RETURN")]
        Return = 4,
    }
}
