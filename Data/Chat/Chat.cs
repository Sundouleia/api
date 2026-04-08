using MessagePack;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Data;

/// <summary>
///   Helps identify what purpose the sent chat message serves.
/// </summary>
public enum SundChatKind
{
    Radar = 0,
    SanctionedGroup = 1,
    Direct = 2,
}

/// <summary>
///   The Chatlog Identifier, and the type of chat it's for.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogId(SundChatKind Kind, string ChatId);

/// <summary>
///   The contents of a radar chat message. <para />
///   Permissions are as-is at the time of sending, and 
///   should be updated when the users permissions update.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentRadarMessage(UserData Sender, string Message, RadarChatFlags Permissions);

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentSanctionMessage(string ChatId, UserData Sender, string Message);

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentDirectMessage(UserData Sender, UserData Target, string Message);

/// <summary>
///   The message stored in the database, holding nessisary information, regardless of type.
/// </summary>
/// <remarks> The <paramref name="TargetUid"/> is a placeholder incase this supports direct messages. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogMessage(ChatlogId Chatlog, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, string? TargetUid = null);

