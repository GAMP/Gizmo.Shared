namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// A single allowed value of a custom signal parameter.
    /// </summary>
    public sealed record SignalParameterAllowedValue(
        /// <summary>
        /// The value stored in <see cref="SignalQuery.Parameters"/> when selected.
        /// </summary>
        string Value,

        /// <summary>
        /// Neutral display name. Used as fallback when <see cref="NameResourceKey"/> is not
        /// set or its resource is not found.
        /// </summary>
        string Name,

        /// <summary>
        /// Optional localization resource key for the display name.
        /// </summary>
        string? NameResourceKey);
}
