using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionRolesUpdate(SanctionData Sanction, List<SanctionRoleData> Roles, Dictionary<string, SanctionAccess> UpdatedAccess) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionVisibilityDto(SanctionData Sanction, bool IsPublic) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPreferencesDto(SanctionData Sanction, bool Animations, bool Sounds, bool Vfx) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileImagesDto(SanctionData Sanction, SanctionProfileImageData Images) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileContentDto(SanctionData Sanction, SanctionProfileContentData Content) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPasswordDto(SanctionData Sanction, string NewPassword) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionNamesDto(SanctionData Sanction, string NewSanctionName, string NewChatlogId) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionStyleDto(SanctionData Sanction, SanctionStyle Style) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionUserAccessDto(SanctionData Sanction, UserData User, SanctionAccess Access) : SanctionPairDto(Sanction, User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBanDto(SanctionData Sanction, UserData User, string BanReason) : SanctionPairDto(Sanction, User);