using MessagePack;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRole(string RoleId, string Name, int Priority, uint Color, uint AccentColor, SanctionAccess Access);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesUpdate(SanctionData Sanction, List<SanctionRole> UpdatedRoles);
