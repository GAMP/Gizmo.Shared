using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Gizmo.Extensibility.Abstractions;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Reflects over a module type's <see cref="ModuleOptionsAttribute"/> declarations and
    /// produces <see cref="ModuleConfigSectionMetadata"/> for each declared options class.
    /// </summary>
    internal static class ModuleConfigMetadataExtractor
    {
        /// <summary>
        /// Extracts configuration metadata from all <see cref="ModuleOptionsAttribute"/>
        /// declarations on <paramref name="moduleType"/>.
        /// </summary>
        internal static IReadOnlyList<ModuleConfigSectionMetadata> Extract(Type moduleType)
        {
            var attrs = moduleType.GetCustomAttributes<ModuleOptionsAttribute>().ToArray();
            if (attrs.Length == 0)
                return [];

            var sections = new List<ModuleConfigSectionMetadata>(attrs.Length);
            foreach (var attr in attrs)
                sections.Add(BuildSectionMetadata(attr));

            return sections;
        }

        private static ModuleConfigSectionMetadata BuildSectionMetadata(ModuleOptionsAttribute attr)
        {
            var optionsType = attr.OptionsType;

            // Seed the visited set with the root type to guard against circular references.
            var visitedTypes = new HashSet<Type> { optionsType };

            var properties = optionsType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() is null)
                .Select(p => BuildPropertyMetadata(p, visitedTypes))
                .ToArray();

            return new ModuleConfigSectionMetadata
            {
                OptionsTypeName = optionsType.FullName ?? optionsType.Name,
                SectionName = attr.SectionName,
                Properties = properties
            };
        }

        private static ModuleConfigPropertyMetadata BuildPropertyMetadata(PropertyInfo prop, HashSet<Type> visitedTypes)
        {
            // JSON key: [JsonPropertyName] if present, otherwise the property name.
            // IConfiguration binding is case-insensitive so this is the canonical display key.
            var jsonKey = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

            // Display name: [Name] if present, otherwise the property name.
            var displayName = prop.GetCustomAttribute<NameAttribute>()?.Name ?? prop.Name;

            // Description: [ExtendedDescription] if present.
            var description = prop.GetCustomAttribute<ExtendedDescriptionAttribute>()?.Description;

            // Default value: [DefaultValue] if present.
            var defaultValue = prop.GetCustomAttribute<DefaultValueAttribute>()?.Value?.ToString();

            // Required: [JsonRequired] presence.
            var isRequired = prop.GetCustomAttribute<JsonRequiredAttribute>() is not null;

            // Sensitive: [ModuleConfigSensitive] presence.
            var isSensitive = prop.GetCustomAttribute<ModuleConfigSensitiveAttribute>() is not null;

            var (kind, isNullable) = ResolveKind(prop.PropertyType);

            // For Object kinds, recurse into the nested type's properties.
            // If the type was already visited we leave NestedProperties null to break the cycle.
            IReadOnlyList<ModuleConfigPropertyMetadata>? nestedProperties = null;
            if (kind == ModuleConfigPropertyKind.Object)
            {
                var core = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (visitedTypes.Add(core))
                {
                    nestedProperties = core
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.GetCustomAttribute<JsonIgnoreAttribute>() is null)
                        .Select(p => BuildPropertyMetadata(p, visitedTypes))
                        .ToArray();

                    // Backtrack so sibling branches can still visit this type.
                    visitedTypes.Remove(core);
                }
            }

            return new ModuleConfigPropertyMetadata
            {
                JsonKey = jsonKey,
                DisplayName = displayName,
                Description = description,
                Kind = kind,
                IsNullable = isNullable,
                DefaultValue = defaultValue,
                AllowedValues = BuildAllowedValues(prop),
                IsRequired = isRequired,
                IsSensitive = isSensitive,
                NestedProperties = nestedProperties
            };
        }

        private static (ModuleConfigPropertyKind Kind, bool IsNullable) ResolveKind(Type propertyType)
        {
            var underlying = Nullable.GetUnderlyingType(propertyType);
            var isNullable = underlying is not null;
            var core = underlying ?? propertyType;

            if (core.IsEnum)
                return (ModuleConfigPropertyKind.Enum, isNullable);

            if (core == typeof(bool))
                return (ModuleConfigPropertyKind.Boolean, isNullable);

            if (core == typeof(int)   || core == typeof(long)  || core == typeof(short) ||
                core == typeof(uint)  || core == typeof(ulong) || core == typeof(ushort) ||
                core == typeof(byte)  || core == typeof(sbyte))
                return (ModuleConfigPropertyKind.Integer, isNullable);

            if (core == typeof(double) || core == typeof(float) || core == typeof(decimal))
                return (ModuleConfigPropertyKind.Decimal, isNullable);

            // Treat as a nested configuration object if it's not a system type and exposes
            // public instance properties (i.e. a user-defined POCO section).
            if (core != typeof(string)
                && !(core.Namespace?.StartsWith("System") == true)
                && core.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length > 0)
                return (ModuleConfigPropertyKind.Object, isNullable);

            // String and system value types that IConfiguration binds from a string token
            // (DateTime, Guid, Uri, TimeSpan, etc.).
            return (ModuleConfigPropertyKind.String, false);
        }

        private static IReadOnlyList<ModuleConfigAllowedValueMetadata> BuildAllowedValues(PropertyInfo prop)
        {
            // Explicit [ModuleConfigAllowedValues] takes precedence over enum reflection.
            var attr = prop.GetCustomAttribute<ModuleConfigAllowedValuesAttribute>();
            if (attr is not null)
            {
                return attr.Values
                    .Select(v => new ModuleConfigAllowedValueMetadata
                    {
                        Value = v?.ToString() ?? string.Empty
                    })
                    .ToArray();
            }

            // For enum-typed properties (including nullable enums), derive from enum members.
            // IConfiguration binds enums by member name, so Value is the member name string.
            var underlying = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
            if (underlying.IsEnum)
            {
                return underlying
                    .GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Select(f => new ModuleConfigAllowedValueMetadata
                    {
                        Name = f.GetCustomAttribute<NameAttribute>()?.Name,
                        Description = f.GetCustomAttribute<ExtendedDescriptionAttribute>()?.Description,
                        Value = f.Name
                    })
                    .ToArray();
            }

            return [];
        }
    }
}
