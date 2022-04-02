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
        /// Receipt printing is pending.
        /// </summary>
        Pending=1,
        /// <summary>
        /// Receipt was printed.
        /// </summary>
        Printed=2,
        /// <summary>
        /// Not all required receipts printed.
        /// </summary>
        PartialyPrinted=3,
    }
}
