using System;

namespace Gizmo.Client
{
    /// <summary>
    /// User balance change event args.
    /// </summary>
    public sealed class UserBalanceEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="balance">User balance.</param>
        public UserBalanceEventArgs(int userId, IUserBalance balance)
        {
            UserId = userId;
            Balance = balance ?? throw new ArgumentNullException(nameof(balance));
        }

        /// <summary>
        /// Gets user id.
        /// </summary>
        public int UserId { get; init; }

        /// <summary>
        /// Gets balance.
        /// </summary>
        public IUserBalance Balance
        {
            get; init;
        }
    }
}
