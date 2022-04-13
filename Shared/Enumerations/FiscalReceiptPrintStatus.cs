namespace Gizmo
{
    /// <summary>
    /// Print status.
    /// </summary>
    /// <remarks>
    /// This flag will be used to indicate receipt print status.
    /// </remarks>
    public enum FiscalReceiptPrintStatus
    {
        /// <summary>
        /// No receipt required.
        /// </summary>
        [Localized("FISCAL_RECEIPT_PRINT_STATUS_NONE")]
        None = 0,
        /// <summary>
        /// Receipt print was required but overriden by operator or non fiscal payment method.
        /// </summary>
        [Localized("FISCAL_RECEIPT_PRINT_STATUS_OVERRIDE")]
        Override = 1,
        /// <summary>
        /// Receipt printing is pending.
        /// </summary>
        [Localized("FISCAL_RECEIPT_PRINT_STATUS_PENDING")]
        Pending = 2,
        /// <summary>
        /// Receipt was printed.
        /// </summary>
        [Localized("FISCAL_RECEIPT_PRINT_STATUS_PRINTED")]
        Printed = 3,
        /// <summary>
        /// Not all required receipts printed or print failed.
        /// </summary>
        [Localized("FISCAL_RECEIPT_PRINT_STATUS_FAILED")]
        Failed = 4,
    }
}
