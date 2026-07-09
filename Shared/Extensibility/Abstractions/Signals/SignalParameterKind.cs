namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Kind of value a custom signal parameter accepts.
    /// </summary>
    /// <remarks>
    /// Describes parameter <em>inputs</em> and drives the editor input control and validation.
    /// Deliberately separate from <see cref="SignalUnit"/>, which describes measured signal
    /// values and is inherently numeric.
    /// </remarks>
    public enum SignalParameterKind
    {
        /// <summary>
        /// Free text value.
        /// </summary>
        Text = 0,

        /// <summary>
        /// Whole number value.
        /// </summary>
        Number = 1,

        /// <summary>
        /// Decimal number value.
        /// </summary>
        Decimal = 2,

        /// <summary>
        /// Boolean toggle value.
        /// </summary>
        Boolean = 3,
    }
}
