using System.Text.Json.Serialization;

namespace Iks_ChatColors;

public class TagObj
{
    
    
    [JsonPropertyName("TagKey")] public string TagKey { get; set; }
    [JsonPropertyName("Tag")] public string Tag { get; set; }
    [JsonPropertyName("TagColor")] public string TagColor { get; set; }
    [JsonPropertyName("ChatColor")] public string ChatColor { get; set; }
    [JsonPropertyName("NameColor")] public string NameColor { get; set; }

    [JsonConstructor]
    public TagObj(string tagKey, string tag, string tagColor, string chatColor, string nameColor)
    {
        TagKey = tagKey;
        Tag = tag;
        TagColor = tagColor;
        ChatColor = chatColor;
        NameColor = nameColor;
    }

    public char GetTagColor()
    {
        return Helper.getColorFromString(TagColor);
    }
    public char GetChatColor()
    {
        return Helper.getColorFromString(ChatColor);
    }
    public char GetNameColor()
    {
        return Helper.getColorFromString(NameColor);
    }

    
}