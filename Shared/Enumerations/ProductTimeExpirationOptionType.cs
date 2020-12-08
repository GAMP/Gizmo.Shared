using System;

namespace Gizmo
{
    /// <summary>
    /// Product time expiration options.
    /// </summary>
    [Flags]
    public enum ProductTimeExpirationOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// At logout.
        /// </summary>
        ExpiresAtLogout = 1,
        /// <summary>
        /// At date.
        /// </summary>
        [Obsolete()]
        ExpiresAtDate = 2,
        /// <summary>
        /// After time.
        /// </summary>
        ExpireAfterTime = 4,
        /// <summary>
        /// At day time.
        /// </summary>
        ExpireAtDayTime = 8,
    }
}
