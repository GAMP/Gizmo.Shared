using System;
using System.Collections.Generic;

namespace Gizmo.UI
{
    /// <summary>
    /// Desktop UI Host window interface.
    /// </summary>
    public interface IHostWindow
    {
        /// <summary>
        /// Gets web view process ids.
        /// </summary>
        /// <returns>Process ids, empty list if web view is not initialized.</returns>
        IEnumerable<int> GetWebViewProcessIds();

        /// <summary>
        /// Gets window handle.
        /// </summary>
        IntPtr Handle { get; }
    }
}
