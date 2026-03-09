using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Gizmo.Extensibility.Abstractions;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// Converts between an integration's raw <c>ConfigJson</c> string and the
    /// <see cref="IntegrationConfigSectionValues"/> tree the Manager UI binds to.
    /// </summary>
    public static class IntegrationConfigHelper
    {
        private static readonly JsonSerializerOptions s_writeOptions = new() { WriteIndented = true };

        /// <summary>
        /// Parses an existing <c>ConfigJson</c> string against the given schema, producing a
        /// mutable value tree the UI can bind to.
        /// When <paramref name="configJson"/> is <see langword="null"/> or empty, all values
        /// are initialized from <see cref="ModuleConfigPropertyMetadata.DefaultValue"/>.
        /// </summary>
        public static List<IntegrationConfigSectionValues> Parse(
            IReadOnlyList<ModuleConfigSectionMetadata> schema,
            string? configJson)
        {
            JsonElement? root = null;
            JsonDocument? doc = null;

            if (!string.IsNullOrWhiteSpace(configJson))
            {
                doc = JsonDocument.Parse(configJson);
                root = doc.RootElement;
            }

            try
            {
                var result = new List<IntegrationConfigSectionValues>(schema.Count);

                foreach (var section in schema)
                {
                    JsonElement? sectionEl;

                    if (section.SectionName is null)
                    {
                        sectionEl = root;
                    }
                    else if (root.HasValue
                        && root.Value.TryGetProperty(section.SectionName, out var el)
                        && el.ValueKind == JsonValueKind.Object)
                    {
                        sectionEl = el;
                    }
                    else
                    {
                        sectionEl = null;
                    }

                    result.Add(new IntegrationConfigSectionValues
                    {
                        Schema = section,
                        Properties = ParseProperties(section.Properties, sectionEl)
                    });
                }

                return result;
            }
            finally
            {
                doc?.Dispose();
            }
        }

        /// <summary>
        /// Serializes the value tree back to a <c>ConfigJson</c> string ready to POST.
        /// Properties with a <see langword="null"/> value and <see cref="ModuleConfigPropertyMetadata.IsNullable"/>
        /// set are written as JSON <c>null</c>. Other null-valued properties are omitted.
        /// </summary>
        public static string Serialize(IReadOnlyList<IntegrationConfigSectionValues> sectionValues)
        {
            var root = new JsonObject();

            foreach (var section in sectionValues)
            {
                if (section.Schema.SectionName is null)
                {
                    WriteProperties(root, section.Properties);
                }
                else
                {
                    var sectionNode = new JsonObject();
                    WriteProperties(sectionNode, section.Properties);
                    root[section.Schema.SectionName] = sectionNode;
                }
            }

            return root.ToJsonString(s_writeOptions);
        }

        // --- private helpers ---

        private static List<IntegrationConfigPropertyValue> ParseProperties(
            IReadOnlyList<ModuleConfigPropertyMetadata> properties,
            JsonElement? node)
        {
            var result = new List<IntegrationConfigPropertyValue>(properties.Count);

            foreach (var prop in properties)
            {
                JsonElement? propEl = null;
                if (node.HasValue && node.Value.TryGetProperty(prop.JsonKey, out var el))
                    propEl = el;

                if (prop.Kind == ModuleConfigPropertyKind.Object)
                {
                    JsonElement? objEl = propEl.HasValue && propEl.Value.ValueKind == JsonValueKind.Object
                        ? propEl
                        : null;

                    result.Add(new IntegrationConfigPropertyValue
                    {
                        Schema = prop,
                        NestedValues = prop.NestedProperties is not null
                            ? ParseProperties(prop.NestedProperties, objEl)
                            : []   // circular-reference edge case — schema had no nested metadata
                    });
                }
                else
                {
                    result.Add(new IntegrationConfigPropertyValue
                    {
                        Schema = prop,
                        Value = ReadScalarValue(propEl, prop.DefaultValue)
                    });
                }
            }

            return result;
        }

        private static string? ReadScalarValue(JsonElement? element, string? defaultValue)
        {
            if (!element.HasValue) return defaultValue;

            return element.Value.ValueKind switch
            {
                JsonValueKind.String => element.Value.GetString(),
                JsonValueKind.True   => "true",
                JsonValueKind.False  => "false",
                JsonValueKind.Number => element.Value.GetRawText(),
                JsonValueKind.Null   => null,
                _                    => defaultValue
            };
        }

        private static void WriteProperties(JsonObject target, List<IntegrationConfigPropertyValue> properties)
        {
            foreach (var pv in properties)
            {
                if (pv.Schema.Kind == ModuleConfigPropertyKind.Object)
                {
                    if (pv.NestedValues is not null)
                    {
                        var nested = new JsonObject();
                        WriteProperties(nested, pv.NestedValues);
                        target[pv.Schema.JsonKey] = nested;
                    }
                }
                else if (pv.Value is null)
                {
                    if (pv.Schema.IsNullable)
                        target[pv.Schema.JsonKey] = null;   // explicit JSON null
                    // else: omit — let the server apply its own default
                }
                else
                {
                    target[pv.Schema.JsonKey] = ScalarToJsonNode(pv.Schema.Kind, pv.Value);
                }
            }
        }

        private static JsonNode? ScalarToJsonNode(ModuleConfigPropertyKind kind, string value)
        {
            return kind switch
            {
                ModuleConfigPropertyKind.Boolean
                    when bool.TryParse(value, out var b)   => JsonValue.Create(b),
                ModuleConfigPropertyKind.Integer
                    when long.TryParse(value, out var l)   => JsonValue.Create(l),
                ModuleConfigPropertyKind.Decimal
                    when double.TryParse(value,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out var d)                         => JsonValue.Create(d),
                _                                          => JsonValue.Create(value)
            };
        }
    }
}
