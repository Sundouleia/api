using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary> 
///     The User we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequest(UserData User, RequestDetails Details) : UserDto(User);

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
public record RequestDetails(bool IsTemp, string Message, ushort FromWorldId, ushort FromZoneId)
{
    // Could include in here, the preset of pairperms to be applied, if not applying Globals.
}

// Make request responce records here to include if we want to force permanent or temporary.
// Update in batches... take your time.
