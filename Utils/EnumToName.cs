using SundouleiaAPI.Files;

namespace SundouleiaAPI.Enums;
public static class EnumToName
{
    public static string ToName(this DownloadSpeeds speeds)
        => speeds switch
        {
            DownloadSpeeds.Bps => "Byte/s",
            DownloadSpeeds.KBps => "KB/s",
            DownloadSpeeds.MBps => "MB/s",
            _ => "UNK"
        };
}
