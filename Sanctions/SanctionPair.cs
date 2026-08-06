using MessagePack;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairDto(SanctionData Sanction, UserData User) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairsDto(SanctionData Sanction, List<UserData> Users) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairFullDto(SanctionData Sanction, SanctionPairInfo Info) : SanctionPairDto(Sanction, Info.User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairInfo(UserData User, DateTime JoinedAt) : UserDto(User)
{
    public bool InSync { get; set; } = false;
    public bool InChat { get; set; } = false;
    public HashSet<string> RoleIds { get; set; } = [];
    public SanctionAccess Access { get; set; } = SanctionAccess.None;
    public DateTime MutedUntil { get; set; } = DateTime.MinValue;
}