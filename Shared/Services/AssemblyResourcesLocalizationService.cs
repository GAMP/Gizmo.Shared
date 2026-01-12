#nullable enable

using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace Gizmo
{
    /// <summary>
    /// Assembly resource localization service.
    /// </summary>
    public sealed class AssemblyResourcesLocalizationService : IAssemblyResourcesLocalizationService
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="stringLocalizerFactory">String localizer factory.</param>
        public AssemblyResourcesLocalizationService(IStringLocalizerFactory stringLocalizerFactory)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        /// <summary>
        /// Default name for the resources. (Resources.resx)
        /// </summary>
        private const string DEFAULT_RESOURCE_NAME = "Resources";

        /// <summary>
        /// Localizer cache. This will allow faster access to the target localizers.
        /// </summary>
        private readonly ConcurrentDictionary<Assembly, IStringLocalizer> _localizerCache = new();

        /// <summary>
        /// String localizer factory.
        /// </summary>
        private readonly IStringLocalizerFactory _stringLocalizerFactory;

        /// <inheritdoc/>
        public string GetLocalizedStringValue(Type type, ExtendedDescriptionAttribute? descriptionAttribute)
        {
            if (descriptionAttribute == null)
                return string.Empty;

            var localizedString = GetLocalizedString(type, descriptionAttribute);

            return localizedString.ResourceNotFound ? descriptionAttribute.Description ?? string.Empty : localizedString.Value;
        }

        /// <inheritdoc/>
        public string GetLocalizedStringValue(Type type, NameAttribute? nameAttribute)
        {
            if (nameAttribute == null)
                return string.Empty;

            var localizedString = GetLocalizedString(type, nameAttribute);

            return localizedString.ResourceNotFound ? nameAttribute.Name ?? string.Empty : localizedString.Value;
        }

        /// <inheritdoc/>
        public string GetLocalizedStringValue(Enum enumValue)
        {
            var nameAttribute = enumValue.GetAttribute<NameAttribute>();
            if (nameAttribute == null)
                return string.Empty;

            return GetLocalizedString(enumValue.GetType(), nameAttribute);
        }

        /// <inheritdoc/>
        public string GetLocalizedStringValue(Type type, string resourceKey)
        {
            var localizer = GetLocalizer(type.Assembly);
            return localizer.GetString(resourceKey);
        }

        private LocalizedString GetLocalizedString(Type type, LocalizedAttribute localizedAttribute)
        {
            var localizer = GetLocalizer(type.Assembly);
            return localizer.GetString(localizedAttribute.ResourceKey);
        }

        /// <summary>
        /// Gets default resource string localizer for specified assembly.
        /// </summary>
        /// <param name="assembly">Assembly instance.</param>
        /// <returns>Default resource string localizer.</returns>
        /// <exception cref="ArgumentException">thrown in case assembly name cannot be extracted from specified assembly.</exception>
        private IStringLocalizer GetLocalizer(Assembly assembly)
        {
            string? assemblyName = assembly.FullName;
            if (string.IsNullOrEmpty(assemblyName))
                throw new ArgumentException(nameof(assemblyName));

            return _localizerCache.GetOrAdd(assembly, (a) =>
            {
                return _stringLocalizerFactory.Create(DEFAULT_RESOURCE_NAME, assemblyName);
            });
        }
    }
}
