namespace Gizmo.Companion
{
    public class CompanionConfig : IdBase<string>
    {
        #region PROPERTIES

        public FiscalPrinterConfig FiscalPrinter
        {
            get;set;
        }

        public RealTimeConfig RealTime
        {
            get;set;
        }

        public WebHostConfig WebHost
        {
            get;set;
        }

        #endregion
    }
}
