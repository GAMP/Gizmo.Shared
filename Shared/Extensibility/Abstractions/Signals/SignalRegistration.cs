using System;
using System.Collections.Generic;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Identity, semantics and parameter schema of a single registered achievement signal.
    /// </summary>
    /// <remarks>
    /// The guid is the canonical signal identity: achievement configuration references
    /// signals by <see cref="SignalGuid"/>, so it is a compatibility contract that must
    /// remain stable for the lifetime of the signal. A signal with different semantics
    /// must ship under a new guid. For provider classes the registration is built by the
    /// host from the class-level <see cref="ModuleMetadataAttribute"/>; collectors declare
    /// registrations for their signals directly.
    /// </remarks>
    public sealed record SignalRegistration(
        /// <summary>
        /// Stable unique signal identity.
        /// </summary>
        Guid SignalGuid,

        /// <summary>
        /// Human-readable neutral signal name (e.g. <c>visits</c>).
        /// Used in diagnostics and as the display fallback when no localized name is available.
        /// </summary>
        string Name,

        /// <summary>
        /// Native measurement unit of the signal values.
        /// </summary>
        SignalUnit Unit,

        /// <summary>
        /// Query filter kinds the signal's provider actually applies.
        /// </summary>
        SignalFilterKinds SupportedFilters,

        /// <summary>
        /// Culture-neutral metadata of the custom parameters the signal accepts via
        /// <see cref="SignalQuery.Parameters"/>. Empty when the signal accepts no custom
        /// parameters — non-empty exactly when <see cref="SignalFilterKinds.Parameters"/>
        /// is declared in <see cref="SupportedFilters"/>.
        /// </summary>
        IReadOnlyList<SignalParameterMetadata> Parameters);
}
