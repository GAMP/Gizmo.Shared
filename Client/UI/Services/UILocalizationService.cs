using Gizmo.UI.Services;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Gizmo.Client.UI.Services
{
    /// <summary>
    /// Client localization service.
    /// </summary>
    public class UILocalizationService : LocalizationServiceBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="localizer">Localizer.</param>
        public UILocalizationService(ILogger<UILocalizationService> logger, IStringLocalizer localizer) : base(logger, localizer)
        {
        }
        #endregion
    }
}
