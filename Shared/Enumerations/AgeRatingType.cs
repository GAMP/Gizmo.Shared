using System.ComponentModel;

namespace Gizmo
{
    /// <summary>
    /// Age rating types.
    /// </summary>
    public enum AgeRatingType
    {
        /// <summary>
        /// None.
        /// </summary>
        [Description("None")]
        None = 0,
        /// <summary>
        /// Manual.
        /// </summary>
        [Description("Manual")]
        Manual = 1,
        /// <summary>
        /// ESRB.
        /// </summary>
        [Description("ESRB")]
        ESRB = 2,
        /// <summary>
        /// PEGI.
        /// </summary>
        [Description("PEGI")]
        PEGI = 3,
    }
}
