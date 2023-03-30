#nullable enable

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gizmo.UI
{
    public interface IInputLanguageService
    {
        IEnumerable<CultureInfo> AvailableLanguages { get; }
        CultureInfo? GetLanguage(string twoLetterISOLanguageName);
        Task SetCurrentInputLanguageAsync(CultureInfo currentInputLanguage);
    }
}
