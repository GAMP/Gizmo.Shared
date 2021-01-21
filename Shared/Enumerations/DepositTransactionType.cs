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
        Deposit = 0,
        /// <summary>
        /// Withdraw from account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_WITHDRAW")]
        Withdraw = 1,
        /// <summary>
        /// Account charge.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CHARGE")]
        Charge = 2,
        /// <summary>
        /// Credit an amount to account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CREDIT")]
        Credit = 3
    }
}