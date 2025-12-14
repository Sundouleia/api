using MessagePack;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record SMABExpireTime(Guid FileId, DateTime NewTimeUtc);