using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     A pair request that is current pending a response from the recipient. <para />
///     Can be canceled by either side.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SundesmoRequest(UserData User, UserData Target, RequestDetails Details, DateTime CreatedAt) : UserDto(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(3);
}

/// <summary>
///     Various details about a request. Useful for filtering requests and such.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestDetails(bool IsTemp, string PreferredNick, string Message, ushort FromWorldId, ushort FromZoneId);
