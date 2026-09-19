using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertData(string AlertId, UserData Poster, DateTime PostedAt, DateTime? NoticeTime = null, TimeSpan? Duration = null)
{
    public DateTime LastEdit { get; set; } = DateTime.MinValue;
    public string[] PingedRoles { get; set; } = [];
    public string Header { get; set; } = string.Empty;
    public string Subheader { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public uint Color { get; set; } = uint.MaxValue;
    public uint AccentColor { get; set; } = 0x77999999;
}