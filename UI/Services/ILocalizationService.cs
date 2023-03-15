using System;
using System.Collections.Generic;
using System.Globalization;

namespace Gizmo.UI.Services
{
    /// <summary>
    /// Localization service interface.
    /// </summary>
    public interface ILocalizationService
    {
        #region PROPERTIES

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
        /// <param name="enumValue">Enum value.</param>
        /// <returns>Localized string value.</returns>
        string GetString(Enum enumValue);

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

        #endregion
    }
}
