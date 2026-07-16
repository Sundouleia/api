using MessagePack;
using SundouleiaAPI.Profiles;
using SundouleiaAPI.Sanctions;

namespace SundouleiaAPI.Profiles;

/// <summary> 
///   A SanctionedGroups full profile data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileData(SanctionData Sanction, SanctionProfileInfo Content, ProfileImages Images) : SanctionDto(Sanction);

/// <summary> All Data associated with the contents of a SanctionProfile, excluding image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileInfo(bool NsfwIcon, bool NsfwBanner, bool NsfwDesc, bool Verified, bool Flagged, string ContentJson)
{
    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static SanctionProfileInfo Empty { get; } = new(false, false, false, false, false, string.Empty);
}