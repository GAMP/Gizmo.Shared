using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client grace period change args.
    /// </summary>
    public sealed class GracePeriodChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public GracePeriodChangeEventArgs() { }

        /// <summary>
        /// Gets if client is in grace period.
        /// </summary>
        public bool IsInGracePeriod { get; init; }

        /// <summary>
        /// Gets grace period time in minutes.
        /// </summary>
        public int GracePeriodTime { get; init; }
    }
}
