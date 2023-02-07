using System;

namespace Gizmo.Client
{
    /// <summary>
    /// Order status change event args.
    /// </summary>
    public sealed class OrderStatusChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR  
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="orderId">Order id.</param>
        /// <param name="newStatus">New status.</param>
        /// <param name="oldStatus">Old status.</param>
        public OrderStatusChangeEventArgs(int userId,
            int orderId,
            OrderStatus newStatus,
            OrderStatus? oldStatus)
        {
            UserId = userId;
            OrderId = orderId;
            NewStatus = newStatus;
            OldStatus = oldStatus;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId
        {
            get;
            init;
        }

        /// <summary>
        /// Gets order id.
        /// </summary>
        public int OrderId
        {
            get;
            init;
        }

        /// <summary>
        /// Gets new status.
        /// </summary>
        public OrderStatus NewStatus
        {
            get;
            init;
        }

        /// <summary>
        /// Gets old status.
        /// </summary>
        public OrderStatus? OldStatus
        {
            get;
            init;
        }

        #endregion

        #region OVERRDIES

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Order id {OrderId} , Old status = {OldStatus?.ToString() ?? ""} New status = {NewStatus}";
        }

        #endregion
    }
}
