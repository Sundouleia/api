using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Chat;

/// <summary>
///   The Chatlog Identifier, and the type of chat it's for.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogId(SundChatKind Kind, string ChatId);

/// <summary>
///   The message stored in the database, holding nessisary information, regardless of type.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogMessage(ChatlogId Chatlog, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, string? TargetUid = null);

