using Gizmo.Server.Web.Api;
using System;

namespace Gizmo.Server.Exceptions
{
    /// <summary>
    /// Attribute used to map exceptions to known web api error code.
    /// </summary>
    /// <remarks>
    /// The attribute is used by exception filter for mapping exception to web api error code.
    /// </remarks>
    public class ExceptionFilterCodeAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Web api error code.</param>
        public ExceptionFilterCodeAttribute(WebApiErrorCode errorCode)
        {
            ErrorCode = errorCode;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Web api error code.
        /// </summary>
        public WebApiErrorCode ErrorCode { get; } 

        #endregion
    }
}
