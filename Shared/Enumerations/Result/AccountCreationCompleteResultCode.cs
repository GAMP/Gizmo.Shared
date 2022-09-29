using Gizmo.Internal;

namespace Gizmo
{
    /// <summary>
    /// Account create completion result.
    /// </summary>
    public enum AccountCreationCompleteResultCode
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
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,

        /// <summary>
        /// No user group.
        /// </summary>
        NoUserGroup = EXTENDED_ERROR_CODES.INVALID_USER_GROUP,

        /// <summary>
        /// None unique input.
        /// </summary>
        NonUniqueInput = EXTENDED_ERROR_CODES.NON_UNIQUE_INPUT,
    }
}
