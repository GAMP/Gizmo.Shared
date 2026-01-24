using System.ComponentModel.DataAnnotations;

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
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Full prepayment", "ADVANCE_PAYMENTS_RUSSIA_FULL_PREPAYMENT")]
        RU_full_prepayment = 0,

        /// <summary>
        /// Prepayment (prepayment).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_PREPAYMENT")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Prepayment", "ADVANCE_PAYMENTS_RUSSIA_PREPAYMENT")]
        RU_prepayment = 1,

        /// <summary>
        /// Advance (advance).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_ADVANCE")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Advance", "ADVANCE_PAYMENTS_RUSSIA_ADVANCE")]
        RU_advance = 2,

        /// <summary>
        /// Full payment (full_payment).
        /// </summary>
        [Localized("ADVANCE_PAYMENTS_RU_FULL_PAYMENT")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Full payment", "ADVANCE_PAYMENTS_RUSSIA_FULL_PAYMENT")]
        RU_full_payment = 3,
    }
}
