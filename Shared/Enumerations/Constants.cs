namespace Gizmo.Internal
{
    /// <summary>
    /// Base codes.
    /// </summary>
    internal class BASE_CODES
    {
        /// <summary>
        /// Success.
        /// </summary>
        public const int SUCCESS = 0;

        /// <summary>
        /// Failure.
        /// </summary>
        public const int FAILURE = 1;
    }

    /// <summary>
    /// Token error codes.
    /// </summary>
    internal class TOKEN_ERROR_CODES
    {
        /// <summary>
        /// Invalid token.
        /// </summary>
        public const int INVALID_TOKEN = 101;
        /// <summary>
        /// Expired token.
        /// </summary>
        public const int EXPIRED_TOKEN = 102;
        /// <summary>
        /// Revoked token.
        /// </summary>
        public const int REVOKED_TOKEN = 103;
        /// <summary>
        /// Used token.
        /// </summary>
        public const int USED_TOKEN = 104;
        /// <summary>
        /// Invalid token input.
        /// </summary>
        public const int INVALID_TOKEN_INPUT = 105;
    }

    /// <summary>
    /// Verification error codes.
    /// </summary>
    internal class VERIFICATION_ERROR_CODES
    {
        /// <summary>
        /// Invalid verification.
        /// </summary>
        public const int INVALID_VERIFICATION = 201;
        /// <summary>
        /// Used verification.
        /// </summary>
        public const int USED_VERIFICATION = 202;
    }

    /// <summary>
    /// Confirmation error codes.
    /// </summary>
    internal class CONFIRMATION_ERROR_CODES
    {
        /// <summary>
        /// Invalid confirmation.
        /// </summary>
        public const int INVALID_CONFIRMATION_CODE = 301;
    }

    /// <summary>
    /// Extended error codes.
    /// </summary>
    internal class EXTENDED_ERROR_CODES
    {
        /// <summary>
        /// Partial success.
        /// </summary>
        public const int PARTIAL_SUCCESS = 401;
        /// <summary>
        /// Invalid input.
        /// </summary>
        public const int INVALID_INPUT = 402;
        /// <summary>
        /// Invalid user id.
        /// </summary>
        public const int INVALID_USER_ID = 403;
        /// <summary>
        /// Invalid user group.
        /// </summary>
        public const int INVALID_USER_GROUP = 404;
        /// <summary>
        /// Non unique input.
        /// </summary>
        public const int NON_UNIQUE_INPUT = 405;
    }

    /// <summary>
    /// Delivery error codes.
    /// </summary>
    internal class DELIVERY_ERROR_CODES
    {
        /// <summary>
        /// Failed.
        /// </summary>
        public const int DELIVERY_FAILED = 501;
        /// <summary>
        /// No route.
        /// </summary>
        public const int NO_ROUTE = 502;
    }
}
