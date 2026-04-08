using MessagePack;

namespace SundouleiaAPI.Data;

// Helper to mimic behavior of parsed HouseId from FFXIVClientStructs, designed for SanctionedGroups.
public readonly struct SanctionHouseId : IEquatable<SanctionHouseId>
{
    private readonly ulong _houseId;

    // Constructor from components
    public SanctionHouseId(ushort worldId, ushort territoryId, byte wardIdx, byte plotIdx, byte apartmentDiv, short roomId, bool isApartment)
    {
        ulong houseId = 0;

        // Byte 0: Apartment flag + plot / division index
        byte unitByte = isApartment ? (byte)(0x80 | (apartmentDiv & 0x7F)) : (byte)(plotIdx & 0x7F);
        houseId |= unitByte;

        // Byte 1: unknown (0)
        houseId |= 0UL << 8;

        // Data2: WardIndex (6 bits) + RoomNumber (10 bits)
        ushort data2 = (ushort)(((roomId & 0x3FF) << 6) | (wardIdx & 0x3F));
        houseId |= ((ulong)data2) << 16;

        // TerritoryTypeId (ushort)
        houseId |= ((ulong)territoryId) << 32;

        // WorldId (ushort)
        houseId |= ((ulong)worldId) << 48;

        _houseId = houseId;
    }

    // Constructor from ulong
    public SanctionHouseId(ulong houseId)
    {
        _houseId = houseId;
    }

    public ulong RawId => _houseId;

    public ushort WorldId => (ushort)(_houseId >> 48);
    public ushort TerritoryId => (ushort)((_houseId >> 32) & 0xFFFF);
    public byte WardIndex => (byte)((_houseId >> 16) & 0x3F);
    public ushort RoomNumber => (ushort)((_houseId >> 22) & 0x3FF);

    public byte UnitByte => (byte)(_houseId & 0xFF);
    public bool IsApartment => (UnitByte & 0x80) != 0;
    public byte ApartmentDivision => IsApartment ? (byte)(UnitByte & 0x7F) : (byte)0;
    public byte PlotIndex => IsApartment ? (byte)0 : (byte)(UnitByte & 0x7F);

    /// <summary>
    /// Generates a location ID for sanctioned plot/workshop checks.
    /// Keeps apartment info intact, masks room only for non-apartments.
    /// </summary>
    public ulong SanctionLocId
    {
        get
        {
            if (IsApartment)
                return _houseId; // keep apartment division & room
            else
            {
                // Mask room number (10 bits at bit 22)
                ulong mask = ~((ulong)0x3FF << 22);
                return _houseId & mask;
            }
        }
    }

    /// <summary>
    /// Checks if two locations match, ignoring room if allowed (SanctionLoc logic)
    /// </summary>
    public bool Matches(SanctionHouseId other, bool ignoreRoomForNonApartments = true)
    {
        if (!ignoreRoomForNonApartments)
            return _houseId == other._houseId;

        // Compare based on SanctionLocId logic
        if (IsApartment || other.IsApartment)
            return _houseId == other._houseId; // apartments always exact match
        return SanctionLocId == other.SanctionLocId;
    }

    // Equality
    public bool Equals(SanctionHouseId other) => _houseId == other._houseId;
    public override bool Equals(object? obj) => obj is SanctionHouseId other && Equals(other);
    public override int GetHashCode() => _houseId.GetHashCode();
    public static bool operator ==(SanctionHouseId left, SanctionHouseId right) => left.Equals(right);
    public static bool operator !=(SanctionHouseId left, SanctionHouseId right) => !(left == right);

    public override string ToString()
    {
        return $"World:{WorldId} Territory:{TerritoryId} Ward:{WardIndex} " +
               $"{(IsApartment ? $"AptDiv:{ApartmentDivision}" : $"Plot:{PlotIndex}")} " +
               $"Room:{RoomNumber} IsApartment:{IsApartment}";
    }
}


/// <summary>
///   Used to store and transmit the metadata information related to ones location data.
/// </summary>
/// <remarks> Update this overtime possibly. Don't really like its structure. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record struct LocationMeta
{
    public byte   DataCenterId     { get; set; }
    public ushort WorldId          { get; set; }
    public ushort TerritoryId      { get; set; } // Missleading indoors
    public byte   IntendedUseId    { get; set; }
    public byte   WardId           { get; set; }
    public byte   PlotOrDivisionId { get; set; }
    public short  RoomId           { get; set; }
    public ulong  HouseId          { get; set; }
}

/// <summary>
///   Intended to optimize later.
///   Provided map data that can be mutated (but shouldnt be)
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record struct MapData(LocationMeta Location, uint MapId)
{
    public float PosX   { get; init; }
    public float PosY   { get; init; }
    public float PosZ   { get; init; }
    public float RotX   { get; init; }
    public float RotY   { get; init; }
    public float RotZ   { get; init; }
    public float RotW   { get; init; }
    public float ScaleX { get; init; }
    public float ScaleY { get; init; }
    public float ScaleZ { get; init; }
}