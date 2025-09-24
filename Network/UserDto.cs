using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);
