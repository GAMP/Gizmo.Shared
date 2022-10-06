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
        [Localized("PASSWORD_RECOVERY_RESULT_CODE_SUCCESS")]
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failed.
        /// </summary>
        [Localized("PASSWORD_RECOVERY_RESULT_CODE_FAILURE")]
        Failed = BASE_CODES.FAILURE,
        /// <summary>
        /// No route.
        /// </summary>
        [Localized("PASSWORD_RECOVERY_RESULT_NO_ROUTE")]
        NoRouteForDelivery = DELIVERY_ERROR_CODES.NO_ROUTE,
        /// <summary>
        /// Delivery failed.
        /// </summary>
        [Localized("PASSWORD_RECOVERY_RESULT_CODE_DELIVERY_FAILED")]
        DeliveryFailed = DELIVERY_ERROR_CODES.DELIVERY_FAILED,
        /// <summary>
        /// Invalid input.
        /// </summary>
        [Localized("PASSWORD_RECOVERY_RESULT_CODE_INVALID_INPUT")]
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,
        /// <summary>
        /// User not found.
        /// </summary>
        [Localized("PASSWORD_RECOVERY_RESULT_CODE_USER_NOT_FOUND")]
        UserNotFound = EXTENDED_ERROR_CODES.USER_NOT_FOUND,
    }
}
