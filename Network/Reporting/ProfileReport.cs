using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     For when we need to report another user for misconduct of profile usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ProfileReport(UserData User, string ReportReason) : UserDto(User);
