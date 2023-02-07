using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User password change event args.
    /// </summary>
    public sealed class UserPasswordChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newPassword">New user password value.</param>
        public UserPasswordChangeEventArgs(string newPassword)
        {
            NewPassword = newPassword;
        }

        /// <summary>
        /// Gets new password value.
        /// </summary>
        public string NewPassword
        {
            get;
            init;
        }
    }
}
