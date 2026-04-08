using MessagePack;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleData(string RoleId, string Name, int Priority, int IconId, bool IsGameIcon, uint Color, uint AccentColor, SanctionAccess Access);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesUpdate(SanctionData Sanction, List<SanctionRoleData> Roles, Dictionary<string, SanctionAccess> UpdatedAccess) : SanctionDto(Sanction);
