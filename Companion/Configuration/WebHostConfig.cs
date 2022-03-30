using System.ComponentModel.DataAnnotations;

namespace Gizmo.Companion
{
    public class WebHostConfig
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets listen ip.
        /// </summary>
        /// <remarks>
        /// This can be used if we want to listen on specific ip address.
        /// </remarks>
        public string ListenIpAddress
        {
            get; set;
        }

        /// <summary>
        /// Gets default listen port.
        /// </summary>
        [Range(0, 65536)]
        public int? Port
        {
            get; set;
        } 

        #endregion
    }
}
