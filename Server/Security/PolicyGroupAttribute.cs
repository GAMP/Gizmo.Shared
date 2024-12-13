using System;

namespace Gizmo.Server
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class PolicyGroupAttribute : Attribute
    {
        public PolicyGroupAttribute(GizmoPolicies rootPolicy) 
        {
            RootPolicy = rootPolicy;
        }

        public PolicyGroupAttribute()
        {
        }

        public GizmoPolicies? RootPolicy { get; }
    }
}
