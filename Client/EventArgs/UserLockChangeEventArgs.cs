using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client user lock change args.
    /// </summary>
    public sealed class UserLockChangeEventArgs : EventArgs
    {
        public bool IsLocked
        {
            get;
            init;
        }
    }
}
