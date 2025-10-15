using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Provides initial data of the current active users in your Radar territory. <para />
///     Only used in callbacks from the server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarZoneInfo(List<RadarUserInfo> CurrentUsers);

/// <summary>
///     The Radar User's OnlineUser data, and their preferences / state.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarUserInfo(OnlineUser OnlineUser, RadarState State);
