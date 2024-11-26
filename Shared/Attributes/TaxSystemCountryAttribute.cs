using System;

namespace Gizmo
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple =false)]
    public sealed class TaxSystemCountryAttribute : Attribute
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="country">Tax system country.</param>
        public TaxSystemCountryAttribute(TaxSystemCountry country)
        {
            Country = country;
        }

        /// <summary>
        /// Gets tax system country.
        /// </summary>
        public TaxSystemCountry Country { get; private set; }
    }
}
