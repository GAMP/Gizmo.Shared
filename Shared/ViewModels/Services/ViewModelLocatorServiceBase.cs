using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.Shared.ViewModels
{
    public abstract class ViewModelLocatorServiceBase<TKey, TModelType> : IViewModelLocatorService<TKey,TModelType> where TKey : notnull
    {
        #region READ ONLY FIELDS

        /// <summary>
        /// View model cache.
        /// </summary>
        private readonly ConcurrentDictionary<TKey, TModelType> _cache = new();

        #endregion

        #region FIELDS

        private bool _isInitialized;
        private readonly ILogger<ViewModelLocatorServiceBase<TKey,TModelType>> _logger;

        #endregion

        #region PROPERTIES

        public IEnumerable<TModelType> ViewModels => _cache.Values; 

        public bool IsInitialized
        {
            get { return _isInitialized; }
            protected set { _isInitialized = value; }
        }

        /// <summary>
        /// Gets default logger.
        /// </summary>
        private ILogger<ViewModelLocatorServiceBase<TKey, TModelType>> Logger
        {
            get { return _logger; }
        }

        #endregion

        #region PUBLIC FUNCTIONS
        
        public async Task<TModelType> GetAsync(TKey key)
        {
            if (!_cache.TryGetValue(key, out var model))
                model = await OnGetViewModelAsync(key);
            return model;
        }

        public async ValueTask InitializeAync(CancellationToken ct = default)
        {
            try
            {
                if (!IsInitialized)
                {
                    //call main initialization
                    await OnInitialize(ct);

                    //mark as initialized
                    IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                //log initialization error
                Logger.LogError(ex, "Initialization failed.");
            }
        } 

        #endregion

        #region ABSTRACT MEMBERS

        /// <summary>
        /// Called when we need to obtain a view model by specified key.
        /// </summary>
        /// <param name="key">View model key.</param>
        /// <returns>Found view model, null in case no view model can be found.</returns>
        protected abstract Task<TModelType> OnGetViewModelAsync(TKey key);

        /// <summary>
        /// Called upon initialization.
        /// </summary>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Associated task.</returns>
        protected abstract Task OnInitialize(CancellationToken ct);

        #endregion
    }
}
