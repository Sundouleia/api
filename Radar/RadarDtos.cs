using MessagePack;
using SundouleiaAPI.Chat;
using SundouleiaAPI.Data;
using SundouleiaAPI.Location;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Radar;

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
    public List<LoggedRadarChatMessage> ChatHistory     { get; set; } = [];
    public List<RadarMember>            RadarUsers      { get; set; } = [];
    public List<RadarGroupMember>       RadarGroupUsers { get; set; } = [];
    public List<SanctionInfo>           SanctionInfos   { get; set; } = [];
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarMember(UserData User, string HashedIdent, RadarFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupJoin(UserData User, string HashedIdent, RadarGroupFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupMember(UserData User, string HashedIdent, RadarGroupFlags Flags) : UserDto(User)
{
    public bool PausedByMe { get; set; } = false;
    public bool PausedByMember { get; set; } = false;

    [IgnoreMember]
    public bool IsPaused => PausedByMe || PausedByMember;
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatMember(UserData User, RadarChatFlags Flags) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record ReceivedChatMessage(ChatlogMessage Message);

[MessagePackObject(keyAsPropertyName: true)]
public record LoggedRadarChatMessage(string ChatId, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, RadarChatFlags Permissions);