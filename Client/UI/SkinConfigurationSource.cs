using System;

namespace Gizmo.Client.UI
{
    /// <summary>
    /// Skin configuration source class.
    /// </summary>
    /// <remarks>
    /// Used to dynamically set skin configuration file.
    /// </remarks>
    public class SkinConfigurationSource : Microsoft.Extensions.Configuration.Json.JsonConfigurationSource
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SkinConfigurationSource() : base()
        {
        }
        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Sets skin configuration source.
        /// </summary>
        /// <param name="fullPath">Full path to the skin configuration file.</param>
        public void SetSource(string fullPath)
        {
            if (fullPath == null)
                throw new ArgumentNullException(nameof(fullPath));

            Path = System.IO.Path.GetFileName(fullPath);
            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(System.IO.Path.GetDirectoryName(fullPath));
        } 

        #endregion
    }
}
