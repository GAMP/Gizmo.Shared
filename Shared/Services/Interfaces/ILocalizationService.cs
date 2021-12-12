using System.Collections.Generic;
using System.Globalization;

namespace Gizmo.Shared.Services
{
    /// <summary>
    /// Localization service interface.
    /// </summary>
    public interface ILocalizationService
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets a list of available regions.
        /// </summary>
        public IEnumerable<RegionInfo> SupportedRegions { get; }

        /// <summary>
        /// Gets a list of available cultures.
        /// </summary>
        public IEnumerable<CultureInfo> SupportedCultures { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Localized string value.</returns>
        string GetString(string key);

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Localized string value.</returns>
        string GetString(string key, params object[] arguments);

        /// <summary>
        /// Gets localized string upper variant value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Localized string value.</returns>
        string GetStringUpper(string key);

        /// <summary>
        /// Gets localized string upper variant value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Localized string value.</returns>
        string GetStringUpper(string key, params object[] arguments);

        /// <summary>
        /// Gets localized string lower variant value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Localized string value.</returns>
        string GetStringLower(string key);

        /// <summary>
        /// Gets localized string lower variant value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>Localized string value.</returns>
        string GetStringLower(string key, params object[] arguments);

        /// <summary>
        /// Sets current culture.
        /// </summary>
        /// <param name="culture">Desired culture.</param>
        void SetCurrentCulture(CultureInfo culture); 

        #endregion
    }
}
