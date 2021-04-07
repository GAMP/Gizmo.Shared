using System;
using System.Collections.Generic;

namespace Gizmo.Shared.ViewModels
{
    /// <summary>
    /// Multi selection view model.
    /// </summary>
    /// <typeparam name="TItemType">Item type.</typeparam>
    public class MultiSelectionViewModel<TItemType> : SingleSelectionViewModel<TItemType>
    {
        #region FIELDS

        #region PRIVATE
        private ICollection<TItemType> _selectedItems;
        #endregion

        #region EVENTS

        #region PUBLIC

        public event EventHandler<SelectionChangedEventArgs<TItemType>> SelectionChanged;

        #endregion

        #endregion

        #endregion

        #region PROPERTIES

        #region PUBLIC

        /// <summary>
        /// Gets or sets selected items.
        /// </summary>
        public ICollection<TItemType> SelectedItems
        {
            get
            {
                if (_selectedItems == null)
                    _selectedItems = CreateCollection();
                return _selectedItems;
            }
            set { SetProperty(ref _selectedItems, value); }
        }

        #endregion

        #endregion

        #region FUNCTIONS

        #region PROTECTED

        #region VIRTUAL
        
        /// <summary>
        /// Lazy initializes desired collection.
        /// </summary>
        /// <returns></returns>
        protected virtual ICollection<TItemType> CreateCollection()
        {
            return new HashSet<TItemType>();
        }   

        #endregion

        #endregion

        #endregion

        #region OVERRIDES

        protected override void OnSelectedChanged(TItemType current, TItemType previous)
        {
            base.OnSelectedChanged(current, previous);

            SelectionChanged?.Invoke(this, new SelectionChangedEventArgs<TItemType>());
        }

        #endregion
    }
}
