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
        RU_Main = 1,
        RU_SimplifiedSystemIncomeTaxation = 2,
        RU_SimplifiedSystemIncomeMinusExpenses = 3,
        RU_SingleAgriculturalTax = 4,
        RU_PatentSystem = 5    
    }
}
