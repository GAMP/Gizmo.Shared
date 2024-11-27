using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Global VAT rates enumeration.
    /// </summary>
    public enum VatRates
    {
        /// <summary>
        /// None (none)
        /// </summary>
        [Localized("VAT_RATES_RU_NONE")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("None", "VAT_RATES_RUSSIA_NONE")]
        RU_none = 0,
        /// <summary>
        /// Zero VAT (vat0)
        /// </summary>
        [Localized("VAT_RATES_RU_VAT0")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT0", "VAT_RATES_RUSSIA_VAT0")]
        RU_vat0 = 1,
        /// <summary>
        /// 10% VAT (vat10)
        /// </summary>
        [Localized("VAT_RATES_RU_VAT10")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT10", "VAT_RATES_RUSSIA_VAT10")]
        RU_vat10 = 2,
        /// <summary>   
        /// 20% VAT (vat20)
        /// </summary>
        [Localized("VAT_RATES_RU_VAT20")]
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT20", "VAT_RATES_RUSSIA_VAT20")]
        RU_vat20 = 3,
    }
}
