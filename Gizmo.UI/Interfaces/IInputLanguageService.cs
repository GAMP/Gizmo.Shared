using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gizmo.UI
{
    public interface IInputLanguageService
    {
        /// <summary>
        /// Occurs once current language changes.
        /// </summary>
        event EventHandler<EventArgs> LanguageChange;

        /// <summary>
        /// Gets available input languages.
        /// </summary>
        IEnumerable<CultureInfo> AvailableInputLanguages { get; }

        /// <summary>
        /// Gets <see cref="CultureInfo"/> based on two letter iso name.
        /// </summary>
        /// <param name="twoLetterISOLanguageName"></param>
        /// <returns></returns>
        CultureInfo? GetLanguage(string twoLetterISOLanguageName);

        /// <summary>
        /// Sets current input language to desired culture.
        /// </summary>
        /// <param name="currentInputLanguage">Language culture.</param>
        /// <returns></returns>
        Task SetCurrentInputLanguageAsync(CultureInfo currentInputLanguage);

        /// <summary>
        /// Gets current input language.
        /// </summary>
        CultureInfo CurrentInputLanguage { get; }
    }
}
