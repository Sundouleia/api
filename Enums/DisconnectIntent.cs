namespace SundouleiaAPI.Enums;


public enum DisconnectIntent : sbyte
{
    Normal          = 0,
    Unexpected      = 1,
    Reload          = 2,
    LogoutShutdown  = 3
}
