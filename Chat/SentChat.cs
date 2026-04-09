using MessagePack;
using SundouleiaAPI.Radar;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Chat;

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

