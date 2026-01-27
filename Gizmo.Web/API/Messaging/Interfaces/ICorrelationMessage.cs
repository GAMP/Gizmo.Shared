using System;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Correlation message interface.
    /// </summary>
    public interface ICorrelationMessage
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets correlation id.
        /// </summary>
        public Guid CorrelationId { get; set; }

        #endregion
    }
}
