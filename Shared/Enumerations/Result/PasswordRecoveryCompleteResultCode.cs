using Gizmo.Internal;

namespace Gizmo
{
    /// <summary>
    /// Password recovery completion result code.
    /// </summary>
    public enum PasswordRecoveryCompleteResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failure.
        /// </summary>
        Failure = BASE_CODES.FAILURE,
        /// <summary>
        /// Invalid token.
        /// </summary>
        InvalidToken = TOKEN_ERROR_CODES.INVALID_TOKEN,
        /// <summary>
        /// Invalid token input.
        /// </summary>
        InvalidTokenInput = TOKEN_ERROR_CODES.INVALID_TOKEN_INPUT,
        /// <summary>
        /// Expired token.
        /// </summary>
        ExpiredToken = TOKEN_ERROR_CODES.EXPIRED_TOKEN,
        /// <summary>
        /// Used token.
        /// </summary>
        UsedToken = TOKEN_ERROR_CODES.USED_TOKEN,
        /// <summary>
        /// Revoked token.
        /// </summary>
        RevokedToken = TOKEN_ERROR_CODES.REVOKED_TOKEN,
        /// <summary>
        /// Invalid token type.
        /// </summary>
        InvalidTokenType = TOKEN_ERROR_CODES.INVALID_TOKEN_TYPE,
    }
}
