﻿using System;

namespace Gizmo.Client
{
    public class ShutDownEventArgs : EventArgs
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
            protected set;
        }

        /// <summary>
        /// Gets if application is sutting down due to a crash.
        /// </summary>
        public bool IsCrashed
        {
            get;
            protected set;
        }

        #endregion
    }
}
