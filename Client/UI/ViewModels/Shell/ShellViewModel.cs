using Gizmo.Shared.ViewModels;

namespace Gizmo.Client.UI.ViewModels
{
    /// <summary>
    /// Shell view model.
    /// </summary>
    public sealed class ShellViewModel : ViewModelBase
    {
        #region FIELDS
        private UILanguageSelectionViewModel _uiLanguageSelectionViewModel;
        private InputLanguageSelectionViewModel _inputLanguageSelectionViewModel;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user interface language selection view model.
        /// </summary>
        public UILanguageSelectionViewModel UILanguageSelectionViewModel
        {
            get { return _uiLanguageSelectionViewModel; }
            set { SetProperty(ref _uiLanguageSelectionViewModel, value); }
        }

        /// <summary>
        /// Gets system input language selection view model.
        /// </summary>
        public InputLanguageSelectionViewModel InputLanguageSelectionViewModel
        {
            get { return _inputLanguageSelectionViewModel; }
            set { SetProperty(ref _inputLanguageSelectionViewModel, value); }
        }

        #endregion

        public bool IsActiveAppsExpanded
        {
            get; protected set;
        }
    }
}
