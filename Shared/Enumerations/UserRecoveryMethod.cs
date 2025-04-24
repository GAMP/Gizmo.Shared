using System;
using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Recovery method.
    /// </summary>
    /// <remarks>
    /// This enum is used to provide available user (password,username e.t.c) recovery methods information.
    /// </remarks>
    [Flags()]
    public enum UserRecoveryMethod
    {
        /// <summary>
        /// No recovery method.
        /// </summary>
        [Name("None", "USER_RECOVERY_METHOD_NONE")]
        None = 0,

        /// <summary>
        /// Recovery by mobile phone.
        /// </summary>
        [Name("Mobile", "USER_RECOVERY_METHOD_MOBILE")]
        Mobile = 1,

        /// <summary>
        /// Recovery by email.
        /// </summary>
        [Name("Email", "USER_RECOVERY_METHOD_EMAIL")]
        Email = 2,
    }
}
