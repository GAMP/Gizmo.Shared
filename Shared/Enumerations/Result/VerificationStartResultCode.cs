using Gizmo.Internal;

namespace Gizmo
{
    /// <summary>
    /// Verification start result code.
    /// </summary>
    public enum VerificationStartResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = BASE_CODES.FAILURE,
        /// <summary>
        /// No route.
        /// </summary>
        NoRouteForDelivery = DELIVERY_ERROR_CODES.NO_ROUTE,
        /// <summary>
        /// Delivery failed.
        /// </summary>
        DeliveryFailed = DELIVERY_ERROR_CODES.DELIVERY_FAILED,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        InvalidUserId = EXTENDED_ERROR_CODES.INVALID_USER_ID,
        /// <summary>
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,
        /// <summary>
        /// Non unique input.
        /// </summary>
        NonUniqueInput = EXTENDED_ERROR_CODES.NON_UNIQUE_INPUT,
    }
}
