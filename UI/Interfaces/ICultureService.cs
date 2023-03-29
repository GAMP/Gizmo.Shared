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
        public IEnumerable<CultureInfo> AvailableCultures { get; }

        /// <summary>
        /// Gets culture or default culter.
        /// </summary>
        /// <param name="culture">Culture.</param>
        Task SetCurrentCultureAsync(CultureInfo culture);
        CultureInfo GetCulture(IEnumerable<CultureInfo> cultures, string twoLetterISOLanguageName);
    }
}
