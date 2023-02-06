using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client grace period change args.
    /// </summary>
    public class GracePeriodChangeEventArgs : EventArgs
    {
        public bool IsInGracePeriod { get; set; }

        public int GracePeriodTime { get; set; }
    }
}
