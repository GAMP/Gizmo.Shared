namespace Gizmo
{
    /// <summary>
    /// Print status.
    /// </summary>
    /// <remarks>
    /// This enum will be used to indicate receipt print status.
    /// </remarks>
    public enum FiscalReceiptPrintStatus
    {
        /// <summary>
        /// No receipt required.
        /// </summary>
        None = 0,

        /// <summary>
        /// Receipt print was required but overridden by operator or non fiscal payment method.
        /// </summary>
        Override = 1,

        /// <summary>
        /// Receipt printing is pending.
        /// </summary>
        Pending = 2,

        /// <summary>
        /// Receipt was printed.
        /// </summary>
        Printed = 3,

        /// <summary>
        /// Not all required receipts printed or print failed.
        /// </summary>
        Failed = 4,

        /// <summary>
        /// Receipt printing is pending but only electronically. 
        /// </summary>
        /// <remarks>
        /// This value is set when we required receipt fiscalization but only electronically.
        /// </remarks>
        EReceiptPending = 5,
    }
}
