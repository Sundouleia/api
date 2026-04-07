using MessagePack;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBanDto(SanctionData Sanction, UserData User, string BanReason) : SanctionPairDto(Sanction, User);

