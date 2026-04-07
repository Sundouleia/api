using MessagePack;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionVisibilityDto(SanctionData Sanction, bool IsPublic) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPreferencesDto(SanctionData Sanction, bool Animations, bool Sounds, bool Vfx) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionPasswordDto(SanctionData Sanction, string NewPassword) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionNamesDto(SanctionData Sanction, string NewSanctionName, string NewChatlogId) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionStyleDto(SanctionData Sanction, SanctionStyle Style) : SanctionDto(Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionUserAccessDto(SanctionData Sanction, UserData User, SanctionAccess Access) : SanctionPairDto(Sanction, User);