namespace Gizmo
{
    /// <summary>
    /// User recovery method result codes.
    /// </summary>
    public enum UserRecoverMethodGetResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        [Localized("USER_RECOVERY_METHOD_GET_RESULT_SUCCESS")]
        Success = 0,
        /// <summary>
        /// Internal error.
        /// </summary>
        [Localized("USER_RECOVERY_METHOD_GET_RESULT_ERROR")]
        Error = 1,
        /// <summary>
        /// User not found.
        /// </summary>
        [Localized("USER_RECOVERY_METHOD_GET_RESULT_USER_NOT_FOUND")]
        UserNotFound = 2,
    }
}
