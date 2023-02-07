using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Maintenance mode change event args.
    /// </summary>
    public sealed class MaintenanceEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="enabled">Indicates if maintenance mode is enabled.</param>
        public MaintenanceEventArgs(bool enabled)
        {
            IsEnabled = enabled;
        }

        /// <summary>
        /// Gets if maintenance mode is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get;
            init;
        }
    }
}
