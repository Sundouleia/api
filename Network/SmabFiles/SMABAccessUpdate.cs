using MessagePack;

namespace SundouleiaAPI.Network;

// Valid for both allowance updates.
[MessagePackObject(keyAsPropertyName: true)]
public record SMABAccessUpdate(Guid FileId, List<string> ToAdd, List<string> ToRemove);