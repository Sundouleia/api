using MessagePack;
using SundouleiaAPI.Chat;
using SundouleiaAPI.Data;
using SundouleiaAPI.Location;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionInfo(SanctionData Sanction, UserData Owner) : SanctionDto(Sanction)
{
    // The actual binding HouseID
    public SanctionHouseType HouseType { get; set; }
    public ulong HouseID { get; set; }

    // The HouseID used in the about and nearby tab. (Currently unused)
    public SanctionHouseType ShownHouseType { get; set; }
    public ulong ShownHouseID { get; set; }

    public bool IsVerified { get; set; } = false;
    public bool IsPublic { get; set; } = true;
    public bool MaskAddress { get; set; } = true;
    public bool AllowShownForAddress { get; set; } = false;
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

    // Failsafe verification check.
    public bool Verified() => IsVerified || HouseID == ShownHouseID;
}

[MessagePackObject(keyAsPropertyName: true)]
public record OwnedSanctionInfo(SanctionInfo Info, SanctionPairInfo? InitPairInfo = null) : SanctionDto(Info.Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleInfo(List<SanctionRoleData> Roles, List<string> OnJoin, string ReqSyncRole, string ReqChatRole);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionDataFull(
    SanctionInfo Info,
    SanctionRoleInfo Roles,
    List<SanctionPairInfo> Members,
    List<SanctionAlertData> Alerts,
    List<ChatlogMessage> Chat,
    Dictionary<string, string> Codes) : SanctionDto(Info.Sanction);