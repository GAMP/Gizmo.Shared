using System;
using System.ComponentModel;

namespace Gizmo.Client.UI
{
    public abstract class ViewStateBase : PropertyChangedBase, IViewState
    {
        #region EVENTS
        public event EventHandler OnChange;
        #endregion

        #region FIELDS
        private bool _emmitChangedOnPropertyChange;
        private bool? _isInitialized;
        private bool _isInitializing;
        private bool _isDirty;
        #endregion

        #region PROPERTIES

        [PropertyChangeIgnore()]
        public bool EmmitChangedOnPropertyChange
        {
            get { return _emmitChangedOnPropertyChange; }
            set { SetProperty(ref _emmitChangedOnPropertyChange, value); }
        }

        [PropertyChangeIgnore()]
        public bool? IsInitialized
        {
            get { return _isInitialized; }
            set { SetProperty(ref _isInitialized, value); }
        }

        [PropertyChangeIgnore()]
        public bool IsInitializing
        {
            get { return _isInitializing; }
            set { SetProperty(ref _isInitializing, value); }
        }

        [PropertyChangeIgnore()]
        public bool IsDirty
        {
            get { return _isDirty; }
        }

        #endregion

        #region FUNCTIONS
        
        public void RaiseChanged()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        } 

        public virtual void SetDefaults()
        {
        }

        public void SetDefaultsIfDirty()
        {
            if(IsDirty)
                SetDefaults();
        }

        #endregion

        #region OVERRIDES

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgsExtended args)
        {
            base.OnPropertyChanged(sender, args);

            //dont take any ignored properties into account
            if (IsIgnoredProperty(args.PropertyName))
                return;

            //any property change marks state as dirty
            _isDirty = true;

            if (EmmitChangedOnPropertyChange)
            {
                //any property changes is considered to be an object change.
                RaiseChanged();
            }
        }

        #endregion
    }
}
