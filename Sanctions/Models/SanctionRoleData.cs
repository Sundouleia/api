using MessagePack;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleData(string RoleId, string Name, int Priority, int IconId, bool IsGameIcon, uint Color, uint AccentColor, SanctionAccess Access);