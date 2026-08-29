using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleData(string RoleId, string Name, int Priority, int IconId, bool IsGameIcon, uint Color, uint AccentColor, SanctionAccess Access);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertData(string AlertId, UserData Poster, DateTime PostedAt)
{
    public bool PingEveryone { get; set; } = false;
    public DateTime LastEditedAt { get; set; } = DateTime.MinValue;
    public string Header { get; set; } = string.Empty;
    public string Subheader { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public uint Color { get; set; } = uint.MaxValue;
    public uint AccentColor { get; set; } = 0x77999999;
    public DateTime? NoticeTime { get; set; } = null;
    public string IpcData { get; set; } = string.Empty;
}
