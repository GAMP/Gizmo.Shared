using System;

namespace Gizmo.Shared.ViewModels
{
    /// <summary>
    /// Single selection view model.
    /// </summary>
    /// <typeparam name="TItemType">Item type.</typeparam>
    public class SingleSelectionViewModel<TItemType> : ViewModelBase
    {
        #region FIELDS

        #region PRIVATE
        private TItemType _selectedItem;
        #endregion

        #region EVENTS

        #region PUBLIC

        public event EventHandler<SelectedChangedEventArgs<TItemType>> SelectedChanged;

        #endregion

        #endregion

        #endregion

        #region PROPERTIES

        #region PUBLIC

        /// <summary>
        /// Gets or setes selected item.
        /// </summary>
        public TItemType SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                var _previousValue = _selectedItem;
                SetProperty(ref _selectedItem, value);

                SelectedChanged?.Invoke(this, new SelectedChangedEventArgs<TItemType>() { Current = _selectedItem, Previous = _previousValue });
                OnSelectedChanged(_selectedItem, _previousValue);
            }
        }

        #endregion

        #endregion

        #region METHODS

        #region PROTECTED

        /// <summary>
        /// Called once selected item changes.
        /// </summary>
        /// <param name="current">Current item.</param>
        /// <param name="previous">Previous item.</param>
        protected virtual void OnSelectedChanged(TItemType current,TItemType previous)
        {

        }

        #endregion

        #endregion

    }
}
