using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Describes a single custom parameter an achievement signal accepts via
    /// <see cref="SignalQuery.Parameters"/>.
    /// </summary>
    /// <remarks>
    /// Custom parameters extend the typed <see cref="SignalQuery"/> filters with
    /// provider-defined inputs (e.g. a gaming statistics provider accepting
    /// <c>game.wins</c>). The metadata exists so configuration editors can generate
    /// input UI and validation for parameters the host knows nothing about — exactly
    /// as the typed filters get theirs from <see cref="SignalFilterKinds"/>.
    /// Resource keys localize against the declaring provider's assembly resources.
    /// </remarks>
    public sealed record SignalParameterMetadata(
        /// <summary>
        /// Stable parameter key used in <see cref="SignalQuery.Parameters"/> (e.g. <c>game.wins</c>).
        /// A compatibility contract — must never change once shipped.
        /// </summary>
        string Key,

        /// <summary>
        /// Kind of value the parameter accepts — drives the input control and validation
        /// (e.g. <see cref="SignalParameterKind.Number"/> renders a whole-number input).
        /// </summary>
        SignalParameterKind Kind,

        /// <summary>
        /// Neutral display name. Used as fallback when <see cref="NameResourceKey"/> is not
        /// set or its resource is not found.
        /// </summary>
        string Name,

        /// <summary>
        /// Optional localization resource key for the display name.
        /// </summary>
        string? NameResourceKey,

        /// <summary>
        /// Optional neutral description.
        /// </summary>
        string? Description,

        /// <summary>
        /// Optional localization resource key for the description.
        /// </summary>
        string? DescriptionResourceKey,

        /// <summary>
        /// Indicates the parameter must be provided when configuring an achievement on this signal.
        /// </summary>
        bool IsRequired,

        /// <summary>
        /// Optional default value pre-filled by editors.
        /// </summary>
        string? DefaultValue,

        /// <summary>
        /// Optional closed set of allowed values. When present, editors render a selection
        /// control instead of a free input.
        /// </summary>
        IReadOnlyList<SignalParameterAllowedValue>? AllowedValues);
}
