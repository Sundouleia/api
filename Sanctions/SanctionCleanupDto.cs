using MessagePack;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionCleanupDto(SanctionData Sanction, List<UserData> ToRemove) : SanctionDto(Sanction);

