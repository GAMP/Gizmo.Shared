using System.Runtime.Serialization;

namespace System.ComponentModel
{
    /// <summary>
    /// Extended PropertyChangedEventArgs class.
    /// </summary>
    [Serializable()]
    [DataContract]
    public class PropertyChangedEventArgsExtended : PropertyChangedEventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public PropertyChangedEventArgsExtended()
            : base(null)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public PropertyChangedEventArgsExtended(string propertyName)
            : base(propertyName)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="newValue">New value.</param>
        public PropertyChangedEventArgsExtended(string propertyName, object newValue)
            : base(propertyName)
        {
            NewValue = newValue;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="newValue">New value.</param>
        /// <param name="oldValue">Old value.</param>
        public PropertyChangedEventArgsExtended(string propertyName, object newValue, object oldValue)
            : base(propertyName)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        ///Gets the new value of the object.
        /// </summary>
        [DataMember()]
        public object NewValue
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the old value of the object.
        /// </summary>
        [DataMember()]
        public object OldValue
        {
            get;
            protected set;
        }

        #endregion
    }
}
