using Gizmo.Shared.Services;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;

namespace Gizmo.Shared.Shared.Services
{
    /// <summary>
    /// Localization service base.
    /// </summary>
    public abstract class LocalizationServiceBase : ILocalizationService
    {
        #region CONSTRUCTOR
        public LocalizationServiceBase(ILogger logger, IStringLocalizer stringLocalizer)
        {
            _logger = logger;
            _localizer = stringLocalizer;
        }
        #endregion

        #region FIELDS

        #region PRIVATE

        private readonly object[] _DEFAULT_ARGS = System.Array.Empty<object>();
        private readonly IStringLocalizer _localizer;
        private readonly ILogger _logger;
        private readonly HashSet<RegionInfo> _regions = new()
        {
            new RegionInfo("us"),
            new RegionInfo("ru"),
            new RegionInfo("gr")
        };
        private readonly HashSet<CultureInfo> _cultures = new()
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU"),
            new CultureInfo("el-GR")
        };

        #endregion

        #region PUBLIC

        /// <inheritdoc/>
        public IEnumerable<RegionInfo> SupportedRegions => _regions;

        /// <inheritdoc/>
        public IEnumerable<CultureInfo> SupportedCultures => _cultures;

        #endregion

        #endregion

        #region PROPERTIES

        #region PRIVATE

        /// <summary>
        /// Gets localizer instance.
        /// </summary>
        private IStringLocalizer Localizer
        {
            get { return _localizer; }
        }

        /// <summary>
        /// Gets logger instance.
        /// </summary>
        private ILogger Logger
        {
            get { return _logger; }
        }

        #endregion

        #endregion

        #region FUNCTIONS

        #region PUBLIC

        /// <inheritdoc/>
        public string GetString(string key)
        {
            return GetString(key, _DEFAULT_ARGS);
        }

        /// <inheritdoc/>
        public string GetString(string key, params object[] arguments)
        {
            return Localizer.GetString(key, arguments);
        }

        /// <inheritdoc/>
        public string GetStringUpper(string key)
        {
            return GetStringUpper(key, _DEFAULT_ARGS);
        }

        /// <inheritdoc/>
        public string GetStringUpper(string key, params object[] arguments)
        {
            return GetString(key, arguments)?.ToUpper();
        }

        /// <inheritdoc/>
        public string GetStringLower(string key)
        {
            return GetStringLower(key, _DEFAULT_ARGS);
        }

        /// <inheritdoc/>
        public string GetStringLower(string key, params object[] arguments)
        {
            return GetString(key, arguments)?.ToLower();
        }

        /// <inheritdoc/>
        public virtual void SetCurrentCulture(CultureInfo culture)
        {
            Logger.LogTrace($"Setting current culture to {culture}.");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        #endregion

        #endregion
    }
}
