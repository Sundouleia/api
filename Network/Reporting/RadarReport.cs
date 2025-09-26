using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     For when we need to report another user for misconduct with the radar system. <para />
///     This variant is for potentially external actions unrelated to the area's chat.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarReport(ushort TerritoryId, ushort WorldId, string ReportReason)
{
    // These can be optionally set, if the report is made indoors.
    public bool IsIndoor { get; set; } = false;
    public byte ApartmentDivision { get; set; } = 0;
    public byte PlotIndex { get; set; } = 0;
    public byte WardIndex { get; set; } = 0;
    public byte RoomNumber { get; set; } = 0;
}
