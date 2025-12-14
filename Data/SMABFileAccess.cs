using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Returned from a successful SMAB file access request.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SMABFileInfo(string DecodeKey, List<string> AllowedFileHashes);
