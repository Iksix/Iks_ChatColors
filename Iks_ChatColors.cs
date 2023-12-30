using System.Numerics;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Config;
using CounterStrikeSharp.API.Modules.Entities;
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

    public string DeadTag = "[DEAD]";
    public char DeadTagColor;
    public string TeamChatTagT = "[T TEAM]";
    public string TeamChatTagCT = "[CT TEAM]";
    public string TeamChatTagSpec = "[SPEC TEAM]";
    public char TeamColorT;
    public char TeamColorCT;
    public char TeamColorSpec;

    public TagObj[] Tags;

    public ChatConfig Config { get; set; }

    public override void Load(bool hotReload)
    {
        AddCommandListener("say", (player, info) => OnSay(player, info));
        AddCommandListener("say_team", (player, info) => OnSayTeam(player, info));
    }


    public void OnConfigParsed(ChatConfig config)
    {
        config = ConfigManager.Load<ChatConfig>(ModuleName);
        Tags = config.Tags;
        DeadTag = config.DeadTag;
        DeadTagColor = Helper.getColorFromString(config.DeadTagColor);
        TeamChatTagT = config.TeamChatTagT;
        TeamChatTagCT = config.TeamChatTagCT;
        TeamChatTagSpec = config.TeamChatTagSpec;
        TeamColorT = Helper.getColorFromString(config.TeamColorT);
        TeamColorCT = Helper.getColorFromString(config.TeamColorCT);
        TeamColorSpec = Helper.getColorFromString(config.TeamColorSpec);

        Config = config;
    }

    public HookResult OnSay(CCSPlayerController? controller, CommandInfo info)
    {
        if (controller == null) return HookResult.Continue;
        string PlayerTeamColor = TeamColor(controller.TeamNum);
        SteamID sid = new SteamID(controller.SteamID);
        string DeadString = !controller.PawnIsAlive ? $" {DeadTagColor}{DeadTag}" : "";
        string? pGroup = null;
        foreach (var group in AdminManager.GetPlayerAdminData(sid).Groups)
        {
            pGroup = group;
        }

        foreach (var tag in Tags)
        {
            if (tag.TagKey.StartsWith("#"))
            {
                if (pGroup == tag.TagKey)
                {
                    Server.PrintToChatAll(
                        $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                    return HookResult.Handled;
                }

                
            }

            if (tag.TagKey.StartsWith("@"))
            {
                if (pGroup == tag.TagKey)
                {
                    Server.PrintToChatAll(
                        $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                    return HookResult.Handled;
                }

                
            }

            if (tag.TagKey == "CT" && controller.TeamNum == 3)
            {
                Server.PrintToChatAll(
                    $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }

            if (tag.TagKey == "T" && controller.TeamNum == 2)
            {
                Server.PrintToChatAll(
                    $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }

            if (tag.TagKey == "SPEC" && controller.TeamNum == 1)
            {
                Server.PrintToChatAll(
                    $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }

            if (tag.TagKey == "everyone")
            {
                Server.PrintToChatAll(
                    $"{DeadString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                return HookResult.Handled;
            }
        }


        return HookResult.Continue;
    }

    public HookResult OnSayTeam(CCSPlayerController? controller, CommandInfo info)
    {
        if (controller == null) return HookResult.Continue;
        string teamString;
        string DeadString = !controller.PawnIsAlive ? $" {DeadTagColor}{DeadTag}" : "";
        switch (controller.TeamNum)
        {
            case 1:
                teamString = $" {TeamColorSpec}{TeamChatTagSpec}";
                break;
            case 2:
                teamString = $" {TeamColorT}{TeamChatTagT}";
                break;
            case 3:
                teamString = $" {TeamColorCT}{TeamChatTagCT}";
                break;
            default:
                teamString = $" {ChatColors.White}[TO TEAM]";
                break;
        }
        string PlayerTeamColor = TeamColor(controller.TeamNum);
        SteamID sid = new SteamID(controller.SteamID);
        string? pGroup = null;
        foreach (var group in AdminManager.GetPlayerAdminData(sid).Groups)
        {
            pGroup = group;
        }

        foreach (var tag in Tags)
        {
            var players = Utilities.GetPlayers();
            foreach (var player in players)
            {
                if (player.TeamNum == controller.TeamNum)
                {
                    if (tag.TagKey.StartsWith("#"))
                    {
                        if (pGroup == tag.TagKey)
                        {
                            player.PrintToChat(
                                $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                            return HookResult.Handled;
                        }
                    }

                    if (tag.TagKey.StartsWith("@"))
                    {
                        if (pGroup == tag.TagKey)
                        {
                            player.PrintToChat(
                                $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                            return HookResult.Handled;
                        }
                    }

                    if (tag.TagKey == "CT" && controller.TeamNum == 3)
                    {
                        player.PrintToChat(
                            $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                        return HookResult.Handled;
                    }

                    if (tag.TagKey == "T" && controller.TeamNum == 2)
                    {
                        player.PrintToChat(
                            $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                        return HookResult.Handled;
                    }

                    if (tag.TagKey == "SPEC" && controller.TeamNum == 1)
                    {
                        player.PrintToChat(
                            $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                        return HookResult.Handled;
                    }

                    if (tag.TagKey == "everyone")
                    {
                        player.PrintToChat(
                            $"{DeadString} {teamString} {(tag.TagColor == "Team" ? PlayerTeamColor : tag.GetTagColor())}{tag.Tag} {(tag.NameColor == "Team" ? PlayerTeamColor : tag.GetNameColor())}{controller.PlayerName}{White}: {(tag.ChatColor == "Team" ? PlayerTeamColor : tag.GetChatColor())}{info.GetArg(1)}");
                        return HookResult.Handled;
                    }
                }
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
            case 1:
                teamColor = $" {TeamColorSpec}";
                break;
            case 2:
                teamColor = $" {TeamColorT}";
                break;
            case 3:
                teamColor = $" {TeamColorCT}";
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