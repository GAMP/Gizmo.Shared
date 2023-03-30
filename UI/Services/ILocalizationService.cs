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
        /// Gets a list of supported cultures.
        /// </summary>
        IEnumerable<CultureInfo> SupportedCultures { get; }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Sets current culture.
        /// </summary>
        /// <param name="culture">
        /// Culture that must be set as current.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task SetCurrentCultureAsync(CultureInfo culture);
        
        /// <summary>
        /// Gets culture by two letter ISO language name.
        /// </summary>
        /// <param name="twoLetterISOLanguageName">
        /// Two letter ISO language name.
        /// </param>
        /// <returns>
        /// Available culture or defailt if not found.
        /// </returns>
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
