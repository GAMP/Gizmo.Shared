#nullable enable

using MessagePack;

namespace Gizmo.UI
{
    /// <summary>
    /// Currency hard options.
    /// </summary>
    [MessagePackObject()]
    public sealed class CurrencyOptions
    {
        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        [Key(0)]
        public string? CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places to use in currency values. The default is 2.
        /// </summary>
        [Key(1)]
        public int? CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the string to use as the decimal separator in currency values.
        /// </summary>
        [Key(2)]
        public string? CurrencyDecimalSeparator { get; set; }

        /// <summary>
        ///  Gets or sets the string to use as the group separator in currency values.
        /// </summary>
        [Key(3)]
        public string? CurrencyGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets an array of integers that specifies the number of digits in each group of digits to the left of the decimal point in currency values. The default is an array containing a single element equal to 3.
        /// </summary>
        [Key(4)]
        public int[]? CurrencyGroupSizes { get; set; }

        /// <summary>
        ///  Gets or sets the format pattern for negative currency values. The default is 0, which represents "-$n".
        /// </summary>
        [Key(5)]
        public int? CurrencyNegativePattern { get; set; }

        /// <summary>
        /// Gets or sets the format pattern for positive currency values. The default is 0, which represents "$n".
        /// </summary>
        [Key(6)]
        public int? CurrencyPositivePattern { get; set; }
    }
}
