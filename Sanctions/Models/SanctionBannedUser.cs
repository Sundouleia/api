using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionBannedUser(UserData User, UserData BannedBy, DateTime BannedAt, string BanReason) : UserDto(User);

