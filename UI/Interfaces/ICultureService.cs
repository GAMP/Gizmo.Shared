#nullable enable

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
        /// Sets current UI culture.
        /// </summary>
        /// <param name="culture">Culture.</param>
        Task SetCurrentUICultureAsync(CultureInfo culture);
    }
}
