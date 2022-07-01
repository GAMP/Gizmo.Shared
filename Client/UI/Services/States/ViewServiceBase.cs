using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Client.UI.View.Services
{
    /// <summary>
    /// View service base class.
    /// </summary>
    public abstract class ViewServiceBase : IViewService
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="logger">Service logger.</param>
        /// <param name="serviceProvider">Service provider.</param>
        public ViewServiceBase(ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region FIELDS
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly SemaphoreSlim _initSemaphore = new(1);
        private bool _isDisposed;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets service logger.
        /// </summary>
        protected ILogger Logger
        {
            get { return _logger; }
        }

        /// <summary>
        /// Gets if service is initialized.
        /// </summary>
        protected bool IsInitialized
        {
            get; set;
        }

        /// <summary>
        /// Gets service provider.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get { return _serviceProvider; }
        }

        /// <summary>
        /// Gets if object is disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return _isDisposed; }
            private set { _isDisposed = value; }
        }

        #endregion

        #region VIRTUAL FUNCTIONS

        public async Task IntializeAsync(CancellationToken ct)
        {
            await _initSemaphore.WaitAsync(ct);
            try
            {
                //check if service is already initialized
                if (IsInitialized)
                    return;

                //call initialization routine
                await OnInitializing(ct);

                //mar as initialzed
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                //log critical service initialization error
                Logger.LogCritical(ex, "Service initialization failed.");
            }
            finally
            {
                _initSemaphore.Release();
            }
        }

        protected virtual Task OnInitializing(CancellationToken ct)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            if (IsDisposed)
                return;

            OnDisposing(true);
            GC.SuppressFinalize(this);

            IsDisposed = true;
        }

        protected virtual void OnDisposing(bool isDisposing)
        {
            //disposing code goes here
        }

        #endregion
    }
}
