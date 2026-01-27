namespace Gizmo.UI
{
    /// <summary>
    /// User interface composition settings.
    /// </summary>
    public sealed class UICompositionOptions
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets app assembly.
        /// </summary>
        public string AppAssembly
        {
            get;set;
        }

        /// <summary>
        /// Gets root component type.
        /// </summary>
        public string RootComponentType
        {
            get;set;
        }

        /// <summary>
        /// Gets notifications component type.
        /// </summary>
        public string NotificationsComponentType
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets additional assemblies.
        /// </summary>
        public string[] AdditionalAssemblies
        {
            get; set;
        } = new string[0]; //empty array by default to avoid null references

        #endregion
    }
}
