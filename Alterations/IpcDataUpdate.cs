using MessagePack;
using System.Text;

namespace SundouleiaAPI.Alterations;

[MessagePackObject(keyAsPropertyName: true)]
public record VisualDeltas(List<VisualDeltaEntry> Deltas);

[MessagePackObject(keyAsPropertyName: true)]
public record VisualDeltaEntry(OwnedObject ObjType, IpcKind Type, string NewData);