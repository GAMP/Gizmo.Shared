using Microsoft.Extensions.Logging;
using System;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

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
        private readonly Subject<Tuple<object, PropertyChangedEventArgs>> _propertyChangedDebounceSubject = new();
        private IDisposable _propertyChnagedDebounceSubscription;
        private IDisposable _stateChangeDebounceSubscription;
        private int _stateChangedDebounceBufferTime = 100;  //buffer state changes for 0.1 second by default
        private int _propertyChangedBufferTime = 100; //buffer state changes for 0.1 second by default
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
        protected int StateChangedDebounceBufferTime
        {
            get { return _stateChangedDebounceBufferTime; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(StateChangedDebounceBufferTime));

                //update current value
                _stateChangedDebounceBufferTime = value;

                //resubscribe
                StateChangedDebounceSubscribe();
            }
        }

        /// <summary>
        /// Gets or sets default view property changed buffer time in milliseconds.
        /// </summary>
        protected int PropertyChangedDebounceBufferTime
        {
            get { return _propertyChangedBufferTime; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(PropertyChangedDebounceBufferTime));

                //update current value
                _propertyChangedBufferTime = value;

                //resubscribe
                PropertyChangedDebounceSubscribe();
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
                .Buffer(TimeSpan.FromMilliseconds(StateChangedDebounceBufferTime))
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

        private void PropertyChangedDebounceSubscribe()
        {
            //dispose any existing subscriptions
            _propertyChnagedDebounceSubscription?.Dispose();

            //resubscribe
            _propertyChnagedDebounceSubscription = _propertyChangedDebounceSubject
             .Buffer(TimeSpan.FromMilliseconds(PropertyChangedDebounceBufferTime))
             .Where(buffer => buffer.Count > 0)
             .Subscribe((e) =>
             {
                 foreach (var item in e.ToList())
                 {
                     OnViewStatePropertyChangedDebounced(item.Item1, item.Item2);
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

        private void OnViewStatePropertyChangedInternal(object sender, PropertyChangedEventArgs e)
        {
            Logger.LogTrace("View state ({viewState}) property ({propertyName}) changed.", sender.GetType().FullName, e.PropertyName);
            
            //call property changed
            OnViewStatePropertyChanged(sender, e);

            //buffer chnage
            _propertyChangedDebounceSubject.OnNext(Tuple.Create(sender, e));
        }

        #endregion

        #region PROTECTED VIRTUAL

        /// <summary>
        /// Called after view state property changed based on buffer interval.
        /// </summary>
        /// <param name="sender">Source view state object.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnViewStatePropertyChangedDebounced(object sender, PropertyChangedEventArgs e)
        {
            Logger.LogInformation("Debounce changed");
        }

        /// <summary>
        /// Called instantly on view state property changed.
        /// </summary>
        /// <param name="sender">Source view state object.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnViewStatePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        #endregion

        #region OVERRIDES      

        protected override Task OnInitializing(CancellationToken ct)
        {
            StateChangedDebounceSubscribe();
            PropertyChangedDebounceSubscribe();

            ViewState.PropertyChanged += OnViewStatePropertyChangedInternal;

            return base.OnInitializing(ct);
        }

        protected override void OnDisposing(bool isDisposing)
        {
            _stateChangeDebounceSubscription?.Dispose();
            _stateChnageDebounceSubject?.Dispose();

            _propertyChangedDebounceSubject?.Dispose();
            _propertyChnagedDebounceSubscription?.Dispose();

            ViewState.PropertyChanged -= OnViewStatePropertyChangedInternal;

            base.OnDisposing(isDisposing);
        }

        #endregion
    }
}
