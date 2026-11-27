using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace Gizmo.Server.Options
{
    /// <summary>
    /// AI options: the MCP endpoint switch and the limits of the AI tool pipeline.
    /// </summary>
    [OptionsConfigurationSection("AI")]
    [StoreOptionsGroup("AI")]
    [MessagePack.MessagePackObject()]
    public sealed class AIOptions : IStoreOptions
    {
        /// <summary>
        /// Whether the MCP endpoint accepts requests.
        /// </summary>
        /// <remarks>
        /// The endpoint is always mapped; while this is off every request to it is rejected, so the switch acts at once.
        /// </remarks>
        [Name("Enable MCP endpoint", "SERVER_OPTION_AI_MCP_ENABLED_NAME")]
        [StoreOptionKey("MCP_ENABLED")]
        [DefaultValue(false)]
        [MessagePack.Key(0)]
        public bool McpEnabled
        {
            get; init;
        }

        /// <summary>
        /// The most tool calls one AI turn may make; further calls in the turn are refused.
        /// </summary>
        [Name("Maximum tool calls per AI turn", "SERVER_OPTION_AI_MAX_TOOL_CALLS_PER_TURN_NAME")]
        [StoreOptionKey("MAX_TOOL_CALLS_PER_TURN")]
        [DefaultValue(16)]
        [Range(1, 256)]
        [MessagePack.Key(1)]
        public int MaxToolCallsPerTurn
        {
            get; init;
        }
    }
}
