using System;

namespace Gizmo.Extensibility.Abstractions
{
    [AttributeUsage(validOn: AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModuleMetadataAttribute : Attribute
    {
        public ModuleMetadataAttribute(string id, string moduleGuid)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id is required.", nameof(id));
            if (!Guid.TryParse(moduleGuid, out _)) throw new ArgumentException("Invalid GUID.", nameof(moduleGuid));
            Id = id;
            ModuleGuid = moduleGuid;
        }

        /// <summary>
        /// Human readable name.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Unique id.
        /// </summary>
        public string ModuleGuid { get; }
    }
}
