using MessagePack;

namespace SundouleiaAPI.Files;

[MessagePackObject(keyAsPropertyName: true)]
public record SMABExpireTime(Guid FileId, DateTime NewTimeUtc);