using MessagePack;
using System.Runtime.CompilerServices;

namespace SundouleiaAPI.Location;

public enum EstateHouseType
{
    Apartment = 0,
    Small = 1,
    Medium = 2,
    Large = 3,
}

// Sanctions are only defined by their exterior location, and not their interior location.
// As such as can assume static territory id locations.
public static class SanctionHouseExtensions
{
    public static readonly IReadOnlyDictionary<ushort, HashSet<int>> MediumPlots = new Dictionary<ushort, HashSet<int>>
    {
        [979] = new HashSet<int> { 21, 18, 17, 8, 7, 2, 26 },
        [641] = new HashSet<int> { 28, 24, 19, 1, 8, 13, 15 },
        [341] = new HashSet<int> { 4, 6, 11, 12, 8, 25, 19 },
        [339] = new HashSet<int> { 1, 4, 6, 7, 14, 29, 30 },
        [340] = new HashSet<int> { 30, 27, 21, 5, 1, 16, 11 }
    };

    public static readonly IReadOnlyDictionary<ushort, HashSet<int>> LargePlots = new Dictionary<ushort, HashSet<int>>
    {
        [979] = new HashSet<int> { 22, 30, 12 },
        [641] = new HashSet<int> { 30, 16, 7 },
        [341] = new HashSet<int> { 5, 13, 30 },
        [339] = new HashSet<int> { 2, 5, 15 },
        [340] = new HashSet<int> { 28, 3, 6 }
    };

    public static EstateHouseType GetEstateType(this SanctionHouseId houseId)
    {
        if (houseId.IsApartment)
            return EstateHouseType.Apartment;
        if (MediumPlots.TryGetValue(houseId.TerritoryId, out var mp) && mp.Contains(houseId.PlotIndex + 1))
            return EstateHouseType.Medium;
        if (LargePlots.TryGetValue(houseId.TerritoryId, out var lp) && lp.Contains(houseId.PlotIndex + 1))
            return EstateHouseType.Large;
        return EstateHouseType.Small;
    }

    public static uint GetIconId(this SanctionHouseId houseId, bool isLocked)
    {
        if (houseId.IsApartment)
            return 60789;
        // Otherwise do a check based on lock type.
        return (houseId.GetEstateType(), isLocked) switch
        {
            (EstateHouseType.Small, true) => 60751,
            (EstateHouseType.Medium, true) => 60752,
            (EstateHouseType.Large, true) => 60753,
            (EstateHouseType.Small, false) => 60754,
            (EstateHouseType.Medium, false) => 60755,
            (EstateHouseType.Large, false) => 60756,
            _ => 60754
        };
    }
}

// Helper to mimic behavior of parsed HouseId from FFXIVClientStructs, designed for SanctionedGroups.
public struct SanctionHouseId : IEquatable<SanctionHouseId>, IComparable<SanctionHouseId>
{
    public ulong HouseId;

    /// <summary>
    ///   True when this represents a valid housing location.
    ///   ulong.MaxValue is reserved to mean "not in housing".
    /// </summary>
    public bool IsValid => HouseId != ulong.MaxValue;

    public SanctionHouseId(ulong houseId) => HouseId = houseId;

    // Should never use this?..
    public SanctionHouseId(ushort worldId, ushort territoryId, byte wardIdx, byte plotIdx, byte apartmentDiv, short roomId, bool isApartment)
    {
        ulong houseId = 0;
        // Byte 0: Apartment flag + plot OR apartment subdivision
        byte unitByte = isApartment ? (byte)(0x80 | (apartmentDiv & 0x7F)) : (byte)(plotIdx & 0x7F);
        houseId |= unitByte;
        // Byte 1: unused / reserved
        houseId |= 0UL << 8;
        // Data2: Ward (6 bits) + Room (10 bits)
        ushort data2 = (ushort)(((roomId & 0x3FF) << 6) | (wardIdx & 0x3F));
        houseId |= ((ulong)data2) << 16;
        // Territory (ushort)
        houseId |= ((ulong)territoryId) << 32;
        // World (ushort)
        houseId |= ((ulong)worldId) << 48;

        HouseId = houseId;
    }

    public static SanctionHouseId Invalid => new(ulong.MaxValue);

    #region Raw accessors
    public ushort WorldId => (ushort)(HouseId >> 48);
    public ushort TerritoryId => (ushort)((HouseId >> 32) & 0xFFFF);

    public byte WardIndex => (byte)((HouseId >> 16) & 0x3F);
    public short RoomNumber => (short)((HouseId >> 22) & 0x3FF);

    public byte UnitByte => (byte)(HouseId & 0xFF);
    public bool IsApartment => ((UnitByte & 0x80) != 0) && ApartmentDivision < 2;

    public byte ApartmentDivision => (byte)(UnitByte & 0x7F);
    public byte PlotIndex => IsApartment ? (byte)0 : (byte)(UnitByte & 0x7F);
    #endregion

    #region Sanction keys
    /// <summary> Ward-Level visibility key. Useful for viewing other sanctions in the ward. </summary>
    /// <remarks> Should only be used on ward updates, should not be used inside. </remarks>
    /// <returns> A key reflecting World + Territory(outside) + Ward </returns>
    public ulong WardSanctionKey
    {
        get
        {
            if (!IsValid)
                return ulong.MaxValue;

            return ((ulong)WorldId << 48) | ((ulong)TerritoryId << 32) | ((ulong)WardIndex << 16);
        }
    }

    /// <summary> Plot-level join key. Can use outside or in a housing plot / FC Chambers. </summary>
    /// <remarks> Only use when trying to join sanction call or inside estates / FC Chambers. </remarks>
    /// <returns> A Key reflecting World + Territory + Ward + Plot </returns>
    public ulong PlotJoinKey
    {
        get
        {
            if (!IsValid || IsApartment)
                return ulong.MaxValue;

            return WardSanctionKey | PlotIndex;
        }
    }

    /// <summary> Apartment join key to be used when inside apartments. </summary>
    /// <returns> A Key reflecting World + Territory + Ward + Subdivision + Room </returns>
    public ulong ApartmentJoinKey
    {
        get
        {
            if (!IsValid || !IsApartment)
                return ulong.MaxValue;

            return WardSanctionKey | ((ulong)ApartmentDivision << 8) | ((ushort)RoomNumber);
        }
    }

    /// <summary> Returns the correct join key for this location. </summary>
    public ulong JoinSanctionKey => IsApartment ? ApartmentJoinKey : PlotJoinKey;
    #endregion

    public string TerritoryName => TerritoryId switch
    {
        339 => "Mist",
        340 => "Lav. Beds",
        341 => "Goblet",
        641 => "Shirogane",
        979 => "Empyreum",
        _ => "Unknown"
    };

    #region Matching logic
    public bool SharesWardWith(SanctionHouseId other)
    {
        if (!IsValid || !other.IsValid)
            return false;

        return WardSanctionKey == other.WardSanctionKey;
    }

    public bool CanJoinPlot(SanctionHouseId other)
    {
        if (!IsValid || !other.IsValid)
            return false;

        if (IsApartment || other.IsApartment)
            return false;

        return PlotJoinKey == other.PlotJoinKey;
    }

    public bool CanJoinApartment(SanctionHouseId other)
    {
        if (!IsValid || !other.IsValid)
            return false;

        if (!IsApartment || !other.IsApartment)
            return false;

        return ApartmentJoinKey == other.ApartmentJoinKey;
    }

    public bool CanJoinWith(SanctionHouseId other)
    {
        if (!IsValid || !other.IsValid)
            return false;

        if (IsApartment || other.IsApartment)
            return IsApartment && other.IsApartment && ApartmentJoinKey == other.ApartmentJoinKey;

        return PlotJoinKey == other.PlotJoinKey;
    }
    #endregion

    public static implicit operator ulong(SanctionHouseId id)
        => id.HouseId;

    public static implicit operator SanctionHouseId(ulong id)
        => new(id);

    public static bool operator ==(SanctionHouseId left, SanctionHouseId right)
        => left.HouseId == right.HouseId;

    public static bool operator !=(SanctionHouseId left, SanctionHouseId right)
        => left.HouseId != right.HouseId;

    public bool Equals(SanctionHouseId other)
        => HouseId == other.HouseId;

    public override bool Equals(object? obj)
        => obj is SanctionHouseId other && Equals(other);

    public override int GetHashCode()
        => HouseId.GetHashCode();

    public int CompareTo(SanctionHouseId other)
        => HouseId.CompareTo(other);

    public override string ToString()
    {
        if (!IsValid)
            return "Non-Housing Location";

        return $"World:{WorldId} Territory:{TerritoryId} Ward:{WardIndex} " +
               (IsApartment
                   ? $"Apartment Div:{ApartmentDivision} Room:{RoomNumber}"
                   : $"Plot:{PlotIndex}") +
               $" IsApartment:{IsApartment}";
    }
}