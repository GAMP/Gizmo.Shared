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
        /// <remarks>
        /// Used as the neutral fallback display name when the type carries no class-level
        /// <see cref="System.ComponentModel.DataAnnotations.NameAttribute"/> or its resource is not found.
        /// </remarks>
        public string Id { get; }

        /// <summary>
        /// Unique id.
        /// </summary>
        public string ModuleGuid { get; }
    }
}
