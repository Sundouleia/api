using MessagePack;
using SundouleiaAPI.Radar;

namespace SundouleiaAPI.Data;

// Performed for the currently connected user, using their Redis-backed hashedId
[MessagePackObject(keyAsPropertyName: true)]
public record OwnedEstates(Dictionary<SanctionHouseType, ulong> Ownerships);