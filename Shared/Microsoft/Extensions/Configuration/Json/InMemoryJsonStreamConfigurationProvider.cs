using System;
using System.IO;

namespace Microsoft.Extensions.Configuration.Json
{
    public class InMemoryJsonStreamConfigurationProvider : JsonStreamConfigurationProvider, IDisposable
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance of <see cref="InMemoryJsonStreamConfigurationProvider"/>.
        /// </summary>
        /// <param name="source">Configuration surce.</param>
        /// <exception cref="ArgumentNullException">thrown in case <paramref name="source"/> is equal to null.</exception>
        public InMemoryJsonStreamConfigurationProvider(InMemoryJsonStreamConfigurationSource source) : base(source)
        {
            _configurationSource = source ?? throw new ArgumentNullException(nameof(source));
            _configurationSource.StreamChanged += OnSourceChanged;
        }
        #endregion

        #region FIELDS
        private readonly InMemoryJsonStreamConfigurationSource _configurationSource;
        #endregion

        #region EVENT HANDLERS
        private void OnSourceChanged(object sender, EventArgs e)
        {
            Load(); //reload the configuration from current stream source
            OnReload(); //will cause reaload token to trigger change event       
        }
        #endregion

        #region OVERRIDES
        public override void Load()
        {
            //initially stream might not have value
            if (Source.Stream == Stream.Null)
                return;

            //load from current stream
            Load(Source.Stream);
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _configurationSource.StreamChanged -= OnSourceChanged;
        }
        #endregion
    }
}
