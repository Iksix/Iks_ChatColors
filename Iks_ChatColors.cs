using System.Numerics;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Config;
using CounterStrikeSharp.API.Modules.Utils;

namespace Iks_ChatColors;

public class Iks_ChatColors : BasePlugin, IPluginConfig<ChatConfig>
{
    public static char Default = '\x01';
    public static char White = '\x01';
    public static char Darkred = '\x02';
    public static char Green = '\x04';
    public static char LightYellow = '\x09';
    public static char LightBlue = '\x0B';
    public static char Olive = '\x05';
    public static char Lime = '\x06';
    public static char Red = '\x07';
    public static char LightPurple = '\x03';
    public static char Purple = '\x0E';
    public static char Grey = '\x08';
    public static char Yellow = '\x09';
    public static char Gold = '\x10';
    public static char Silver = '\x0A';
    public static char Blue = '\x0B';
    public static char DarkBlue = '\x0C';
    public static char BlueGrey = '\x0A';
    public static char Magenta = '\x0E';
    public static char LightRed = '\x0F';
    public static char Orange = '\x10';
    
    public override string ModuleName { get; } = "Iks_ChatColors";
    public override string ModuleVersion { get; } = "1.0.0";
    public override string ModuleAuthor { get; } = "iks";

    public TagObj[] Tags;
    
    public ChatConfig Config { get; set; }

    public override void Load(bool hotReload)
    {
        AddCommandListener("say", (player, info) => OnSay(player, info));
    }


    public void OnConfigParsed(ChatConfig config)
    {
        config = ConfigManager.Load<ChatConfig>(ModuleName);
        Tags = config.Tags;
        foreach (var Tag in Tags)
        {
            Console.WriteLine("========================");
            Console.WriteLine($"TagKey: {Tag.TagKey}");
            Console.WriteLine($"Tag: {Tag.Tag}");
            Console.WriteLine($"TagColor: {Tag.GetTagColor()}");
            Console.WriteLine($"ChatColor: {Tag.GetChatColor()}");
            Console.WriteLine($"NameColor: {Tag.GetNameColor()}");
            Console.WriteLine("========================");
        }
        Config = config;
    }
    
    public HookResult OnSay(CCSPlayerController? controller, CommandInfo info)
    {
        if (controller == null) return HookResult.Continue;
        string PlayerTeamColor = TeamColor(controller.TeamNum);

        foreach (var tag in Tags)
        {
            if (tag.TagKey.StartsWith("#"))
            {
                if (AdminManager.PlayerInGroup(controller, tag.TagKey))
                {
                    Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                    return HookResult.Handled;
                };
            }
            if (tag.TagKey.StartsWith("@"))
            {
                if (AdminManager.PlayerHasPermissions(controller, tag.TagKey))
                {
                    Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                    return HookResult.Handled;
                };
            }
            if (tag.TagKey == "CT" && controller.TeamNum == 3)
            {
                Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }
            if (tag.TagKey == "T" && controller.TeamNum == 2)
            {
                Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }
            if (tag.TagKey == "SPEC" && controller.TeamNum == 1)
            {
                Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }
            if (tag.TagKey == "everyone")
            {
                Server.PrintToChatAll($" {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }
        }
        
        
        return HookResult.Continue;
    }
    [ConsoleCommand("css_getcolors")]
    public void OnGetColors(CCSPlayerController? controller, CommandInfo info)
    {
        controller.PrintToChat($" {Default}Default");
        controller.PrintToChat($" {White}White");
        controller.PrintToChat($" {Darkred}Darkred");
        controller.PrintToChat($" {Green}Green");
        controller.PrintToChat($" {LightYellow}LightYellow");
        controller.PrintToChat($" {LightBlue}LightBlue");
        controller.PrintToChat($" {Olive}Olive");
        controller.PrintToChat($" {Lime}Lime");
        controller.PrintToChat($" {Red}Red");
        controller.PrintToChat($" {LightPurple}LightPurple");
        controller.PrintToChat($" {Purple}Purple");
        controller.PrintToChat($" {Grey}Grey");
        controller.PrintToChat($" {Yellow}Yellow");
        controller.PrintToChat($" {Gold}Gold");
        controller.PrintToChat($" {Silver}Silver");
        controller.PrintToChat($" {Blue}Blue");
        controller.PrintToChat($" {DarkBlue}DarkBlue");
        controller.PrintToChat($" {BlueGrey}BlueGrey");
        controller.PrintToChat($" {Magenta}Magenta");
        controller.PrintToChat($" {LightRed}LightRed");
        controller.PrintToChat($" {Orange}Orange");
    }
    
    private string TeamColor(int teamNum)
    {
        string teamColor;

        switch (teamNum)
        {
            case 2:
                teamColor = $"{ChatColors.Yellow}";
                break;
            case 3:
                teamColor = $"{ChatColors.BlueGrey}";
                break;
            default:
                teamColor = $"{ChatColors.White}";
                break;
        }

        return teamColor;
    }
    
    [RequiresPermissions("@css/root")]
    [ConsoleCommand("css_chatcolors_reload")]
    public void OnReloadCommand(CCSPlayerController? controller, CommandInfo info)
    {
        OnConfigParsed(Config);
        if (controller != null)
        {
            controller.PrintToChat($" {ChatColors.Green}[ChatColors] Config Reloaded");
        }
    }
}
