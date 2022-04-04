namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Generic message interface.
    /// </summary>
    public interface IMessage
    {
        #region PROPERTIES

        /// <summary>
        /// Gets message version.
        /// </summary>
        public int Version { get; }

        #endregion
    }
}
