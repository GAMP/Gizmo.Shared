namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Dependency injection registration scope.
    /// </summary>
    public enum RegisterScope
    {
        /// <summary>
        /// Transient.
        /// </summary>
        Transient=2,
        /// <summary>
        /// Scoped.
        /// </summary>
        Scoped=1,
        /// <summary>
        /// Singelton.
        /// </summary>
        Singelton=0,
    }
}
