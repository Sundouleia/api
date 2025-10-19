namespace SundouleiaAPI.Enums;


public enum DisconnectIntent : sbyte
{
    Normal       = 0,
    Reconnection = 1,
    Logout       = 2,
    Shutdown     = 3
}
