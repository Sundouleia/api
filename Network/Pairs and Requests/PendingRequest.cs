using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     A pair request that is current pending a response from the recipient. <para />
///     Can be canceled by either side.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PendingRequest(UserData User, UserData Target, bool IsTemp, string Message, DateTime CreatedAt) : UserDto(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(3);
}
