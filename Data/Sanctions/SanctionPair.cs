using MessagePack;
using SundouleiaAPI.Data.Permissions;
using SundouleiaAPI.Network;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairDto(SanctionData Sanction, UserData User) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairFullDto(SanctionData Sanction, UserData User, List<string> RoleIds, SanctionAccess Access, DateTime JoinedAt) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairPause(SanctionData Sanction, UserData User, bool PausedClient) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairRoles(SanctionData Sanction, UserData User, List<string> RoleIds) : SanctionPairDto(Sanction, User);

// A member of a sanction. May add more later, unsure.
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairInfo(UserData User, List<string> RoleIds, SanctionAccess Access, DateTime JoinedAt) : UserDto(User);