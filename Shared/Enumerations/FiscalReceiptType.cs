namespace Gizmo
{
    /// <summary>
    /// Fiscal receipt type.
    /// </summary>
    /// <remarks>
    /// Represents the type of fiscal receipt printed.
    /// </remarks>
    public enum FiscalReceiptType
    {
        /// <summary>
        /// Invoice sale.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_SALE")]
        Sale = 0,
        /// <summary>
        /// Invoice void.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_VOID_SALE")]
        VoidSale = 1,
        /// <summary>
        /// Deposit sale.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_DEPOSIT")]
        Deposit = 2,
        /// <summary>
        /// Deposit void.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_VOID_DEPOSIT")]
        VoidDeposit = 3,
        /// <summary>
        /// Deposit withdraw.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_WITHDRAW_DEPOIST")]
        WithdrawDeposit = 4,
        /// <summary>
        /// Pay in transaction.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_PAY_IN")]
        PayIn = 5,
        /// <summary>
        /// Pay out transaction.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_PAY_OUT")]
        PayOut = 6,
        /// <summary>
        /// Shift open.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_SHIFT_OPEN")]
        ShiftOpen = 7,
        /// <summary>
        /// Shift close.
        /// </summary>
        [Localized("FISCAL_RECEIPT_TYPE_SHIFT_CLOSE")]
        ShiftClose = 6,
    }
}
