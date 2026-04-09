using MessagePack;
using SundouleiaAPI.Chat;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Reporting;

/// <summary>
///     For when we need to report another user for misconduct of chat usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatReport(UserData User, ChatlogId Chatlog, string MessageId, string Reason) : UserDto(User);
