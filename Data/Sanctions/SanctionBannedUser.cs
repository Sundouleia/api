using MessagePack;
using SundouleiaAPI.Network;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBannedUser(UserData User, UserData BannedBy, DateTime BannedAt, string BanReason) : UserDto(User);

