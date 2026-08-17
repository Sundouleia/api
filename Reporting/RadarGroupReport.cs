using MessagePack;
using SundouleiaAPI.Alterations;
using SundouleiaAPI.Data;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Reporting;

/// <summary>
///   Used to report a user in a RadarGroup for misconduct.
/// </summary>
/// <remarks> May revise later. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupReport(UserData User, LocationMeta Location, string RadarId, string Reason) : UserDto(User)
{
    public List<ValidModFileDto> ModsSnapshot { get; set; } = [];
    public List<VisualDeltaEntry> AppearanceSnapshot { get; set; } = [];
    public ValidModFileDto? Suspect { get; set; }
}
