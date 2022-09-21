namespace Gizmo
{
    /// <summary>
    /// Verification complete result.
    /// </summary>
    public enum VerificationCompleteResultCode
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
        /// Invalid verification.
        /// </summary>
        InvalidVerification = VERIFICATION_ERROR_CODES.INVALID_VERIFICATION,
        /// <summary>
        /// Used verification.
        /// </summary>
        AlreadyVerified = VERIFICATION_ERROR_CODES.USED_VERIFICATION,
        /// <summary>
        /// Partial success.
        /// </summary>
        PartialSuccess = EXTENDED_ERROR_CODES.PARTIAL_SUCCESS,
        /// <summary>
        /// Invalid confirmation code.
        /// </summary>
        InvalidConfirmationCode = CONFIRMATION_ERROR_CODES.INVALID_CONFIRMATION_CODE,
    }
}
