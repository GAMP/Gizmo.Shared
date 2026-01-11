#nullable enable

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

        CultureInfo? GetLanguage(string twoLetterISOLanguageName);
        
        Task SetCurrentInputLanguageAsync(CultureInfo currentInputLanguage);
        
        CultureInfo CurrentInputLanguage { get; }
    }
}
