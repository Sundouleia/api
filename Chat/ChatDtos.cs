using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Chat;

/// <summary>
///   The Chatlog Identifier, and the type of chat it's for.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogId(SundChatKind Kind, string ChatId)
{
    // Add support for DM's soon.
    public static readonly ChatlogId Invalid = new(SundChatKind.Direct, string.Empty);
}

/// <summary>
///   The message stored in the database, holding nessisary information, regardless of type.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogMessage(ChatlogId Chatlog, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, byte[] Contents)
{
    /// <summary> TargetId can refer to a SanctionSID, or the recipient UID of a DM. </summary>
    public string? TargetId { get; init; } = null;
    public ushort Flags { get; init; } = 0;
}

/// <summary>
///   The contents of a radar chat message. <para />
///   Permissions are as-is at the time of sending, and 
///   should be updated when the users permissions update.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentMessage(ChatlogId Id, UserData Sender, string Message, byte[] Contents)
{
    /// <summary> TargetId can refer to a SanctionSID, or the recipient UID of a DM. </summary>
    public string? TargetId { get; init; } = null;
    public ushort Flags { get; init; } = 0;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ChatHistoryRequest(ChatlogId Id, int total = 250, string? SanctionId = null);


