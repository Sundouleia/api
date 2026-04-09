using MessagePack;

namespace SundouleiaAPI.User;

[MessagePackObject(keyAsPropertyName: true)]
public record BlockedUser(UserData User, DateTime BlockedAtUTC) : UserDto(User);

