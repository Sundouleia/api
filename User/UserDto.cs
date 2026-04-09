using MessagePack;

namespace SundouleiaAPI.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);

[MessagePackObject(keyAsPropertyName: true)]
public record UserListDto(List<UserData> Users);