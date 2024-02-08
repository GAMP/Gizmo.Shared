#nullable enable
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Options store configuration source.
    /// </summary>
    public class OptionsStoreConfigurationSource : IConfigurationSource
    {
        #region EVENTS

        /// <summary>
        /// Occurs on source change.
        /// </summary>
        public event EventHandler<EventArgs>? SourceChanged;

        /// <summary>
        /// Occurs on store options change.
        /// </summary>
        public event EventHandler<EventArgs>? OptionsChanged;

        #endregion

        #region FIELDS

        private IOptionsStoreService? _service;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets options service.
        /// </summary>
        public IOptionsStoreService? Service
        {
            get { return _service; }
        }

        #endregion

        #region FUNCTIONS

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new OptionsStoreConfigurationProvider(this);
        }

        /// <summary>
        /// Uses options store service as current source.
        /// </summary>
        /// <param name="service">Options store service.</param>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="service"/>is equal to null.</exception>
        public void UseSource(IOptionsStoreService service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            //if previous service was set unsubscribe from options change event
            if (_service != null)
                _service.Changed -= StoreOptionsChanged;

            _service = service;
            _service.Changed += StoreOptionsChanged;
            SourceChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region EVENT HANDLERS

        private void StoreOptionsChanged(object? sender, EventArgs e)
        {
            OptionsChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
