using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Profiles;

/// <summary> A Users full profile data </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileData(UserData User, UserProfileInfo Info, UserProfileImage Image) : UserDto(User);

/// <summary> The contents of a users profile, excluding the image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileInfo(bool NsfwPicture, bool NsfwDescription, bool Flagged, string ContentJson)
{
    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static UserProfileInfo Empty { get; } = new(false, false, false, string.Empty);
}

/// <summary> The base64 imagedata for a users profile. (Move to R2 when possible! </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileImage(string Base64Image = "");