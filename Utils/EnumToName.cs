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
}
