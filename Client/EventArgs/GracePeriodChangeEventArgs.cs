using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Client grace period change args.
    /// </summary>
    public sealed class GracePeriodChangeEventArgs : EventArgs
    {
        public bool IsInGracePeriod
        {
            get;
            init;
        }

        public int GracePeriodTime
        {
            get;
            init;
        }
    }
}
