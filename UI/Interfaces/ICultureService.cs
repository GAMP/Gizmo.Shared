#nullable enable

using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Gizmo.UI
{
    /// <summary>
    /// Culture service.
    /// </summary>
    /// <remarks>
    /// Responsible of setting culture based on platform.
    /// </remarks>
    public interface ICultureService
    {
        /// <summary>
        /// Gets a list of available cultures.
        /// </summary>
        public IEnumerable<CultureInfo> AveliableCultures { get; }

        /// <summary>
        /// Sets current UI culture.
        /// </summary>
        /// <param name="culture">Culture.</param>
        Task SetCurrentCultureAsync(CultureInfo culture);
        CultureInfo GetCurrentCulture(string twoLetterISOLanguageName);
    }
}
