using MessagePack;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairDto(SanctionData Sanction, UserData User) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairsDto(SanctionData Sanction, List<UserData> Users) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairFullDto(SanctionData Sanction, UserData User, bool InChat, List<string> RoleIds, SanctionAccess Access, DateTime JoinedAt) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairRoles(SanctionData Sanction, UserData User, List<string> RoleIds) : SanctionPairDto(Sanction, User);

//[MessagePackObject(keyAsPropertyName: true)]
//public record SanctionPairInfo(UserData User, bool InChat, List<string> RoleIds, SanctionAccess Access, DateTime JoinedAt) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairInfo(UserData User, DateTime JoinedAt) : UserDto(User)
{
    public bool InChat { get; set; } = false;
    public HashSet<string> RoleIds { get; set; } = [];
    public SanctionAccess Access { get; set; } = SanctionAccess.None;
}