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
    [MessagePack.MessagePackObject()]
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
        [MessagePack.Key(0)]
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
        [MessagePack.Key(1)]
        public string? CurrencySymbol
        {
            get;init;
        }

        /// <summary>
        /// Gets currency decimal digits.
        /// </summary>
        [Name("Currency decimal digits", "SERVER_OPTION_CURRENCY_DECIMAL_DIGITS_NAME")]
        [ExtendedDescription("Specifies currency decimal digits", "SERVER_OPTION_CURRENCY_DECIMAL_DIGITS_DESCRIPTION")]
        [StoreOptionKey("CURRENCY_DECIMAL_DIGITS")]
        [MessagePack.Key(2)]
        [DefaultValue(2)]
        [Range(0, 4)]
        public int? CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets currency decimal separator.
        /// </summary>
        [Name("Currency decimal separator", "SERVER_OPTION_CURRENCY_DECIMAL_SEPARATOR_NAME")]
        [ExtendedDescription("Specifies currency decimal separator", "SERVER_OPTION_CURRENCY_DECIMAL_SEPARATOR_DESCRIPTION")]
        [StoreOptionKey("CURRENCY_DECIMAL_SEPARATOR")]
        [MessagePack.Key(3)]
        [DefaultValue(null)]
        public string? CurrencyDecimalSeparator { get; set; }

        /// <summary>
        ///  Gets or sets the string to use as the group separator in currency values.
        /// </summary>
        [Name("Currency group separator", "SERVER_OPTION_CURRENCY_GROUP_SEPARATOR_NAME")]
        [ExtendedDescription("Specifies currency group separator", "SERVER_OPTION_CURRENCY_GROUP_SEPARATOR_DESCRIPTION")]
        [StoreOptionKey("CURRENCY_GROUP_SEPARATOR")]
        [MessagePack.Key(4)]
        [DefaultValue(null)]
        public string? CurrencyGroupSeparator { get; set; }
    }
}
