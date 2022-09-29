using System;

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
        None = 0,
        /// <summary>
        /// Recovery by mobile phone.
        /// </summary>
        Mobile=1,
        /// <summary>
        /// Recovery by email.
        /// </summary>
        Email=2,
    }
}
