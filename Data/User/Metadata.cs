using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///   Used to store and transmit the metadata information related to ones location data.
/// </summary>
/// <remarks> Update this overtime possibly. Don't really like its structure. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record struct LocationMeta
{
    public byte   DataCenterId     { get; set; }
    public ushort WorldId          { get; set; }
    public ushort TerritoryId      { get; set; }
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