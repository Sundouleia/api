using MessagePack;

namespace SundouleiaAPI.Network;

// Valid for DataHash and Password updates.
[MessagePackObject(keyAsPropertyName: true)]
public record SMABDataUpdate(Guid FileId, string NewData);
