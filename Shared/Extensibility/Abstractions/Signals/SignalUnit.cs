namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Native measurement unit of an achievement signal.
    /// </summary>
    /// <remarks>
    /// Determines how raw signal values are displayed, formatted and validated
    /// (e.g. achievement target value editors). Providers always return values
    /// in their native unit; any conversion is a configuration concern.
    /// </remarks>
    public enum SignalUnit
    {
        /// <summary>
        /// Plain occurrence count (e.g. visits, matches played).
        /// </summary>
        Count = 0,

        /// <summary>
        /// Monetary amount in operator currency (e.g. money spent).
        /// </summary>
        Currency = 1,

        /// <summary>
        /// Time duration expressed in seconds (e.g. play time).
        /// </summary>
        Duration = 2,

        /// <summary>
        /// Loyalty points (e.g. points earned).
        /// </summary>
        Points = 3,

        /// <summary>
        /// Time duration expressed in whole days (e.g. days since registration).
        /// </summary>
        Days = 4,
    }
}
