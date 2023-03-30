#nullable enable

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gizmo.UI.Services
{
    public interface IInputLanguageService
    {
        IEnumerable<CultureInfo> AvailableLaguages { get; }
        CultureInfo? GetLanguage(string twoLetterISOLanguageName);
        Task SetCurrentInputLanguageAsync(CultureInfo currentInputLanguage);
    }
}
