using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client activity event args.
    /// </summary>
    public sealed class ClientActivityEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="activity">Current activity.</param>
        public ClientActivityEventArgs(ClientStartupActivity activity)
        {
            Activity = activity;
        }

        /// <summary>
        /// Gets current client activity.
        /// </summary>
        public ClientStartupActivity Activity
        {
            get;
            init;
        }
    }
}
