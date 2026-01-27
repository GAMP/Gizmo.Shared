using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    [OptionsConfigurationSection("MISC")]
    [StoreOptionsGroup("MISC")]
    [MessagePack.MessagePackObject()]
    public sealed  class MiscOptions : IStoreOptions
    {
        [Name("Execute batch files for computers", "SERVER_OPTION_EXECUTE_BATCH_FOR_COMPUTERS_NAME")]
        [StoreOptionKey("EXECUTE_BATCH_FOR_COMPUTERS")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool ExecuteBatchForComputers { get; init; }
    }
}
