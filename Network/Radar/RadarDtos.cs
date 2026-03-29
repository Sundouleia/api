using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Network;


/// <summary>
///   Updates your location to the server, and joins any location-based modules you have enabled.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record LocationUpdate(UserData User, LocationMeta Location, bool JoinChat, bool JoinRadar, bool JoinRadarGroup)
{
    public RadarChatFlags  ChatFlags    { get; set; } = RadarChatFlags.None;
    public RadarFlags      PublicFlags  { get; set; } = RadarFlags.None;
    public RadarGroupFlags GroupFlags   { get; set; } = RadarGroupFlags.None;
}

/// <summary>
///   The compiled return result dto from a location update, returning all members of each component we are in.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record LocationUpdateResult()
{
    public List<RadarMember>            RadarUsers      { get; set; } = [];
    public List<LoggedRadarChatMessage> ChatHistory     { get; set; } = [];
    public List<RadarGroupMember>       RadarGroupUsers { get; set; } = [];
}


[MessagePackObject(keyAsPropertyName: true)]
public record RadarMember(UserData User, string HashedIdent, RadarFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupMember(UserData User, string HashedIdent, RadarGroupFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatMember(UserData User, RadarChatFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record ReceivedChatMessage(ChatlogId Chatlog, UserData Sender, string Message) : UserDto(Sender);

[MessagePackObject(keyAsPropertyName: true)]
public record LoggedRadarChatMessage(string ChatId, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, RadarChatFlags Permissions);

[MessagePackObject(keyAsPropertyName: true)]
public record DirectChatMessage(UserData User, UserData Target, string Message, RadarChatFlags Permissions);