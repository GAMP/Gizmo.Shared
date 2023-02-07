using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client shutdown event args.
    /// </summary>
    public sealed class ShutDownEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="restarting"></param>
        /// <param name="isCrashed"></param>
        public ShutDownEventArgs(bool restarting = false, bool isCrashed = false)
        {
            IsRestarting = restarting;
            IsCrashed = isCrashed;
        }

        /// <summary>
        /// Gets if application is restarting.
        /// </summary>
        public bool IsRestarting
        {
            get;
            init;
        }

        /// <summary>
        /// Gets if application is sutting down due to a crash.
        /// </summary>
        public bool IsCrashed
        {
            get;
            init;
        }
    }
}
