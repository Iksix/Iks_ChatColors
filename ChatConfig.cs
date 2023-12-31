using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace Iks_ChatColors;

public class ChatConfig : IBasePluginConfig
{
    [JsonPropertyName("DeadTag")] public string DeadTag { get; set; } = "[DEAD]";
    [JsonPropertyName("DeadTagColor")] public string DeadTagColor { get; set; } = "White";
    [JsonPropertyName("TeamChatTagT")] public string TeamChatTagT { get; set; } = "[T TEAM]";
    [JsonPropertyName("TeamChatTagCT")] public string TeamChatTagCT { get; set; } = "[CT TEAM]";
    [JsonPropertyName("TeamChatTagSpec")] public string TeamChatTagSpec { get; set; } = "[CT TEAM]";
    [JsonPropertyName("TeamColorT")] public string TeamColorT { get; set; } = "Yellow";
    [JsonPropertyName("TeamColorCT")] public string TeamColorCT { get; set; } = "BlueGrey";
    [JsonPropertyName("TeamColorSpec")] public string TeamColorSpec { get; set; } = "BlueGrey";
    
    [JsonPropertyName("TeamChatTagAllCT")] public string TeamChatTagAllCT { get; set; } = "[CT]";
    [JsonPropertyName("TeamChatTagAllCTColor")] public string TeamChatTagAllCTColor { get; set; } = "BlueGrey";
    [JsonPropertyName("TeamChatTagAllT")] public string TeamChatTagAllT { get; set; } = "[T]";
    [JsonPropertyName("TeamChatTagAllTColor")] public string TeamChatTagAllTColor { get; set; } = "Orange";
    [JsonPropertyName("TeamChatTagAllSpec")] public string TeamChatTagAllSpec { get; set; } = "[SPEC]";
    [JsonPropertyName("TeamChatTagAllSpecColor")] public string TeamChatTagAllSpecColor { get; set; } = "Purple";

    [JsonPropertyName("Tags")] public TagObj[] Tags { get; set; } = { new TagObj("everyone", "[Player]", "Green","Green", "Green")  };
    public int Version { get; set; }
}