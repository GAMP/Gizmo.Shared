using System;

namespace Gizmo
{
    /// <summary>
    /// Product time usage options.
    /// </summary>
    [Flags]
    public enum ProductTimeUsageOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Maximum usage.
        /// </summary>
        HasMaximumUsage = 1,
        /// <summary>
        /// Maximum daily usage.
        /// </summary>
        HasMaximumDailyUsage = 2,
    }
}
