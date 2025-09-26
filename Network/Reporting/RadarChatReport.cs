using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     For when we need to report another user for misconduct of profile usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatReport(UserData User, ushort TerritoryId, ushort WorldId, string ChatCompressed, string ReportReason) : UserDto(User)
{
    // These can be optionally set, if the report is made indoors.
    public bool IsIndoor { get; set; } = false;
    public byte ApartmentDivision { get; set; } = 0;
    public byte PlotIndex { get; set; } = 0;
    public byte WardIndex { get; set; } = 0;
    public byte RoomNumber { get; set; } = 0;
}
