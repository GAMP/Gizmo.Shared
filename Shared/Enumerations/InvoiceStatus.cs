namespace Gizmo
{
    /// <summary>
    /// Invoice status.
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// Unpaid.
        /// </summary>
        [Localized("INVOICE_STATUS_UNPAID")]
        Unpaid = 0,
        /// <summary>
        /// Partially paid.
        /// </summary>
        [Localized("INVOICE_STATUS_PARTIALLY_PAID")]
        PartialyPaid = 1,
        /// <summary>
        /// Paid.
        /// </summary>
        [Localized("INVOICE_STATUS_PAID")]
        Paid = 2,
    }
}
