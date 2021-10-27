namespace Gizmo
{
    /// <summary>
    /// Loyality points transaction type.
    /// </summary>
    public enum PointsTransactionType
    {
        /// <summary>
        /// Points award.
        /// </summary>
        Award = 0,
        /// <summary>
        /// Points redeem.
        /// </summary>
        Redeem = 1,
        /// <summary>
        /// Points set.
        /// </summary>
        Set = 2,
        /// <summary>
        /// Points credited.
        /// </summary>
        Credit = 3,
        /// <summary>
        /// Points return transaction.
        /// </summary>
        Remove = 4,
    }
}
