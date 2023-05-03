namespace Gizmo
{
    /// <summary>
    /// User product availability check result.
    /// </summary>
    public enum UserProductAvailabilityCheckResult
    {
        /// <summary>
        /// Success.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_SUCCESS")]
        Success = 0,
        /// <summary>
        /// Invalid user id passed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_INVALID_USER_ID")]
        InvalidUserId = 1,
        /// <summary>
        /// Invalid product id passed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_INVALID_PRODUCT_ID")]
        InvalidProdcutId = 2,
        /// <summary>
        /// User group disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_DISALLOWED_USER_GROUP")]
        UserGroupDisallowed = 3,
        /// <summary>
        /// Sale disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_SALE_DISALLOWED")]
        SaleDisallowed = 4,
        /// <summary>
        /// Client ordering disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_CLIENT_ORDER_DISALLOWED")]
        ClientOrderDisallowed = 5,
        /// <summary>
        /// Geuest order disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_GUEST_SALE_DISALLOWED")]
        GuestSaleDisallowed = 6,
        /// <summary>
        /// Product id out of stock.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_OUT_OF_STOCK")]
        OutOfStock = 7,
        /// <summary>
        /// Purchase period disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_PURCHASE_PERIOD_DISALLOWED")]
        PeriodDisallowed = 8,
    }
}
