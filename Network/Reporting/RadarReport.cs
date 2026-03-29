using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///   Used to report a user in a RadarGroup for misconduct.
/// </summary>
/// <remarks> May revise later. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarReport(UserData User, ushort WorldId, ushort TerritoryId, string ReportReason) : UserDto(User);
