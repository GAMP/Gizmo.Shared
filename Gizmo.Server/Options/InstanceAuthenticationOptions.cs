using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [StoreOptionsGroup("INSTANCE_AUTHENTICATION")]
    public sealed class InstanceAuthenticationOptions : IStoreOptions
    {
        [Name("State", "SERVER_OPTION_INSTANCE_AUTHENTICATION_STATE_NAME")]
        [StoreOptionKey("STATE")]
        public InstanceAuthenticationState State { get; init; }
    }
}
