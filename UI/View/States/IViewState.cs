using System;

namespace Gizmo.UI.View.States
{
    /// <summary>
    /// View state interface.
    /// </summary>
    /// <remarks>
    /// Used by any view comopnent that is bound to properties of this object.
    /// </remarks>
    public interface IViewState
    {
        #region EVENTS
        
        /// <summary>
        /// Raised on object change.
        /// </summary>
        event EventHandler OnChange;

        #endregion

        #region PROPERTIES

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

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Raises changed event.
        /// </summary>
        void RaiseChanged();

        #endregion
    }
}
