using MessagePack;

namespace SundouleiaAPI.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record SMABFileKey(string Key);
