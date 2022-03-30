namespace Gizmo.Companion
{
    /// <summary>
    /// Base class with id.
    /// </summary>
    public class IdBase<TIDType>
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public virtual TIDType Id { get; set; }
    }
}
