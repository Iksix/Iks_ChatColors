using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace Iks_ChatColors;

public class ChatConfig : IBasePluginConfig
{
    [JsonPropertyName("Tags")] public TagObj[] Tags { get; set; } = { new TagObj("everyone", "[Player]", "Green","Green", "Green")  };
    public int Version { get; set; }
}