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

    public static string ToName(this DownloadSpeeds speeds)
        => speeds switch
        {
            DownloadSpeeds.Bps => "Byte/s",
            DownloadSpeeds.KBps => "KB/s",
            DownloadSpeeds.MBps => "MB/s",
            _ => "UNK"
        };

    public static string ToName(this PresetApplyType type)
        => type switch
        {
            PresetApplyType.ReplaceAll      => "Replace all current statuses",
            PresetApplyType.UpdateExisting  => "Update duration of existing",
            PresetApplyType.IgnoreExisting  => "Ignore existing",
            _ => "UNK"
        };

    public static string ToDisplayName(this PresetApplyType type)
        => type switch
        {
            PresetApplyType.ReplaceAll      => "Replace All",
            PresetApplyType.UpdateExisting  => "Update Existing",
            PresetApplyType.IgnoreExisting  => "Ignore Existing",
            _ => "UNK"
        };
}
