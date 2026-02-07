using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary> 
///     The User we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequest(UserData User, RequestDetails Details) : UserDto(User);

// For bulk sending.
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequests(List<UserData> Recipients, RequestDetails Details);

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

/// <summary>
///     Very basic request response packet. Includes if the responder desires 
///     to forcibly accept the request as temporary, or permanent.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponse(UserData User, bool AsTemp) : UserDto(User);

/// <summary>
///     List variant of <see cref="RequestResponse"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponses(List<RequestResponse> Responces);


