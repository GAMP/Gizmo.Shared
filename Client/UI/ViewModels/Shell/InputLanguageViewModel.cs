using Gizmo.Shared.ViewModels;

namespace Gizmo.Client.UI.ViewModels
{
    /// <summary>
    /// Input language view model.
    /// </summary>
    public sealed class InputLanguageViewModel : ViewModelBase
    {
        #region FIELDS
        private string _name = default;
        private string _iconSource = default;
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets input language name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        /// Gets or sets input language icon source.
        /// </summary>
        public string IconSource
        {
            get { return _iconSource; }
            set { SetProperty(ref _iconSource, value); }
        } 

        #endregion
    }
}
