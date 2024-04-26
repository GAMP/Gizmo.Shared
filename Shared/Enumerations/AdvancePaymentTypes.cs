namespace Gizmo
{
    /// <summary>
    /// Advance payment types.
    /// </summary>
    /// <remarks>
    /// In payment system this describes the prepayment/advance payments and similar.
    /// </remarks>
    public enum AdvancePaymentTypes
    {
        /// <summary>
        /// Full prepayment (full_prepayment).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_FULL_PREPAYMENT")]
        RU_full_prepayment = 0,
        /// <summary>
        /// Prepayment (prepayment).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_PREPAYMENT")]
        RU_prepayment = 1,
        /// <summary>
        /// Advance (advance).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_ADVANCE")]
        RU_advance = 2,
        /// <summary>
        /// Full payment (full_payment).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_FULL_PAYMENT")] 
        RU_full_payment = 3,
    }
}
