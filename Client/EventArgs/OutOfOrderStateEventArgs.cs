using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Out of order state change event args.
    /// </summary>
    public sealed class OutOfOrderStateEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="newState">New state.</param>
        public OutOfOrderStateEventArgs(bool newState)
        {
            IsOutOfOrder = newState;
        }

        /// <summary>
        /// Gets if out of order.
        /// </summary>
        public bool IsOutOfOrder
        {
            get;
            init;
        }
    }
}
