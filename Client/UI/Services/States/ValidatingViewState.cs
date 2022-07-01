using System.ComponentModel;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Validating view state base class.
    /// </summary>
    public abstract class ValidatingViewState : ViewStateBase, IValidatingViewState
    {
        #region FIELDS
        private bool? _isValid;
        private bool _isValidating;
        #endregion

        #region PROPERTIES
        
        [PropertyChangeIgnore()]
        public bool? IsValid { get { return _isValid; } set { SetProperty(ref _isValid, value); } }
        
        [PropertyChangeIgnore()]
        public bool IsValidating { get { return _isValidating; } set { SetProperty(ref _isValidating, value); } }

        #endregion
    }
}
