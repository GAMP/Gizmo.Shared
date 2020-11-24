using System;

namespace Gizmo
{
    /// <summary>
    /// Bundle stock options.
    /// </summary>
    [Flags]
    public enum BundleStockOptionType
    {
        /// <summary>
        /// By default bundled products stock will be counted
        /// </summary>
        None = 0,
        /// <summary>
        /// Bundle has its own stock control.
        /// </summary>
        SelfStockCount = 1
    }
}
