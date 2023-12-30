namespace Iks_ChatColors;

public class Helper
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
    
    public static char getColorFromString(string str)
    {
        char color;
        switch (str)
        {
            case "Default":
                color = Default;
                break;
            case "White":
                color = White;
                break;
            case "Darkred":
                color = Darkred;
                break;
            case "Green":
                color = Green;
                break;
            case "LightYellow":
                color = LightYellow;
                break;
            case "LightBlue":
                color = LightBlue;
                break;
            case "Olive":
                color = Olive;
                break;
            case "Lime":
                color = Lime;
                break;
            case "Red":
                color = Red;
                break;
            case "Purple":
                color = Purple;
                break;
            case "Grey":
                color = Grey;
                break;
            case "Yellow":
                color = Yellow;
                break;
            case "Gold":
                color = Gold;
                break;
            case "Silver":
                color = Silver;
                break;
            case "Blue":
                color = Blue;
                break;
            case "DarkBlue":
                color = DarkBlue;
                break;
            case "BlueGrey":
                color = BlueGrey;
                break;
            case "Magenta":
                color = Magenta;
                break;
            case "LightRed":
                color = LightRed;
                break;
            case "LightPurple":
                color = LightPurple;
                break;
            case "Orange":
                color = Orange;
                break;
            default:
                // Handle the case where the color code is not recognized.
                // You might want to set a default color in this case.
                color = Default;
                break;
        }

        return color;
    }
}