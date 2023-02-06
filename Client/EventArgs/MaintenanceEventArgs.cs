using System;

namespace Gizmo.Client
{
    public class MaintenanceEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        public MaintenanceEventArgs(bool enabled)
        {
            IsEnabled = enabled;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if maintenance mod is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get;
            protected set;
        }

        #endregion
    }
}
