using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    /// <summary>
    /// Tax system country.
    /// </summary>
    /// <remarks>
    /// Used to group tax systems <see cref="TaxSystems"/> by country.
    /// </remarks>
    public enum TaxSystemCountry
    {
        /// <summary>
        /// None.
        /// </summary>
        [Name("Unspecified", "TAX_SYSTEM_COUNTRY_UNSPECIFIED")]
        None = 0,

        /// <summary>
        /// Russia.
        /// </summary>
        [Name("Russia", "TAX_SYSTEM_COUNTRY_RUSSIA")]
        Russia = 1,
    }
}
