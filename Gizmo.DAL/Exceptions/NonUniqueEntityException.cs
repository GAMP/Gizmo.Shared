using System;
using Gizmo.Server.Exceptions;

namespace Gizmo.DAL
{
    /// <summary>
    /// Non unique entity value exception.
    /// Thrown when trying to update or create an entity and another entity has same unique value.
    /// </summary>
    [ExceptionFilterCode(ExceptionCode.NonUniqueEntityValue)]
    public class NonUniqueEntityValueException : Exception
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Entity key.</param>
        /// <param name="value">Value.</param>
        /// <param name="entityType">Entity type.</param>
        public NonUniqueEntityValueException(string propertyName, object value, Type entityType) : base()
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(PropertyName));

            PropertyName = propertyName;
            Value = value;
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
        }

        public override string Message => $"Specified entity {EntityType} property : {PropertyName} value : {Value} is not unique.";

        /// <summary>
        /// Gets entity property name.
        /// </summary>
        public string PropertyName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        public Type EntityType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity value.
        /// </summary>
        public object Value
        {
            get; set;
        }
    }
}
