namespace Gizmo
{
    /// <summary>
    /// User order create result.
    /// </summary>
    public enum UserOrderCreateResult
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Insufficient balance.
        /// </summary>
        InsufficientBalance = 1,
        /// <summary>
        /// Invalid payment method.
        /// </summary>
        InvalidPaymentMethod = 2,
        /// <summary>
        /// Invalid order.
        /// </summary>
        InvalidOrder = 3,
        /// <summary>
        /// Ordering is disabled.
        /// </summary>
        OrderingDisabled = 4,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        InvalidUserId = 5,
    }
}
