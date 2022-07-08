using System;
using System.ComponentModel;
using System.Threading;

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
        private int _propertyChnagedlockCount;
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
            set { SetProperty(ref _isDirty, value); }
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

        #endregion

        #region OVERRIDES

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgsExtended args)
        {
            base.OnPropertyChanged(sender, args);

            if (EmmitChangedOnPropertyChange)
            {
                //any property changes is considered to be an object change.
                RaiseChanged();
            }
        }

        protected override bool OnPropertyChanging(object sender, PropertyChangedEventArgsExtended args)
        {
            //dont take any ignored properties into account
            if (IsIgnoredProperty(args.PropertyName))
                return false;

            if (Interlocked.Add(ref _propertyChnagedlockCount,0) > 0)
            {
                return false;
            }
            else
            {
                return base.OnPropertyChanging(sender, args);
            }
        }

        #endregion

        /// <summary>
        /// Creates property change lock.
        /// </summary>
        /// <remarks>
        /// As long as one or more locks held the <see cref="PropertyChangedBase.OnPropertyChanged(object, PropertyChangedEventArgsExtended)"/> method will not be called.
        /// </remarks>
        /// <returns>Disposable lock object.</returns>
        public IDisposable PropertyChangedLock()
        {
            Interlocked.Increment(ref _propertyChnagedlockCount);
            return new PropertyChangeLock(this);
        }

        internal void ReleaseLock()
        {
            int previousCount = Interlocked.Add(ref _propertyChnagedlockCount, 0);
            int newCount = Interlocked.Decrement(ref _propertyChnagedlockCount);

            if (previousCount > 0 && newCount == 0)
            {
                //all locks released
            }
        }
    }

    class PropertyChangeLock : IDisposable
    {
        #region CONSTRUCTOR
        public PropertyChangeLock(ViewStateBase viewState)
        {
            _viewState = viewState ?? throw new ArgumentNullException(nameof(viewState));
        } 
        #endregion

        #region READ ONLY FIELDS
        private readonly ViewStateBase _viewState;
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _viewState.ReleaseLock();
        } 
        #endregion
    }
}
