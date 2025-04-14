using System;

namespace Gizmo.UI.View.States
{
    /// <summary>
    /// View state interface.
    /// </summary>
    /// <remarks>
    /// Used by any view component that is bound to properties of this object.
    /// </remarks>
    public interface IViewState
    {
        /// <summary>
        /// Raised on object change.
        /// </summary>
        event EventHandler OnChange;

        /// <summary>
        /// Gets if state is initialized.
        /// Null indicates initialization pending.
        /// </summary>
        bool? IsInitialized { get; set; }

        /// <summary>
        /// Gets if state is currently initializing.
        /// </summary>
        bool IsInitializing { get; set; }

        /// <summary>
        /// Gets if state has modifications and considered dirty.
        /// </summary>
        bool IsDirty { get; set; }

        /// <summary>
        /// Raises changed event.
        /// </summary>
        void RaiseChanged();
    }
}
