namespace SundouleiaAPI.Location;

/// <summary>
///   Stores a struct of information in relation to a TerritoryId.
/// </summary>
/// <param name="Id"> The Territories PlaceRegionID </param>
/// <param name="RegionName"> The Territories PlaceRegion Name </param>
/// <param name="TerritoryId"> The TerritoryID </param>
/// <param name="TerritoryName"> The name of that Territory </param>
public readonly record struct PlaceRegionData(ushort Id, string RegionName, ushort TerritoryId, string TerritoryName);