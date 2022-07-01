using Microsoft.Extensions.Logging;
using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Gizmo.Client.UI.View.Services
{
    public abstract class ViewStateServiceBase<TState> : ViewServiceBase where TState : IViewState
    {
        #region CONSTRUCTOR
        public ViewStateServiceBase(TState viewState, ILogger logger, IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
            _viewState = viewState;
        }
        #endregion

        #region FIELDS
        private readonly TState _viewState;
        private readonly Subject<IViewState> _stateChnageDebounceSubject = new();
        private IDisposable _stateChangeDebounceSubscription;
        private int _debounceBufferTime = 100;  //buffer state changes for 0.1 second by default
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets view state.
        /// </summary>
        public TState ViewState
        {
            get { return _viewState; }
        }

        /// <summary>
        /// Gets or sets defaul view state changed buffer time in milliseconds.
        /// </summary>
        protected int DebounceBufferTime
        {
            get { return _debounceBufferTime; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(DebounceBufferTime));

                //resubscribe
                StateChangedDebounceSubscribe();

                //update current value
                _debounceBufferTime = value;
            }
        }

        #endregion

        #region PRIVATE FUNCTIONS

        private void StateChangedDebounceSubscribe()
        {
            //dispose any existing subscriptions
            _stateChangeDebounceSubscription?.Dispose();

            //resubscribe
            _stateChangeDebounceSubscription = _stateChnageDebounceSubject
                .Buffer(TimeSpan.FromMilliseconds(DebounceBufferTime))
                .Where(buffer => buffer.Count > 0)
                .Distinct()
                .Subscribe(viewStates =>
                {
                    foreach (IViewState changedViewState in viewStates)
                    {
                        try
                        {
                            changedViewState.RaiseChanged();
                        }
                        catch (Exception ex)
                        {
                            //the handlers are outside of our code so we should handle the exception and log it
                            Logger.LogError(ex, "Error in view state change handler.");
                        }
                    }
                });
        }

        #endregion

        #region PROTECTED FUNCTIONS
        
        /// <summary>
        /// Debounces view state change.
        /// </summary>
        protected void DebounceViewStateChange()
        {
            DebounceViewStateChange(ViewState);
        }

        /// <summary>
        /// Debounces view state change.
        /// </summary>
        /// <param name="viewState">View state.</param>
        /// <exception cref="ArgumentNullException">thrown in case<paramref name="viewState"/>being equal to null.</exception>
        protected void DebounceViewStateChange(IViewState viewState)
        {
            if (viewState == null)
                throw new ArgumentNullException(nameof(viewState));

            //push the state to the subject
            _stateChnageDebounceSubject.OnNext(viewState);
        } 

        #endregion     

        #region PRIVATE EVENT HANDLERS

        private void OnViewStatePropertyChangedInternal(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Logger.LogTrace("View state ({viewState}) property ({propertyName}) changed.", sender.GetType().FullName, e.PropertyName);            
            OnViewStatePropertyChanged(sender, e);
        }

        #endregion

        #region PROTECTED VIRTUAL

        protected virtual void OnViewStatePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        #endregion

        #region OVERRIDES      

        protected override Task OnInitializing(CancellationToken ct)
        {
            StateChangedDebounceSubscribe();
            ViewState.PropertyChanged += OnViewStatePropertyChangedInternal;

            return base.OnInitializing(ct);
        }

        protected override void OnDisposing(bool isDisposing)
        {
            _stateChangeDebounceSubscription?.Dispose();
            _stateChnageDebounceSubject?.Dispose();

            ViewState.PropertyChanged -= OnViewStatePropertyChangedInternal;

            base.OnDisposing(isDisposing);
        } 

        #endregion
    }
}
