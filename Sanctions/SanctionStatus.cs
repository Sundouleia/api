using MessagePack;
using SundouleiaAPI.Chat;
using SundouleiaAPI.Connection;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionJoinDto(string SID, string Password);

public record SanctionOptInsResult(List<OnlineUser> Online, List<ChatlogMessage> Chat);

// Use elsewhere later when we do prune services.
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionCleanupDto(SanctionData Sanction, List<UserData> ToRemove) : SanctionDto(Sanction);

