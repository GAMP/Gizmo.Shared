using System;

namespace Gizmo.Web.Api.Messaging
{
    /// <summary>
    /// Used to provide unique integer id for an event group.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EventGroupAttribute : Attribute
    {
        #region CONSTRUCTOR
        
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="id">Group id.</param>
        public EventGroupAttribute(int id)
        {
            Id = id;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Group id.
        /// </summary>
        public int Id
        {
            get;
        } 

        #endregion
    }
}
