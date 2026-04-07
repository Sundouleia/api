using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     For when we need to report another user for misconduct of chat usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionReport(SanctionData Sanction, string Reason) : SanctionDto(Sanction);
