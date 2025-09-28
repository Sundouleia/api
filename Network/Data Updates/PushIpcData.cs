using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcFull(List<UserData> Recipients, CharaModData ModData, ClientIpcData IpcData);

public record PushIpcMods(List<UserData> Recipients, CharaModData ModData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcOther(List<UserData> Recipients, ClientIpcData IpcData);

// Sends a single IPC update to all pairs. This update cannot be a mod update.
[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcSingle(List<UserData> Recipients, OwnedObject Object, IpcKind Kind, string NewData)
{
    public override string ToString() => $"To ({Recipients.Count}) recipients, Object: {Object} Type: {Kind}";
}
