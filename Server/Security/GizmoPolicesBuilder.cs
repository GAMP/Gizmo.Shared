#nullable enable

using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Gizmo.Server
{
    /// <summary>
    /// Helper class to build policies.
    /// </summary>
    public static class GizmoPolicesBuilder
    {
        /// <summary>
        /// Adds known Gizmo policies to the authorization options.
        /// </summary>
        /// <param name="authorizationOptions">Options.</param>
        /// <returns>Options.</returns>
        /// <remarks>
        /// The polices are named in following format Resource:Operation.
        /// </remarks>
        public static AuthorizationOptions AddGizmoPolicies(this AuthorizationOptions authorizationOptions)
        {
            var attributes = Enum.GetValues(typeof(GizmoPolicies)).Cast<GizmoPolicies>()
                 .Select(policy => new
                 {
                     Policy = policy,
                     Description = policy.GetAttribute<ClaimDescriptionAttribute>()
                 })
                 .Where(policy => policy.Description != null)
                 .ToList();

            foreach (var attribute in attributes)
            {
                var description = attribute.Description!;
                var policy = attribute.Policy;
                authorizationOptions.AddPolicy(GetPolicyName(policy), e =>
                {
                    var builder = e.RequireClaim(description.Resource, description.Operation);
                    foreach (var dependency in description.DependsOn)
                    {
                        var dependencyAttribute = dependency.GetAttribute<ClaimDescriptionAttribute>();
                        if (dependencyAttribute == null)
                            continue;

                        builder.RequireClaim(dependencyAttribute.Resource, dependencyAttribute.Operation);
                    }
                });
            }

            //custom policies
            authorizationOptions.AddPolicy("require-register", e => e.RequireClaim(ClaimNames.Register));
            authorizationOptions.AddPolicy("require-branch", e => e.RequireClaim(ClaimNames.Branch));
            authorizationOptions.AddPolicy("require-branch-register", e => e.RequireClaim(ClaimNames.Branch).RequireClaim(ClaimNames.Register));
            authorizationOptions.AddPolicy("require-branch-register", e => e.RequireClaim(ClaimNames.Branch).RequireClaim(ClaimNames.Register));

            return authorizationOptions;
        }

        /// <summary>
        /// Gets policy name.
        /// </summary>
        /// <param name="policy">Claim type.</param>
        /// <returns>Policy name.</returns>
        public static string GetPolicyName(GizmoPolicies policy)
        {
            //no special naming is really required, we can just use enum name as its guaranteed to be unique
            return policy.ToString();
        }
    }
}
