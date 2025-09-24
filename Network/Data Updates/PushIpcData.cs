using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Flags;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcFull(List<UserData> Recipients, CharaModData ModData, CharaIpcData IpcData);

public record PushIpcMods(List<UserData> Recipients, CharaModData ModData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcOther(List<UserData> Recipients, CharaIpcData IpcData);

// Sends a single IPC update to all pairs. This update cannot be a mod update.
[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcSingle(List<UserData> Recipients, IpcKind Type, string NewData)
{
    public override string ToString() => $"To ({Recipients.Count}) recipients, Type: {Type}";
}
