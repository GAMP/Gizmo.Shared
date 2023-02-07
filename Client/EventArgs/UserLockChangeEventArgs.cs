using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client user lock change args.
    /// </summary>
    public sealed class UserLockChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public UserLockChangeEventArgs() { }

        /// <summary>
        /// Gets if user lock is active.
        /// </summary>
        public bool IsLocked { get; init; }
    }
}
