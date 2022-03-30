using System.Collections.Generic;

namespace Gizmo.Companion
{
    /// <summary>
    /// Fiscal printer configuration.
    /// </summary>
    public class FiscalPrinterConfig
    {
        #region PROPERTIES

        /// <summary>
        /// Gets fiscal printer configurations.
        /// </summary>
        public IEnumerable<FiscalPrinterDeviceConfig> FiscalPrinters
        {
            get; set;
        } 

        #endregion
    }
}
