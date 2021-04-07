using System;

namespace Gizmo.Shared.ViewModels
{
    /// <summary>
    /// Selected changed event args.
    /// </summary>
    /// <typeparam name="TItemType">Item type.</typeparam>
    public class SelectedChangedEventArgs<TItemType> : EventArgs
    {
        #region PROPERTIES

        #region PUBLIC 

        /// <summary>
        /// Gets currently selected item.
        /// </summary>
        public TItemType Current { get; set; }

        /// <summary>
        /// Gets previously selected item.
        /// </summary>
        public TItemType Previous { get; set; }

        #endregion

        #endregion
    }
}
