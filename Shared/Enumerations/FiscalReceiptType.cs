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
        /// Register transaction.
        /// </summary>
        RegisterTransaction=4,
    }
}
