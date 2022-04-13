namespace Gizmo
{
    /// <summary>
    /// Fiscal receipt type.
    /// </summary>
    public enum FiscalReceiptType 
    {
        /// <summary>
        /// Invoice sale.
        /// </summary>
        Sale=0,
        /// <summary>
        /// Invoice void.
        /// </summary>
        VoidSale=1,
        /// <summary>
        /// Deposit sale.
        /// </summary>
        Deposit=2,
        /// <summary>
        /// Deposit void.
        /// </summary>
        VoidDeposit=3,
        /// <summary>
        /// Deposit withdraw.
        /// </summary>
        WithdrawDeposit=4,
        /// <summary>
        /// Pay in transaction.
        /// </summary>
        PayIn=5,
        /// <summary>
        /// Pay out transaction.
        /// </summary>
        PayOut=6,
    }
}
