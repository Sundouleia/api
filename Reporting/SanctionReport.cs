using MessagePack;
using SundouleiaAPI.Sanctions;

namespace SundouleiaAPI.Reporting;

/// <summary>
///     For when we need to report another user for misconduct of chat usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionReport(SanctionData Sanction, string Reason) : SanctionDto(Sanction);
