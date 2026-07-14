using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
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
        public AssemblyResourcesLocalizationService()
        {
        }
        
        private const string DEFAULT_RESOURCE_NAME = "Resources";

        /// <summary>
        /// Fallback resource simple name probed when an assembly embeds no "Resources" resx.
        /// Host application assemblies conventionally name their default resources "SharedResource"
        /// (e.g. the server assembly), while module assemblies use "Resources".
        /// </summary>
        private const string FALLBACK_RESOURCE_NAME = "SharedResource";
        private CultureInfo? _culture;
        private readonly ConcurrentDictionary<(Assembly asm, string simpleName), ResourceManager?> _managerCache = new();

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

        public string GetLocalizedStringValueOrName(Enum enumValue)
        {
            var nameAttribute = enumValue.GetAttribute<NameAttribute>();
            if (nameAttribute == null)
                return enumValue.ToString();

            var result = GetLocalizedString(enumValue.GetType(), nameAttribute);
            return string.IsNullOrWhiteSpace(result) ? enumValue.ToString() : result;
        }

        /// <inheritdoc/>
        public string GetLocalizedStringValue(Type type, string resourceKey)
        {
            var localizer = GetLocalizer(type.Assembly, DEFAULT_RESOURCE_NAME);
            return localizer.GetString(resourceKey);
        }

        public void SetCulture(CultureInfo? culture) => _culture = culture;

        private LocalizedString GetLocalizedString(Type type, LocalizedAttribute localizedAttribute)
        {
            var localizer = GetLocalizer(type.Assembly, DEFAULT_RESOURCE_NAME);
            return localizer.GetString(localizedAttribute.ResourceKey);
        }

        /// <summary>
        /// Gets default resource string localizer for specified assembly.
        /// </summary>
        /// <param name="assembly">Assembly instance.</param>
        /// <returns>
        /// Default resource string localizer, or a no-op localizer if the assembly embeds no
        /// matching resource. Constructing a <see cref="ResourceManager"/> against a non-existent
        /// base name would throw <see cref="MissingManifestResourceException"/> on first lookup,
        /// which is unacceptable for plugin assemblies that legitimately ship without resources.
        /// </returns>
        private IStringLocalizer GetLocalizer(Assembly assembly, string resourceSimpleName)
        {
            var rm = _managerCache.GetOrAdd((assembly, resourceSimpleName), static key =>
            {
                var (asm, simpleName) = key;
                var baseName = ResolveResourceBaseNameFromManifest(asm, simpleName)
                    ?? ResolveResourceBaseNameFromManifest(asm, FALLBACK_RESOURCE_NAME);
                return baseName is null ? null : new ResourceManager(baseName, asm);
            });

            return rm is null
                ? NullStringLocalizer.Instance
                : new ResourceManagerBackedStringLocalizer(rm, _culture);
        }

        private static string? ResolveResourceBaseNameFromManifest(Assembly assembly, string resourceSimpleName)
        {
            // Manifest contains entries like "...Resources.resources"
            // (Culture-specific resx typically go into satellite assemblies and won't appear here.)
            var suffix = "." + resourceSimpleName + ".resources";

            var candidates = assembly.GetManifestResourceNames()
                .Where(n => n.EndsWith(suffix, StringComparison.Ordinal))
                .Select(n => n[..^".resources".Length]) // remove trailing ".resources"
                .ToArray();

            if (candidates.Length == 0)
                return null;

            // Prefer the “most canonical” candidate:
            // 1) If there is exactly one, use it.
            // 2) Else prefer the shortest (usually least nested, e.g. avoids accidental extra segments)
            // 3) You can replace this policy with explicit priority rules if you want.
            if (candidates.Length == 1)
                return candidates[0];

            return candidates.OrderBy(c => c.Length).First();
        }

        private sealed class NullStringLocalizer : IStringLocalizer
        {
            public static readonly NullStringLocalizer Instance = new();

            public LocalizedString this[string name] => new(name ?? string.Empty, name ?? string.Empty, resourceNotFound: true);

            public LocalizedString this[string name, params object[] arguments] => new(name ?? string.Empty, name ?? string.Empty, resourceNotFound: true);

            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) => [];
        }

        public sealed class ResourceManagerBackedStringLocalizer : IStringLocalizer
        {
            private readonly ResourceManager _resourceManager;
            private readonly CultureInfo? _fixedCulture;

            public ResourceManagerBackedStringLocalizer(ResourceManager rm, CultureInfo? fixedCulture = null)
            {
                _resourceManager = rm;
                _fixedCulture = fixedCulture;
            }

            private CultureInfo Culture => _fixedCulture ?? CultureInfo.CurrentUICulture;

            public LocalizedString this[string name]
            {
                get
                {
                    var value = _resourceManager.GetString(name, Culture);
                    return value is null
                        ? new LocalizedString(name, name, resourceNotFound: true)
                        : new LocalizedString(name, value, resourceNotFound: false);
                }
            }

            public LocalizedString this[string name, params object[] arguments]
            {
                get
                {
                    var format = _resourceManager.GetString(name, Culture);
                    if (format is null)
                        return new LocalizedString(name, name, resourceNotFound: true);

                    var value = string.Format(Culture, format, arguments);
                    return new LocalizedString(name, value, resourceNotFound: false);
                }
            }

            public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
            {
                var set = _resourceManager.GetResourceSet(Culture, createIfNotExists: true, tryParents: includeParentCultures);
                if (set is null) yield break;

                foreach (System.Collections.DictionaryEntry entry in set)
                {
                    if (entry.Key is string key)
                        yield return new LocalizedString(key, entry.Value?.ToString() ?? key, resourceNotFound: false);
                }
            }

            public ResourceManagerBackedStringLocalizer WithCulture(CultureInfo culture)
                => new (_resourceManager, culture);
        }
    }
}
