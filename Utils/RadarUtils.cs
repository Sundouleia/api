using SundouleiaAPI.Data;
using SundouleiaAPI.Location;
using System.Collections.ObjectModel;

namespace SundouleiaAPI;
#nullable enable
public static class RadarUtils
{
    public static readonly IReadOnlyList<PlaceRegionData> PlaceData =
    [
        new(22,   "La Noscea",            134,  "Middle La Noscea"),
        new(22,   "La Noscea",            135,  "Lower La Noscea"),
        new(22,   "La Noscea",            137,  "Eastern La Noscea"),
        new(22,   "La Noscea",            138,  "Western La Noscea"),
        new(22,   "La Noscea",            139,  "Upper La Noscea"),
        new(22,   "La Noscea",            180,  "Outer La Noscea"),
        new(22,   "La Noscea",            250,  "Wolves' Den Pier"),
        new(23,   "The Black Shroud",     148,  "Central Shroud"),
        new(23,   "The Black Shroud",     152,  "East Shroud"),
        new(23,   "The Black Shroud",     153,  "South Shroud"),
        new(23,   "The Black Shroud",     154,  "North Shroud"),
        new(24,   "Thanalan",             140,  "Western Thanalan"),
        new(24,   "Thanalan",             141,  "Central Thanalan"),
        new(24,   "Thanalan",             145,  "Eastern Thanalan"),
        new(24,   "Thanalan",             146,  "Southern Thanalan"),
        new(24,   "Thanalan",             147,  "Northern Thanalan"),
        new(25,   "Coerthas",             155,  "Coerthas Central Highlands"),
        new(25,   "Coerthas",             397,  "Coerthas Western Highlands"),
        new(26,   "Mor Dhona",            156,  "Mor Dhona"),
        new(497,  "Abalathia's Spine",    401,  "The Sea of Clouds"),
        new(497,  "Abalathia's Spine",    402,  "Azys Lla"),
        new(498,  "Dravania",             398,  "The Dravanian Forelands"),
        new(498,  "Dravania",             399,  "The Dravanian Hinterlands"),
        new(498,  "Dravania",             400,  "The Churning Mists"),
        new(2400, "Gyr Abania",           612,  "The Fringes"),
        new(2400, "Gyr Abania",           620,  "The Peaks"),
        new(2400, "Gyr Abania",           621,  "The Lochs"),
        new(2401, "Othard",               613,  "The Ruby Sea"),
        new(2401, "Othard",               614,  "Yanxia"),
        new(2401, "Othard",               622,  "The Azim Steppe"),
        new(2950, "Norvrandt",            813,  "Lakeland"),
        new(2950, "Norvrandt",            814,  "Kholusia"),
        new(2950, "Norvrandt",            815,  "Amh Araeng"),
        new(2950, "Norvrandt",            816,  "Il Mheg"),
        new(2950, "Norvrandt",            817,  "The Rak'tika Greatwood"),
        new(2950, "Norvrandt",            818,  "The Tempest"),
        new(3702, "The Northern Empty",   956,  "Labyrinthos"),
        new(3703, "Ilsabard",             957,  "Thavnair"),
        new(3703, "Ilsabard",             958,  "Garlemald"),
        new(3704, "The Sea of Stars",     959,  "Mare Lamentorum"),
        new(3704, "The Sea of Stars",     960,  "Ultima Thule"),
        new(3705, "The World Unsundered", 961,  "Elpis"),
        new(4500, "Yok Tural",            1187, "Urqopacha"),
        new(4500, "Yok Tural",            1188, "Kozama'uka"),
        new(4500, "Yok Tural",            1189, "Yak T'el"),
        new(4501, "Xak Tural",            1190, "Shaaloani"),
        new(4501, "Xak Tural",            1191, "Heritage Found"),
        new(4502, "Unlost World",         1192, "Living Memory"),
    ];

    /// <summary>
    ///   Static readonly lookup keyed by the territory ID.
    /// </summary>
    public static IReadOnlyDictionary<ushort, PlaceRegionData> PlaceDataLookup { get; }
        = new ReadOnlyDictionary<ushort, PlaceRegionData>(PlaceData.ToDictionary(t => t.TerritoryId));

    /// <summary>
    ///   Should be using to ensure that a radar group cannot exist in housing zones! (May be missing exterior housing areas)
    /// </summary>
    public static readonly IReadOnlySet<ushort> HousingAreas = new HashSet<ushort>
    {
        282, 283, 284, 342, 343, 344, 345, 346, 347, 384, 385, 386, 649, 650, 651, 652, 980, 982, 983, // Houses
        608, 609, 610, 655, 999, // Apartments
    };

    /// <summary>
    ///   Helper to indicate which intended uses are forbidden in radar chat.
    /// </summary>
    public static readonly IReadOnlySet<XivIntendedUse> ForbiddenInChat = new HashSet<XivIntendedUse>()
    {
        // IntendedUse.Town, <-- Maybe uncomment later if nessisary.
        XivIntendedUse.MordionGaol,
        XivIntendedUse.HousingIndoor,
        XivIntendedUse.Frontline,
        XivIntendedUse.CrystallineConflict,
        XivIntendedUse.RivalWings,
    };

    /// <summary>
    ///   Allow normal pairing over radar anywhere
    /// </summary>
    public static string RadarPublicKey(this LocationMeta loc)
        => loc.IsIndoors
        ? $"{loc.WorldId}_{loc.TerritoryId}_{loc.WardId}_{loc.PlotOrDivisionId}_{loc.RoomId}"
        : $"{loc.WorldId}_{loc.TerritoryId}_{loc.WardId}";

    /// <summary>
    ///   Bar housing
    /// </summary>
    public static string? RadarGroupKey(this LocationMeta loc)
    {
        // If the location is in a housing area, we should forbid RadarGroup presence.
        if (HousingAreas.Contains(loc.TerritoryId))
            return null;

        if ((XivIntendedUse)loc.IntendedUseId is XivIntendedUse.HousingOutdoor or XivIntendedUse.HousingIndoor)
            return null;

        return $"{loc.WorldId}_{loc.TerritoryId}";
    }

    public static bool IsValidRadarGroupArea(this LocationMeta loc)
        => loc.RadarGroupKey() is not null;

    /// <summary>
    ///   Gets the ChatlogID of the current location for a RadarChat identifier
    /// </summary>
    public static string? RadarChatKey(this LocationMeta loc)
    {
        var use = (XivIntendedUse)loc.IntendedUseId;
        // Under no condition should chat be accessible in restricted areas.
        // I do not want to be known as the person that allowed for open chat in pvp areas... lol.
        if (ForbiddenInChat.Contains(use))
            return null;

        return use switch
        {
            XivIntendedUse.Overworld => PlaceDataLookup.TryGetValue(loc.TerritoryId, out var placeData)
               ? $"{loc.DataCenterId}_{placeData.RegionName}" : null,
            _ => $"{loc.DataCenterId}_{use.ToDisplayName().Replace(' ', '_')}",
        };
    }

    public static string? RadarChatLabel(this LocationMeta loc)
    {
        var use = (XivIntendedUse)loc.IntendedUseId;
        if (ForbiddenInChat.Contains(use))
            return null;

        return use switch
        {
            XivIntendedUse.Overworld => PlaceDataLookup.TryGetValue(loc.TerritoryId, out var pd) ? pd.RegionName : null, 
            _ => use.ToDisplayName(),
        };
    }

    // Refer to FFXIVClientStructs HouseId on how to mimic parsing.
    public static string GetSanctionName(ulong houseId)
    {
        if (houseId == 0)
            return "Sanctioned Group";

        // Extract Data2 (ushort at offset 2 = bits 16-31)
        ushort data2 = (ushort)((houseId >> 16) & 0xFFFF);
        // WardIndex = bits 0-5
        byte wardIndex = (byte)(data2 & 0x3F); // 0b0011_1111
        // RoomNumber = bits 6-15
        int roomNumber = (data2 >> 6) & 0x3FF; // 10 bits
        // Extract first byte for Unit info (offset 0)
        byte unitByte = (byte)(houseId & 0xFF);
        // Determine apartment vs plot
        bool isApartment = (unitByte & 0b0000_0001) != 0;
        // PlotIndex for homes
        byte plotIndex = (byte)((unitByte >> 1) & 0x7F); // remaining 7 bits?

        if (isApartment)
            return $"Sanctioned Room {roomNumber}";
        else
            return $"Sanctioned Plot W{wardIndex + 1}P{plotIndex + 1}";
    }
}
#nullable disable