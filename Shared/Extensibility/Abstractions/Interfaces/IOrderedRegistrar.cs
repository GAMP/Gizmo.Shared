namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Defines a contract for objects that specify an order value to determine their processing sequence.
    /// </summary>
    /// <remarks>Implementations can use the order value to control the execution or registration order of
    /// components within a collection. Lower values typically indicate higher priority.</remarks>
    public interface IOrderedRegistrar
    {
        /// <summary>
        /// Gets the order in which the item is processed.
        /// </summary>
        /// <remarks>The order is represented as an integer value, where a lower number indicates a higher
        /// priority in processing. This property is read-only and is typically set during initialization.</remarks>
        int Order { get; }
    }
}
