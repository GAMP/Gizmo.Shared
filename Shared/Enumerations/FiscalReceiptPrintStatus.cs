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
        None=0,
        /// <summary>
        /// Receipt print was required but overriden by operator or non fiscal payment method.
        /// </summary>
        Override=1,
        /// <summary>
        /// Receipt printing is pending.
        /// </summary>
        Pending=2,
        /// <summary>
        /// Receipt was printed.
        /// </summary>
        Printed=3,
        /// <summary>
        /// Not all required receipts printed or print failed.
        /// </summary>
        Failed=4,
    }
}
