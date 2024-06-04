namespace Gizmo
{
    /// <summary>
    /// Order status.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// On hold.
        /// </summary>
        [Localized("ORDER_STATUS_ON_HOLD")]
        OnHold = 0,

        /// <summary>
        /// Completed.
        /// </summary>
        [Localized("ORDER_STATUS_COMPLETED")]
        Completed = 1,

        /// <summary>
        /// Canceled.
        /// </summary>
        [Localized("ORDER_STATUS_CANCELED")]
        Canceled = 2,

        /// <summary>
        /// Accepted.
        /// </summary>
        [Localized("ORDER_STATUS_ACCEPTED")]
        Accepted = 3,

        /// <summary>
        /// Processing.
        /// </summary>
        [Localized("ORDER_STATUS_PROCESSING")]
        Processing = 4,
    }
}
