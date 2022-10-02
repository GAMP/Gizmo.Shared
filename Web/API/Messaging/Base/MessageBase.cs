using MessagePack;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Base communication message class.
    /// </summary>
    [MessagePackObject()]
    public abstract class MessageBase : IMessage
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        protected MessageBase()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets message version.
        /// </summary>
        [DefaultValue(0)]
        [JsonIgnore()]
        [Key(0)]
        public int Version
        {
            get; set;
        }

        #endregion
    }
}
