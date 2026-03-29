using MessagePack;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record SMABFileKey(string Key);
