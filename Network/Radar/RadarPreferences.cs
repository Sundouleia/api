using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Intended to update preferences for the current radar data. <para />
///     Used as a fallback for the hashedCID's. and also for additional 
///     options included in radar functionality. <para />
///     
///     RequestsAllowed is effectively determined by if <paramref name="HashedCID"/> is empty or not.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarState(bool UseChat, string HashedCID);
