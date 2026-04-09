using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Sanctions;

/// <summary>
///   The base data for a group. Note that the name is mutable and
///   will if cached should not be used for reliable name retrieval.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionData(string SID, string Name, DateTime ValidatedAt, DateTime CreatedAt)
{
    [IgnoreMember] 
    public string DisplayName => string.IsNullOrWhiteSpace(Name) ? SID : Name;
}

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionDto(SanctionData Sanction);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionDataFull(SanctionData Sanction, SanctionInfo Info, List<SanctionPairInfo> Members) : SanctionDto(Sanction);

/// <summary> 
///   A SanctionedGroups full profile data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileData(SanctionData Sanction, SanctionProfileContentData Content, SanctionProfileImageData Images) : SanctionDto(Sanction);