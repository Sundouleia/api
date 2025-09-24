namespace SundouleiaAPI.Enums;
public static class EnumToName
{
    public static string ToName(this InteractionType interactionType)
        => interactionType switch
        {
            InteractionType.None => "None",
            InteractionType.PauseStateChange => "Pause State Changed",
            InteractionType.PermissionChange => "Permission Changed",
            _ => "UNK"
        };
}
