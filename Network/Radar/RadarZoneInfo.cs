using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Provides initial data of the current active users in your Radar territory. <para />
///     Only used in callbacks from the server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarZoneInfo(List<OnlineUser> CurrentUsers);
