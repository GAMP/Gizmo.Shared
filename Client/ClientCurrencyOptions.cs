#nullable enable

namespace Gizmo.Client.UI;

/// <summary>
/// Currency hard options.
/// </summary>
public sealed class ClientCurrencyOptions
{
    /// <summary>
    /// Gets or sets the currency symbol.
    /// </summary>
    public string? CurrencySymbol { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal places to use in currency values. The default is 2.
    /// </summary>
    public int? CurrencyDecimalDigits { get; set; }

    /// <summary>
    /// Gets or sets the string to use as the decimal separator in currency values.
    /// </summary>
    public string? CurrencyDecimalSeparator { get; set; }

    /// <summary>
    ///  Gets or sets the string to use as the group separator in currency values.
    /// </summary>
    public string? CurrencyGroupSeparator { get; set; }

    /// <summary>
    /// Gets or sets an array of integers that specifies the number of digits in each group of digits to the left of the decimal point in currency values. The default is an array containing a single element equal to 3.
    /// </summary>
    public int[]? CurrencyGroupSizes { get; set; }

    /// <summary>
    ///  Gets or sets the format pattern for negative currency values. The default is 0, which represents "-$n".
    /// </summary>
    public int? CurrencyNegativePattern { get; set; }

    /// <summary>
    /// Gets or sets the format pattern for positive currency values. The default is 0, which represents "$n".
    /// </summary>
    public int? CurrencyPositivePattern { get; set; }
}
