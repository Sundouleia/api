using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Profiles;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

// ChangeNames
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionNamesDto(SanctionData Sanction, string NewSanctionName, string NewChatlogId) : SanctionDto(Sanction);

// ChangeProfile
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileImages(SanctionData Sanction, ProfileImages Images) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileContents(SanctionData Sanction, SanctionProfileInfo Content) : SanctionDto(Sanction);

// ChangePreferences
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPreferencesDto(SanctionData Sanction, bool Anims, bool Sfx, bool Vfx, bool SyncMinionMount, bool SyncPet, bool SyncBuddy) : SanctionDto(Sanction);

// ChangeVisibility
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionVisibilityDto(SanctionData Sanction, bool IsPublic) : SanctionDto(Sanction);

// ChangePassword
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPasswordDto(SanctionData Sanction, string NewPassword) : SanctionDto(Sanction);

// Alerts
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertAddUpdateDto(SanctionData Sanction, SanctionAlertData Alert) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertRemovalDto(SanctionData Sanction, List<string> AlertIds) : SanctionDto(Sanction);


[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAlertsDto(SanctionData Sanction, List<SanctionAlertData> Alerts) : SanctionDto(Sanction);

// Chat
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionMuteDto(SanctionData Sanction, UserData Target, DateTime ExpireTime) : SanctionDto(Sanction);

// Roles
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleRequirementsDto(SanctionData Sanction, string[]? RoleIdsOnJoin, string? SyncRoleId, string? ChatRoleId) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesDto(SanctionData Sanction, List<SanctionRoleData> Roles) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairRolesDto(SanctionData Sanction, UserData User, List<string> RoleIds) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleForUsers(SanctionData Sanction, List<UserData> Users, string RoleId, bool Assigning) : SanctionPairsDto(Sanction, Users);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesUpdate(SanctionData Sanction, List<SanctionRoleData> Roles, Dictionary<string, SanctionAccess> UpdatedAccess) : SanctionDto(Sanction);

// Access
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPairAccessDto(SanctionData Sanction, UserData User, SanctionAccess Access) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAccessForUsers(SanctionData Sanction, List<UserData> Users, SanctionAccess Access, bool Assigning) : SanctionPairsDto(Sanction, Users);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBulkUpdate(SanctionData Sanction, Dictionary<string, string[]> UpdatedRoles, Dictionary<string, SanctionAccess> UpdatedAccess) : SanctionDto(Sanction);

// Banning
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBanDto(SanctionData Sanction, List<UserData> Users, string BanReason) : SanctionDto(Sanction);

// ---- Non-Management Calls ----
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRoleClaim(SanctionData Sanction, string RoleId, string ClaimCode) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionOptInPrefs(SanctionData Sanction, bool SyncUser, bool ChatUser) : SanctionDto(Sanction);
