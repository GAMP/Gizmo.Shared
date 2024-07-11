using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// User login result.
    /// </summary>
    [Flags()]
    public enum LoginResult
    {
        /// <summary>
        /// Login was sucessfull.
        /// </summary>
        [Localized("LOGIN_RESULT_SUCESS")]
        Sucess = 0,
        /// <summary>
        /// Invalid parameters specified.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_PARAMETERS")]
        [Name("Invalid parameters", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_PARAMETERS_NAME")]
        [ExtendedDescription("The specified parameters are invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_PARAMETERS_DESCRIPTION")]
        InvalidParameters = 1,
        /// <summary>
        /// Account is disabled.
        /// </summary>
        [Localized("LOGIN_RESULT_ACCOUNT_DISABLED")]
        [Name("Account disabled", "EXCEPTION_ERROR_LOGIN_RESULT_ACCOUNT_DISABLED_NAME")]
        [ExtendedDescription("The specified user account is disabled", "EXCEPTION_ERROR_LOGIN_RESULT_ACCOUNT_DISABLED_DESCRIPTION")]
        AccountDisabled = 2,
        /// <summary>
        /// Username is invalid.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_USERNAME")]
        [Name("Invalid username", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USERNAME_NAME")]
        [ExtendedDescription("The specified username is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USERNAME_DESCRIPTION")]
        InvalidUserName = 4,
        /// <summary>
        /// Password is invalid.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_PASSWORD")]
        [Name("Invalid password", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_PASSWORD_NAME")]
        [ExtendedDescription("The specified password is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_PASSWORD_DESCRIPTION")]
        InvalidPassword = 8,
        /// <summary>
        /// Generic internal error.
        /// </summary>
        [Localized("LOGIN_RESULT_FAILED")]
        [Name("Login failed", "EXCEPTION_ERROR_LOGIN_RESULT_FAILED_NAME")]
        [ExtendedDescription("Unspecified login error", "EXCEPTION_ERROR_LOGIN_RESULT_FAILED_DESCRIPTION")]
        Failed = 16,
        /// <summary>
        /// Login was denied.
        /// </summary>
        [Localized("LOGIN_RESULT_DENIED")]
        [Name("Login denied", "EXCEPTION_ERROR_LOGIN_RESULT_DENIED_NAME")]
        [ExtendedDescription("Login was denied", "EXCEPTION_ERROR_LOGIN_RESULT_DENIED_DESCRIPTION")]
        Denied = 32,
        /// <summary>
        /// Function timed out.
        /// </summary>
        [Obsolete()]
        [Localized("LOGIN_RESULT_TIMED_OUT")]
        TimedOut = 64,
        /// <summary>
        /// Login function cannot be executed.
        /// </summary>
        [Obsolete()]
        [Localized("LOGIN_RESULT_CANT_EXECUTE")]
        CantExecute = 128,
        /// <summary>
        /// User already logged in.
        /// </summary>
        [Localized("LOGIN_RESULT_ALREADY_LOGGED_IN")]
        [Name("Already logged in", "EXCEPTION_ERROR_LOGIN_RESULT_ALREADY_LOGGED_IN_NAME")]
        [ExtendedDescription("User is already logged in", "EXCEPTION_ERROR_LOGIN_RESULT_ALREADY_LOGGED_IN_DESCRIPTION")]
        AlreadyLoggedIn = 256,
        /// <summary>
        /// Login in progress.
        /// </summary>
        [Localized("LOGIN_RESULT_IN_PROGRESS")]
        [Name("In progress", "EXCEPTION_ERROR_LOGIN_RESULT_LOGIN_IN_PROGRESS_NAME")]
        [ExtendedDescription("Login in progress", "EXCEPTION_ERROR_LOGIN_RESULT_LOGIN_IN_PROGRESS_DESCRIPTION")]
        LoginInProgress = 512,
        /// <summary>
        /// Logout in progress.
        /// </summary>
        [Localized("LOGIN_RESULT_IN_PROGRESS")]
        [Name("In progress", "EXCEPTION_ERROR_LOGIN_RESULT_LOGOUT_IN_PROGRESS_NAME")]
        [ExtendedDescription("Logout in progress", "EXCEPTION_ERROR_LOGIN_RESULT_LOGOUT_IN_PROGRESS_DESCRIPTION")]
        LogoutInProgress = 1024,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_USER")]
        [Name("Invalid user", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USER_ID_NAME")]
        [ExtendedDescription("The specified user is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USER_ID_DESCRIPTION")]
        InvalidUserId = 2048,
        /// <summary>
        /// Invalid host id.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_HOST")]
        [Name("Invalid host", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_HOST_ID_NAME")]
        [ExtendedDescription("The specified host is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_HOST_ID_DESCRIPTION")]
        InvalidHostId = 4096,
        /// <summary>
        /// Maximum sessions reached.
        /// </summary>
        [Localized("LOGIN_RESULT_MAX_SESSIONS_REACHED")]
        [Name("Maximum sessions reached", "EXCEPTION_ERROR_LOGIN_RESULT_MAXIMUM_SESSIONS_REACHED_NAME")]
        [ExtendedDescription("Login failed because maximum sessions reached", "EXCEPTION_ERROR_LOGIN_RESULT_MAXIMUM_SESSIONS_REACHED_DESCRIPTION")]
        MaximumSessionsReached = 8192,
        /// <summary>
        /// Insufficient balance.
        /// </summary>
        [Localized("LOGIN_RESULT_INSUFFICIENT_BALANCE")]
        [Name("Insufficient balance", "EXCEPTION_ERROR_LOGIN_RESULT_INSUFFICIENT_BALANCE_NAME")]
        [ExtendedDescription("The specified user has insufficient balance", "EXCEPTION_ERROR_LOGIN_RESULT_INSUFFICIENT_BALANCE_DESCRIPTION")]
        InsufficientBalance = 16384,
        /// <summary>
        /// Invalid user group was specified for login.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_USER_GROUP")]
        [Name("Invalid user group", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USER_GROUP_ID_NAME")]
        [ExtendedDescription("The specified user group is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_USER_GROUP_ID_DESCRIPTION")]
        InvalidUserGroupId = 32768,
        /// <summary>
        /// Slot in use.
        /// </summary>
        [Localized("LOGIN_RESULT_SLOT_IN_USE")]
        [Name("Slot is already in use", "EXCEPTION_ERROR_LOGIN_RESULT_SLOT_IN_USE_NAME")]
        [ExtendedDescription("The specified slot is already in use", "EXCEPTION_ERROR_LOGIN_RESULT_SLOT_IN_USE_DESCRIPTION")]
        SlotInUse = 65536,
        /// <summary>
        /// Slot invalid.
        /// </summary>
        [Localized("LOGIN_RESULT_SLOT_INVALID")]
        [Name("Invalid slot", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_SLOT_NAME")]
        [ExtendedDescription("The specified slot is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_SLOT_DESCRIPTION")]
        SlotInvalid = 131072,
        /// <summary>
        /// Not in waiting line.
        /// </summary>
        [Localized("LOGIN_RESULT_NOT_IN_WAITING_LINE")]
        [Name("Not in waiting line", "EXCEPTION_ERROR_LOGIN_RESULT_NOT_IN_WAITING_LINE_NAME")]
        [ExtendedDescription("The specified user is not in waiting line", "EXCEPTION_ERROR_LOGIN_RESULT_NOT_IN_WAITING_LINE_DESCRIPTION")]
        NotInWaitingLine = 262144,
        /// <summary>
        /// Credentials pair is invalid.
        /// </summary>
        [Localized("LOGIN_RESULT_INVALID_CREDENTIALS")]
        [Name("Invalid username or password", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_CREDENTIALS_NAME")]
        [ExtendedDescription("The specified username or password is invalid", "EXCEPTION_ERROR_LOGIN_RESULT_INVALID_CREDENTIALS_DESCRIPTION")]
        InvalidCredentials = InvalidPassword | InvalidUserName,
        /// <summary>
        /// User group use not allowed for the operator.
        /// </summary>
        [Localized("LOGIN_RESULT_OPERATOR_USER_GROUP_DENIED")]
        [Name("Usergroup login denied for operator", "EXCEPTION_ERROR_LOGIN_RESULT_OPERATOR_USER_GROUP_DENIED_NAME")]
        [ExtendedDescription("Usergroup not allowed to login from manager", "EXCEPTION_ERROR_LOGIN_RESULT_OPERATOR_USER_GROUP_DENIED_DESCRIPTION")]
        OperatorUserGroupDenied = 524288,
        /// <summary>
        /// Login is restricted by age-hour restrictions.
        /// </summary>
        [Localized("LOGIN_RESULT_RESTRICTED_BY_AGE")]
        [Name("Login age restrictions", "EXCEPTION_ERROR_LOGIN_RESULT_RESTRICTED_BY_AGE_NAME")]
        [ExtendedDescription("Login is not allowed at this time due to age restrictions configuration", "EXCEPTION_ERROR_LOGIN_RESULT_RESTRICTED_BY_AGE_DESCRIPTION")]
        RestrictedByAge = 1048576,
    }
}
