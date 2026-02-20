using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Gizmo.Extensibility.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Gizmo.Extensibility
{
    /// <summary>
    /// A <see cref="ConfigurationProvider"/> backed by a JSON string that can be reloaded at
    /// runtime. Calling <see cref="Reload"/> updates the key-value data and fires the change
    /// token that <c>IOptionsMonitor&lt;T&gt;</c> subscribes to, so all registered options
    /// classes are updated without restarting the module.
    /// </summary>
    internal sealed class ReloadableJsonConfigurationProvider : ConfigurationProvider, IModuleConfigurationReloader
    {
        private string? _json;

        internal ReloadableJsonConfigurationProvider(string? json) => _json = json;

        public override void Load() => ParseJson(_json);

        /// <inheritdoc/>
        public void Reload(string? newConfigJson)
        {
            _json = newConfigJson;
            ParseJson(_json);
            OnReload(); // signals IChangeToken → IOptionsMonitor fires OnChange callbacks
        }

        private void ParseJson(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                Data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
                return;
            }

            var bytes = Encoding.UTF8.GetBytes(json);
            using var stream = new MemoryStream(bytes);
            var snapshot = new ConfigurationBuilder().AddJsonStream(stream).Build();

            // ConfigurationProvider.Data holds only leaf (non-null) values; section header
            // keys have null values in AsEnumerable() and are intentionally excluded.
            Data = snapshot
                .AsEnumerable()
                .Where(kv => kv.Value is not null)
                .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);
        }
    }

    internal sealed class ReloadableJsonConfigurationSource : IConfigurationSource
    {
        internal ReloadableJsonConfigurationProvider Provider { get; }

        internal ReloadableJsonConfigurationSource(string? json) =>
            Provider = new ReloadableJsonConfigurationProvider(json);

        public IConfigurationProvider Build(IConfigurationBuilder builder) => Provider;
    }
}
