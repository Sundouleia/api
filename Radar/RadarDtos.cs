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
///   The compiled return result dto from a location update,
///   returning all members of each component we are in.
/// </summary>
/// <remarks> If a returned element is null, it means you could not join it. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record LocationUpdateResult
{
    public List<SanctionInfo>?      SanctionInfos   { get; set; } = null;
    public List<ChatlogMessage>?    ChatHistory     { get; set; } = null;
    public List<RadarMember>?       RadarUsers      { get; set; } = null;
    public List<RadarGroupMember>?  RadarGroupUsers { get; set; } = null;
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupJoin(UserData User, string HashedIdent, RadarGroupFlags Flags) : UserDto(User);

public interface IRadarSyncMember
{
    public UserData User { get; }
    public string HashedIdent { get; }
    public string RadarName { get; } // Maybe remove, idk.
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarMember(UserData User, string HashedIdent, RadarFlags Flags) : UserDto(User), IRadarSyncMember
{
    [IgnoreMember]
    public string RadarName => Flags.HasAny(RadarFlags.UseDisplayName) ? User.VanityOrAnonName : User.AnonName;
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarGroupMember(UserData User, string HashedIdent, RadarGroupFlags Flags) : UserDto(User), IRadarSyncMember
{
    public bool PausedByMe { get; set; } = false;
    public bool PausedByMember { get; set; } = false;

    [IgnoreMember]
    public bool IsPaused => PausedByMe || PausedByMember;

    [IgnoreMember]
    public string RadarName => Flags.HasAny(RadarGroupFlags.UseDisplayName) ? User.VanityOrAnonName : User.AnonName;
}

[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatMember(UserData User, RadarChatFlags Flags) : UserDto(User);