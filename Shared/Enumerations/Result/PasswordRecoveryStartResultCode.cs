using Gizmo.Internal;

namespace Gizmo
{
    /// <summary>
    /// Password recovery start result code.
    /// </summary>
    public enum PasswordRecoveryStartResultCode
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
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,
        /// <summary>
        /// User not found.
        /// </summary>
        UserNotFound = EXTENDED_ERROR_CODES.USER_NOT_FOUND,
    }
}
