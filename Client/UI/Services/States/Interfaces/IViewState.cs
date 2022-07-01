using System;
using System.ComponentModel;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// View state interface.
    /// </summary>
    /// <remarks>
    /// Used by any view comopnent that is bound to properties of this object.
    /// </remarks>
    public interface IViewState : INotifyPropertyChanged
    {
        #region EVENTS
        
        /// <summary>
        /// Raised on object change.
        /// </summary>
        event EventHandler OnChange;

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets if change event should be reaised on propery change.
        /// </summary>
        bool EmmitChangedOnPropertyChange { get; set; }

        /// <summary>
        /// Gets if state is initialized.
        /// Null indicates initialization pending.
        /// </summary>
        bool? IsInitialized { get; set; }

        /// <summary>
        /// Gets if state is currently initializing.
        /// </summary>
        bool IsInitializing { get; set; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Raises changed event.
        /// </summary>
        void RaiseChanged(); 

        #endregion
    }
}
