namespace Gizmo.Client
{
    public class ClientAppSettings
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets api endpoint url.
        /// </summary>
        public string ApiEndpoint
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets real time endpoint url.
        /// </summary>
        public string RealTimeEndpoint
        {
            get; set;
        }

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
        /// Gets or sets additional assemblies.
        /// </summary>
        public string[] AdditionalAssemblies
        {
            get; set;
        } = new string[0]; //empty array by default to avoid null references

        #endregion
    }
}
