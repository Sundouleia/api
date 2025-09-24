using SundouleiaAPI.Enums;
using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///     The primary record used to represent a Sundouleia user.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AccountReputation
{
    public bool IsVerified { get; set; } = false;
    public bool IsBanned { get; set; } = false;
    public int WarningStrikes { get; set; } = 0;

    public bool ProfileViewing { get; set; } = true;
    public int ProfileViewStrikes { get; set; } = 0;

    public bool ProfileEditing { get; set; } = true;
    public int ProfileEditStrikes { get; set; } = 0;

    public bool RadarUsage { get; set; } = true;
    public int RadarStrikes { get; set; } = 0;

    public bool ChatUsage { get; set; } = true;
    public int ChatStrikes { get; set; } = 0;
}
