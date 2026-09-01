using MessagePack;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Requests;

[MessagePackObject(keyAsPropertyName: true)]
public record ActiveRequests(List<PairRequest> PairRequests, List<SanctionInquiry> SanctionRequests);

#region PairRequests
/// <summary> 
///   The User we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequest(UserData User, RequestDetails Details) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequests(List<UserData> Recipients, RequestDetails Details);

/// <summary>
///   A pair request that is current pending a response from the recipient.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PairRequest(UserData User, UserData Target, RequestDetails Details, DateTime CreatedAt) : UserDto(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(3);
}

/// <summary>
///   Various details about a request. Useful for filtering requests and such.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestDetails(bool IsTemp, string Message, ushort FromWorldId, ushort FromZoneId);

/// <summary>
///   Very basic request response packet. Includes if the responder desires 
///   to forcibly accept the request as temporary, or permanent.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponse(UserData User, bool AsTemp) : UserDto(User);

/// <summary>
///   List variant of <see cref="RequestResponse"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponses(List<RequestResponse> Responces);
#endregion

#region SanctionRequests
[MessagePackObject(keyAsPropertyName: true)]
public record CreateSanctionInquiry(UserData Target, RequestKind Kind, string SID, string TargetSID) : UserDto(Target);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionInquiry(UserData User, UserData Target, RequestKind Kind, string SID, string TargetSID, DateTime CreatedAt) : UserDto(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(1) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(1);
}

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionInquiryReply(UserData User, UserData Target, RequestKind Kind, string SID, string TargetSID, bool Accepted) : UserDto(User)
{
    public SanctionDataFull? TargetFullData { get; set; } = null;
}
#endregion


