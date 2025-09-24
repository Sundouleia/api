using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Sent to the connected client in the process of verifying their account.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record VerificationCode(string Code = "");
