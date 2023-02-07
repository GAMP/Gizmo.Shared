using System;

namespace Gizmo.Client
{
    public sealed class ShutDownEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ShutDownEventArgs(bool restarting = false, bool isCrashed = false)
        {
            IsRestarting = restarting;
            IsCrashed = isCrashed;
        }

        #endregion

        #region PROPERTIES

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

        #endregion
    }
}
