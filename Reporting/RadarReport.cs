using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Reporting;

/// <summary>
///   Used to report a user in a RadarGroup for misconduct.
/// </summary>
/// <remarks> May revise later. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarReport(UserData User, ushort WorldId, ushort TerritoryId, string Reason) : UserDto(User);
