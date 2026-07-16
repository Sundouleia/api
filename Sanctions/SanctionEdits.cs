using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Profiles;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesUpdate(SanctionData Sanction, List<SanctionRoleData> Roles, Dictionary<string, SanctionAccess> UpdatedAccess) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesDto(SanctionData Sanction, List<SanctionRoleData> Roles) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertsDto(SanctionData Sanction, List<SanctionAlertData> Alerts) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionVisibilityDto(SanctionData Sanction, bool IsPublic) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPreferencesDto(SanctionData Sanction, bool Anims, bool Sfx, bool Vfx, bool SyncMinionMount, bool SyncPet, bool SyncBuddy) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileImagesDto(SanctionData Sanction, ProfileImages Images) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileContentDto(SanctionData Sanction, SanctionProfileInfo Content) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPasswordDto(SanctionData Sanction, string NewPassword) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionNamesDto(SanctionData Sanction, string NewSanctionName, string NewChatlogId) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionUserAccessDto(SanctionData Sanction, UserData User, SanctionAccess Access) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBanDto(SanctionData Sanction, UserData User, string BanReason) : SanctionPairDto(Sanction, User);

// User edits.
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleClaimDto(SanctionData Sanction, string RoleId, string ClaimCode) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionOptInPrefs(SanctionData Sanction, bool SyncUser, bool ChatUser) : SanctionDto(Sanction);
