#nullable enable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gizmo.UI
{
    /// <summary>
    /// Currency hard options.
    /// </summary>
    [MessagePack.MessagePackObject()]
    public sealed class CurrencyOptions
    {
        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        [MessagePack.Key(0)]
        [DefaultValue(null)]
        [Range(1,10)]
        public string? CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the number of decimal places to use in currency values. The default is 2.
        /// </summary>
        [MessagePack.Key(1)]
        [DefaultValue(2)]
        [Range(2, 4)]
        public int? CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the string to use as the decimal separator in currency values.
        /// </summary>
        [MessagePack.Key(2)]
        [DefaultValue(null)]
        public string? CurrencyDecimalSeparator { get; set; }

        /// <summary>
        ///  Gets or sets the string to use as the group separator in currency values.
        /// </summary>
        [MessagePack.Key(3)]
        [DefaultValue(null)]
        public string? CurrencyGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets an array of integers that specifies the number of digits in each group of digits to the left of the decimal point in currency values. The default is an array containing a single element equal to 3.
        /// </summary>
        [MessagePack.Key(4)]
        [DefaultValue(null)]
        public int[]? CurrencyGroupSizes { get; set; }

        /// <summary>
        ///  Gets or sets the format pattern for negative currency values. The default is 0, which represents "-$n".
        /// </summary>
        [MessagePack.Key(5)]
        [DefaultValue(null)]
        public int? CurrencyNegativePattern { get; set; }

        /// <summary>
        /// Gets or sets the format pattern for positive currency values. The default is 0, which represents "$n".
        /// </summary>
        [MessagePack.Key(6)]
        [DefaultValue(null)]
        public int? CurrencyPositivePattern { get; set; }
    }
}
