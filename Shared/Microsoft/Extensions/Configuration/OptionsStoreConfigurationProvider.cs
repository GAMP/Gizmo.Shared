#nullable enable
using System;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// Options store configuration source.
    /// </summary>
    public class OptionsStoreConfigurationProvider : ConfigurationProvider
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="source">Configuration source.</param>
        public OptionsStoreConfigurationProvider(OptionsStoreConfigurationSource source) : base()
        {
            _source = source;
            _source.SourceChanged += OnConfigurationSourceSourceChanged;
            _source.OptionsChanged += OnStoreOptionsChanged;
        }

        #endregion

        #region FIELDS
        private readonly OptionsStoreConfigurationSource _source;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets configuration source.
        /// </summary>
        public OptionsStoreConfigurationSource Source
        {
            get { return _source; }
        }

        #endregion

        public override void Load() => LoadAsync().GetAwaiter().GetResult();

        private async Task LoadAsync()
        {
            //service might not be set yet
            if (Source.Service == null)
                return;

            try
            {
                var allOptions = await Source.Service.ReadAsync(default)
                    .ConfigureAwait(false);

                foreach (var optionPack in allOptions)
                {
                    foreach (var option in optionPack.ValueStore)
                    {
                        Data.Remove($"{optionPack.Section ?? optionPack.GroupName}:{option.Key.ValuePropertyName}");
                        Data.Add($"{optionPack.Section ?? optionPack.GroupName}:{option.Key.ValuePropertyName}", option.Value.Value);
                    }
                }

                OnReload();
            }
            catch
            {

            }
        }

        private void OnConfigurationSourceSourceChanged(object? sender, EventArgs e)
        {
            Load();
        }

        private void OnStoreOptionsChanged(object? sender, EventArgs e)
        {
            Load();
        }
    }
}
