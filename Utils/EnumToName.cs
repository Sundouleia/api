namespace SundouleiaAPI.Enums;
public static class EnumToName
{
    public static string ToName(this DataEventType interactionType)
        => interactionType switch
        {
            DataEventType.None => "None",
            DataEventType.PauseStateChange => "Pause State Changed",
            DataEventType.PermissionChange => "Permission Changed",
            _ => "UNK"
        };
}
