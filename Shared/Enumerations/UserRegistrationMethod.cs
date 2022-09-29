using System;

namespace Gizmo
{
    /// <summary>
    /// Registration method.
    /// </summary>
    /// <remarks>
    /// This enum is used to provide available user (password,username e.t.c) registration methods information.
    /// </remarks>
    [Flags()]
    public enum UserRegistrationMethod
    {
        /// <summary>
        /// No registration.
        /// </summary>
        None = 0,
        /// <summary>
        /// Simple registration without verification proccess.
        /// </summary>
        Simple=1,
        /// <summary>
        /// Registration with mobile phone confirmation.
        /// </summary>
        Mobile=2,
        /// <summary>
        /// Registration with email confirmation.
        /// </summary>
        Email=4,
    }
}
