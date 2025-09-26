using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates to our Radar table entry the zone which we are in and our hashed CID. <para />
///     
///     We can be inside of a Radar without a valid CID. This will prevent requests but 
///     allow us to use the chat, if we so desire.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarZoneUpdate(ushort WorldId, ushort TerritoryId, bool JoinChat, string HashedCID);
