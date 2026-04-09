using MessagePack;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Data;

// A member of a sanction. May add more later, unsure.
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairInfo(UserData User, List<string> RoleIds, SanctionAccess Access, DateTime JoinedAt) : UserDto(User);