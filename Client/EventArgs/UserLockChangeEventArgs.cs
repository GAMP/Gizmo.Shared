using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client user lock change args.
    /// </summary>
    public class UserLockChangeEventArgs : EventArgs
    {
        public bool IsLocked { get; set; }
    }
}
