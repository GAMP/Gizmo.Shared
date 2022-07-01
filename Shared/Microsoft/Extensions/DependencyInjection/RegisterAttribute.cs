using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Dependency injection registration attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class RegisterAttribute : Attribute
    {
        #region PROPERTIES

        /// <summary>
        /// Gets registration scope.
        /// </summary>
        /// <remarks>
        /// The default value is singelton.
        /// </remarks>
        public RegisterScope Scope { get; init; } = RegisterScope.Singelton;

        #endregion
    }
}
