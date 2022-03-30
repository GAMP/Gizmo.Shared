namespace Gizmo.Companion
{
    /// <summary>
    /// Fiscal printer device config.
    /// </summary>
    public class FiscalPrinterDeviceConfig : IdBase<string>
    {
        #region PROPERTIES
        /// <summary>
        /// Gets fiscal printer type.
        /// </summary>
        public FiscalPrinterType Type
        {
            get; set;
        } 
        #endregion
    }
}
