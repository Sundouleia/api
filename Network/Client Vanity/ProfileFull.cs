using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Holds both <paramref name="User"/>'s Profile content, 
///     but also the avatar image with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record FullProfileData(UserData User, ProfileContent Info, string? Base64Image) : UserDto(User);
