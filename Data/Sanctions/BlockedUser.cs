using MessagePack;
using SundouleiaAPI.Network;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record BlockedUser(UserData User, DateTime BlockedAtUTC) : UserDto(User);

