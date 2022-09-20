using System;

namespace Microsoft.Extensions.Options
{
    /// <summary>
    /// Protect attribute used to mark properties that should be protected.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public sealed class ProtectAttribute : Attribute
    {
    }
}
