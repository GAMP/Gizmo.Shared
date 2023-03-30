using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

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
        IEnumerable<CultureInfo> SupportedCultures { get; }

        #endregion

        #region FUNCTIONS

        Task SetCurrentCultureAsync(CultureInfo culture);
        CultureInfo GetCulture(string twoLetterISOLanguageName);

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

        #endregion
    }
}
