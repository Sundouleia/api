using MessagePack;
using SundouleiaAPI.Location;

namespace SundouleiaAPI.Sanctions;

// Performed for the currently connected user, using their Redis-backed hashedId
[MessagePackObject(keyAsPropertyName: true)]
public record OwnedEstates(Dictionary<SanctionHouseType, ulong> Ownerships);