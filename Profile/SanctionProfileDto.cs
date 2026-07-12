using MessagePack;
using SundouleiaAPI.Profiles;
using SundouleiaAPI.Sanctions;

namespace SundouleiaAPI.Profiles;

/// <summary> 
///   A SanctionedGroups full profile data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileData(SanctionData Sanction, SanctionProfileInfo Content, SanctionProfileImages Images) : SanctionDto(Sanction);

/// <summary> All Data associated with the contents of a SanctionProfile, excluding image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileInfo(bool NsfwLogo, bool NsfwBanner, bool Verified, bool Flagged, string ContentJson)
{
    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static SanctionProfileInfo Empty { get; } = new(false, false, false, false, string.Empty);
}

/// <summary> A SanctionedGroups profile image data. </summary>
[MessagePackObject(keyAsPropertyName: true)] // Maybe make nullable as a sign of what should update.
public record SanctionProfileImages(string Base64Logo = "", string Base64Banner = "");