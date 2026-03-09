namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Allows the host to push a new configuration JSON string to a running module instance
    /// without restarting it.
    /// </summary>
    /// <remarks>
    /// The host resolves this by <c>PublicId</c> from the keyed DI container and calls
    /// <see cref="Reload"/> whenever the integration's <c>ConfigJson</c> is updated in the
    /// database. All <c>IOptionsMonitor&lt;T&gt;</c> instances bound to that module's
    /// configuration will fire their <c>OnChange</c> callbacks automatically.
    /// </remarks>
    public interface IModuleConfigurationReloader
    {
        /// <summary>
        /// Reloads the module configuration from the supplied JSON string and notifies all
        /// <c>IOptionsMonitor&lt;T&gt;</c> subscribers of the change.
        /// </summary>
        /// <param name="newConfigJson">
        /// The new configuration JSON, or <see langword="null"/> / empty to clear all values.
        /// </param>
        void Reload(string? newConfigJson);
    }
}
