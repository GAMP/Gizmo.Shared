using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Dependency injection registration attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class RegisterAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public RegisterAttribute()
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="types">Extended types.</param>
        public RegisterAttribute(params Type[] types)
        {
             Types = types;
        }
        
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="scope">Registration scope.</param>
        public RegisterAttribute(RegisterScope scope)
        {
            Scope = scope;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="scope">Registration scope.</param>
        /// <param name="types">Extended types.</param>
        public RegisterAttribute(RegisterScope scope, params Type[] types)
        {
            Scope = scope;
            Types = types;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets registration scope.
        /// </summary>
        /// <remarks>
        /// The default value is <see cref="RegisterScope.Singelton"/>.
        /// </remarks>
        public RegisterScope Scope { get; init; } = RegisterScope.Singelton;

        /// <summary>
        /// Gets extended types by which this service should be registered.
        /// </summary>
        /// <remarks>
        /// The service will always be registered by the type the attribute applied to and all extended types will forward service registration to original type.<br/>
        /// <b>Types must either represent a class or interface.</b> 
        /// </remarks>
        public Type[] Types { get; init; } = Array.Empty<Type>();

        #endregion
    }
}
