using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User password change event args.
    /// </summary>
    public sealed class UserPasswordChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newPassword">New user password value.</param>
        public UserPasswordChangeEventArgs(string newPassword)
        {
            NewPassword = newPassword;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets new password value.
        /// </summary>
        public string NewPassword
        {
            get;
            protected set;
        }
        #endregion
    } 
}
