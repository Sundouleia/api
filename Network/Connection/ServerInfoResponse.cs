using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Server Info Response that provides the total online users.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ServerInfoResponse(int OnlineUsers);
