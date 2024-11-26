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
        Undefined = 0,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        RU_Main = 1,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        RU_SimplifiedSystemIncomeTaxation = 2,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        RU_SimplifiedSystemIncomeMinusExpenses = 3,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        RU_SingleAgriculturalTax = 4,
        [TaxSystemCountry(TaxSystemCountry.Russia)]
        RU_PatentSystem = 5    
    }
}
