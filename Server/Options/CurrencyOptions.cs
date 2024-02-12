#nullable enable

using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// Currency options.
    /// </summary>
    [OptionsConfigurationSection("CURRENCY")]
    [StoreOptionsGroup("CURRENCY")]    
    public sealed class CurrencyOptions : IStoreOptions
    {
        /// <summary>
        /// Gets default ISO 4217 currency.<br></br>
        /// <a href="https://en.wikipedia.org/wiki/ISO_4217"></a>
        /// </summary>
        [Name("Default currency", "SERVER_OPTION_CURRENCY_CURRENCY_NAME")]
        [ExtendedDescription("Specifies default currency", "SERVER_OPTION_CURRENCY_CURRENCY_DESCRIPTION")]
        [StoreOptionKey("CURRENCY_CODE")]
        [StringLength(3,MinimumLength = 3)]
        [DefaultValue(null)]
        public string? CurrencyCode
        {
            get; init;
        }

        /// <summary>
        /// Gets optional currency symbol.
        /// </summary>
        /// <remarks>
        /// This value is used to override current culture currency symbol.
        /// </remarks>
        [Name("Currency symbol", "SERVER_OPTION_CURRENCY_SYMBOL_NAME")]
        [ExtendedDescription("Specifies currency symbol", "SERVER_OPTION_CURRENCY_SYMBOL_DESCRIPTION")]
        [StoreOptionKey("CURRENCY_SYMBOL")]
        [DefaultValue(null)]
        public string? CurrencySymbol
        {
            get;init;
        }
    }
}
