using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Deposit transaction types.
    /// </summary>
    public enum DepositTransactionType
    {
        /// <summary>
        /// Deposit to an account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_DEPOSIT")]
        [Name("Deposit", "DEPOSIT_TRANSACTION_TYPE_DEPOSIT")]
        Deposit = 0,
        /// <summary>
        /// Withdraw from account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_WITHDRAW")]
        [Name("Withdraw", "DEPOSIT_TRANSACTION_TYPE_WITHDRAW")]
        Withdraw = 1,
        /// <summary>
        /// Account charge.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CHARGE")]
        [Name("Charge", "DEPOSIT_TRANSACTION_TYPE_CHARGE")]
        Charge = 2,
        /// <summary>
        /// Credit an amount to account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CREDIT")]
        [Name("Credit", "DEPOSIT_TRANSACTION_TYPE_CREDIT")]
        Credit = 3
    }
}
