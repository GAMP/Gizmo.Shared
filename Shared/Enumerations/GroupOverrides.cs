using System;

namespace Gizmo
{
    /// <summary>
    /// Computer group configuration overrides.
    /// </summary>
    [Flags]
    public enum GroupOverrides
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Applications.
        /// </summary>
        Applications = 1,
        /// <summary>
        /// Security.
        /// </summary>
        Security = 2,
        /// <summary>
        /// Age rating.
        /// </summary>
        AgeRating = 4,
    }
}