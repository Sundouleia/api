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
    public string? Password { get; set; } = null;
    public string ChatlogId { get; set; } = string.Empty;

    public bool SuggestFilterAnims { get; set; } = false;
    public bool SuggestFilterSfx { get; set; } = false;
    public bool SuggestFilterVfx { get; set; } = false;
    public bool SuggestFilterSidekicks { get; set; } = false;
    public bool SuggestFilterPets { get; set; } = false;
    public bool SuggestFilterCompanions { get; set; } = false;

    public List<string> RolesOnJoin { get; set; } = [];
    public string RequiredSyncRole { get; set; } = string.Empty;
    public string RequiredChatRole { get; set; } = string.Empty;
    public List<SanctionRoleData> Roles { get; set; } = [];
}
