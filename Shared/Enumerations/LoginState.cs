using System;

namespace Gizmo
{
    /// <summary>
    /// Login state enumeration.
    /// </summary>
    [Flags()]
    public enum LoginState
    {
        /// <summary>
        /// Logged out.
        /// </summary>
        LoggedOut = 0,
        /// <summary>
        /// Logged in.
        /// </summary>
        LoggedIn = 1,
        /// <summary>
        /// Logging in.
        /// </summary>
        LoggingIn = 2,
        /// <summary>
        /// Logging out.
        /// </summary>
        LoggingOut = 4,
        /// <summary>
        /// Login failed.
        /// </summary>
        LoginFailed = 8,
        ///<summary>
        /// Login completed.
        /// </summary>
        LoginCompleted = 16 | LoggedIn,
    }
}
