using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Tax systems.
    /// </summary>
    public enum TaxSystems
    {
        /// <summary>
        /// Undefined.
        /// </summary>
        /// <remarks>
        /// Had to keep this enum in order to preserve compatibility with existing configuration.
        /// </remarks>

        [Name("Undefined", "TAX_SYSTEMS_UNDEFINED")]
        Undefined = 0,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Main", "TAX_SYSTEMS_RUSSIA_MAIN")]
        RU_Main = 1,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Simplified system minus taxation", "TAX_SYSTEMS_RUSSIA_SIMPLIFIED_SYSTEM_INCOME_MINUS_TAXATION")]
        RU_SimplifiedSystemIncomeTaxation = 2,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Simplified system minus expenses", "TAX_SYSTEMS_RUSSIA_SIMPLIFIED_SYSTEM_INCOME_MINUS_EXPSENSES")]
        RU_SimplifiedSystemIncomeMinusExpenses = 3,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Single agricultural tax", "TAX_SYSTEMS_RUSSIA_SINGLE_AGRICULTURAL_TAX")]
        RU_SingleAgriculturalTax = 4,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        [Name("Patent system", "TAX_SYSTEMS_RUSSIA_PATENT_SYSTEM")]
        RU_PatentSystem = 5    
    }
}
