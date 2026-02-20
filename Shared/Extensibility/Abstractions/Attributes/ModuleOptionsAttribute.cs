using System;

namespace Gizmo.Extensibility.Abstractions
{
    /// <summary>
    /// Declares an options class that should be bound from the module's configuration and
    /// registered in the DI container via <c>IOptions&lt;TOptions&gt;</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The options class must be JSON-deserializable. Property names and behaviour follow the
    /// standard <c>System.Text.Json</c> conventions; use the usual annotations to customise
    /// binding:
    /// <list type="bullet">
    ///   <item><c>[JsonPropertyName("name")]</c> — override the JSON key</item>
    ///   <item><c>[JsonIgnore]</c> — exclude a property from binding</item>
    ///   <item><c>[JsonConverter(typeof(...))]</c> — custom converter</item>
    ///   <item><c>[JsonRequired]</c> — mark a property as required</item>
    /// </list>
    /// </para>
    /// <para>
    /// Apply the attribute multiple times on the same module class to register several
    /// independent options types, optionally scoped to different JSON sections:
    /// <code>
    /// [ModuleOptions(typeof(ConnectionOptions), "Connection")]
    /// [ModuleOptions(typeof(RetryOptions), "Retry")]
    /// public sealed class MyPlugin : IModuleStart { ... }
    /// </code>
    /// </para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ModuleOptionsAttribute : Attribute
    {
        /// <param name="optionsType">The options class to bind and register.</param>
        /// <param name="sectionName">
        /// The JSON section name to bind from. When <see langword="null"/> (default) the entire
        /// module configuration JSON is used as the options source.
        /// </param>
        public ModuleOptionsAttribute(Type optionsType, string? sectionName = null)
        {
            OptionsType = optionsType;
            SectionName = sectionName;
        }

        /// <summary>The options class to bind and register.</summary>
        public Type OptionsType { get; }

        /// <summary>
        /// The JSON section name to bind from, or <see langword="null"/> to use the root of
        /// the module configuration.
        /// </summary>
        public string? SectionName { get; }
    }
}
