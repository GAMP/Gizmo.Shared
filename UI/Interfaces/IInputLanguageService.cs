#nullable enable

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gizmo.UI
{
    public interface IInputLanguageService
    {
        /// <summary>
        /// Gets available input languages.
        /// </summary>
        IEnumerable<CultureInfo> AvailableInputLanguages { get; }
        CultureInfo? GetLanguage(string twoLetterISOLanguageName);
        Task SetCurrentInputLanguageAsync(CultureInfo currentInputLanguage);
    }
}
