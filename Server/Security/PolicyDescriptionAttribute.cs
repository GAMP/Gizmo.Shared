using System;
using System.ComponentModel.DataAnnotations;
using Gizmo.Server.Security;

namespace Gizmo.Server
{
    /// <summary>
    /// Policy description attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PolicyDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Claim resource.</param>
        /// <param name="operation">Claim operation.</param>
        /// <param name="policyGroup">Policy group.</param>
        /// <param name="dependsOn">Dependent policies.</param>
        /// <param name="policySets">Default policies sets</param>
        /// <param name="nameKey">Localized name key.</param>
        /// <param name="descriptionKey">Localized description key.</param>
        public PolicyDescriptionAttribute(string resource, string operation, GizmoPolicyGroups policyGroup, GizmoPolicies[] dependsOn, string nameKey, string descriptionKey, GizmoPolicySet[] policySets)
        {
            NameKey = nameKey;
            DescriptionKey = descriptionKey;
            Resource = resource;
            Operation = operation;
            PolicyGroup = policyGroup;
            DependsOn = dependsOn;
            DefaultSets = policySets;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Claim resource.</param>
        /// <param name="operation">Claim operation.</param>
        /// <param name="policyGroup">Policy group.</param>
        /// <param name="dependsOn">Policy dependencies.</param>
        /// <param name="nameKey">Localized name key.</param>
        /// <param name="descriptionKey">Localized description key.</param>
        public PolicyDescriptionAttribute(string resource, string operation, GizmoPolicyGroups policyGroup, GizmoPolicies[] dependsOn, string nameKey, string descriptionKey) :
            this(resource, operation, policyGroup, dependsOn, nameKey, descriptionKey, Array.Empty<GizmoPolicySet>())
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Claim resource.</param>
        /// <param name="operation">Claim operation.</param>
        /// <param name="policyGroup">Policy group.</param>
        /// <param name="nameKey">Localized name key.</param>
        /// <param name="descriptionKey">Localized description key.</param>
        public PolicyDescriptionAttribute(string resource, string operation, GizmoPolicyGroups policyGroup, string nameKey, string descriptionKey, GizmoPolicySet[] policySets) : this(resource, operation, policyGroup, Array.Empty<GizmoPolicies>(), nameKey, descriptionKey,policySets)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="resource">Claim resource.</param>
        /// <param name="operation">Claim operation.</param>
        /// <param name="policyGroup">Policy group.</param>
        /// <param name="nameKey">Localized name key.</param>
        /// <param name="descriptionKey">Localized description key.</param>
        public PolicyDescriptionAttribute(string resource, string operation, GizmoPolicyGroups policyGroup, string nameKey, string descriptionKey) : this(resource, operation, policyGroup, Array.Empty<GizmoPolicies>(), nameKey, descriptionKey)
        {
        }

        /// <summary>
        /// Gets resource.
        /// </summary>
        public string Resource
        {
            get;
        }

        /// <summary>
        /// Gets operation.
        /// </summary>
        public string Operation
        {
            get;
        }

        /// <summary>
        /// Gets localized name key.
        /// </summary>
        public string NameKey
        {
            get;
        }

        /// <summary>
        /// Gets localized description key.
        /// </summary>
        public string DescriptionKey
        {
            get;
        }

        /// <summary>
        /// Gets dependencies.
        /// </summary>
        public GizmoPolicies[] DependsOn
        {
            get;
        } = [];

        /// <summary>
        /// Gets default policy sets.
        /// </summary>
        public GizmoPolicySet[] DefaultSets { get; } = [];

        /// <summary>
        /// Gets or sets if permission is assignable.
        /// </summary>
        public bool IsAssignable
        {
            get; init;
        } = true;

        /// <summary>
        /// Gets policy group.
        /// </summary>
        public GizmoPolicyGroups PolicyGroup
        {
            get;
        }

        /// <summary>
        /// This allows implicit conversion from <see cref="PolicyDescriptionAttribute"/> to <see cref="NameAttribute"/>.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator NameAttribute(PolicyDescriptionAttribute value)
        {
            return new NameAttribute(value.Resource, value.NameKey);
        }

        /// <summary>
        /// This allows implicit conversion from <see cref="PolicyDescriptionAttribute"/> to <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ExtendedDescriptionAttribute(PolicyDescriptionAttribute value)
        {
            return new ExtendedDescriptionAttribute(value.Operation, value.DescriptionKey);
        }
    }
}
