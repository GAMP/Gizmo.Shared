using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Gizmo.Server.Security
{
    /// <summary>
    /// Helper class to build policies.
    /// </summary>
    public static class PolicesBuilder
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
                     Description = policy.GetAttribute<PolicyDescriptionAttribute>()
                 })
                 .Where(policy => policy.Description != null)
                 .ToList();

            foreach (var attribute in attributes)
            {
                var descriptionAttribute = attribute.Description!;
                var policy = attribute.Policy;

                authorizationOptions.AddPolicy(GetPolicyName(policy), e =>
                {
                    var builder = e.RequireClaim(descriptionAttribute.Resource, descriptionAttribute.Operation);
                    foreach (var dependency in descriptionAttribute.DependsOn)
                    {
                        var dependencyAttribute = dependency.GetAttribute<PolicyDescriptionAttribute>();
                        if (dependencyAttribute == null)
                            continue;

                        builder.RequireClaim(dependencyAttribute.Resource, dependencyAttribute.Operation);
                    }
                });
            }

            //custom policies
            authorizationOptions.AddPolicy("require-register", e => e.RequireClaim(ClaimNames.RegisterId));
            authorizationOptions.AddPolicy("require-branch", e => e.RequireClaim(ClaimNames.BranchId));
            authorizationOptions.AddPolicy("require-branch-register", e => e.RequireClaim(ClaimNames.BranchId).RequireClaim(ClaimNames.RegisterId));
            authorizationOptions.AddPolicy("require-branch-register", e => e.RequireClaim(ClaimNames.BranchId).RequireClaim(ClaimNames.RegisterId));

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

        /// <summary>
        /// Returns all supported claims.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<(string Operation, string Resource)> Claims()
        {
            return Enum.GetValues(typeof(GizmoPolicies))
                .OfType<GizmoPolicies>()
                .Select(enumValue =>
                {
                    var claimAttribute = enumValue.GetAttribute<PolicyDescriptionAttribute>();
                    return (claimAttribute!.Resource, claimAttribute!.Operation);
              });
        }
    }
}
