using MessagePack;
using SundouleiaAPI.Location;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionInfo(SanctionData Sanction, UserData Owner) : SanctionDto(Sanction)
{
    public SanctionHouseType HouseType { get; set; }
    public ulong HouseID { get; set; }
    public bool IsPublic { get; set; } = true;
    public string ChatlogId { get; set; } = string.Empty;
    public SanctionStyle Style { get; set; } = new();
    public bool AllowAnimationsPreferred { get; set; } = true;
    public bool AllowSoundsPreferred { get; set; } = true;
    public bool AllowVfxPreferred { get; set; } = true;
    public List<SanctionRoleData> Roles { get; set; } = new();
}
