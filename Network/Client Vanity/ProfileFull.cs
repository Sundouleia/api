using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Holds both <paramref name="User"/>'s Profile content, 
///     but also the avatar image with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileData(UserData User, ProfileContent Info, string? Base64Image) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileData(SanctionData Sanction, SanctionProfileContent Content, SanctionProfileImages Images) : SanctionDto(Sanction);