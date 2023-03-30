using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Gizmo.UI.Services
{
    /// <summary>
    /// Localization service interface.
    /// </summary>
    public interface ILocalizationService
    {
        #region FUNCTIONS

        /// <summary>
        /// Sets current culture.
        /// </summary>
        /// <param name="culture">
        /// Culture that must be set as current.
        /// </param>
        /// <returns>
        /// Task.
        /// </returns>
        Task SetCurrentCultureAsync(CultureInfo culture);

        /// <summary>
        /// Gets supported cultures.
        /// </summary>
        /// <param name="cToken">
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Supported cultures.
        /// </returns>
        ValueTask<IEnumerable<CultureInfo>> GetSupportedCulturesAsync(CancellationToken cToken = default);

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
