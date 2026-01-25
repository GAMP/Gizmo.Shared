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
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("None", "VAT_RATES_RUSSIA_NONE")]
        RU_none = 0,
        
        /// <summary>
        /// Zero VAT (vat0)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT0", "VAT_RATES_RUSSIA_VAT0")]
        RU_vat0 = 1,
        
        /// <summary>
        /// 10% VAT (vat10)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT10", "VAT_RATES_RUSSIA_VAT10")]
        RU_vat10 = 2,

        /// <summary>   
        /// 20% VAT (vat20)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT20", "VAT_RATES_RUSSIA_VAT20")]
        RU_vat20 = 3,

        /// <summary>   
        /// 5% VAT (vat5)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT5", "VAT_RATES_RUSSIA_VAT5")]
        RU_vat5 = 4,

        /// <summary>   
        /// 7% VAT (vat7)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT7", "VAT_RATES_RUSSIA_VAT7")]
        RU_vat7 = 5,

        /// <summary>   
        /// 5/105% VAT (vat105)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT105", "VAT_RATES_RUSSIA_VAT105")]
        RU_vat105 = 6,

        /// <summary>   
        /// 7/107% VAT (vat107)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT107", "VAT_RATES_RUSSIA_VAT107")]
        RU_vat107 = 7,

        /// <summary>   
        /// 10/110% VAT (vat110)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT110", "VAT_RATES_RUSSIA_VAT110")]
        RU_vat110 = 8,

        /// <summary>   
        /// 20/120% VAT (vat120)
        /// </summary>
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("VAT120", "VAT_RATES_RUSSIA_VAT120")]
        RU_vat120 = 9,
    }
}
