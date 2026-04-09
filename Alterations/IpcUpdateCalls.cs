using MessagePack;
using SundouleiaAPI.Loci;
using SundouleiaAPI.Locis;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Alterations;

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcFull(List<UserData> Recipients, ModUpdates Mods, VisualUpdate Visuals, bool IsInitialData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcMods(List<UserData> Recipients, ModUpdates Mods, string ManipString);

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcOther(List<UserData> Recipients, VisualUpdate Visuals);

// Sends a single IPC update to all pairs. This update cannot be a mod update.
[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcSingle(List<UserData> Recipients, OwnedObject Object, IpcKind Kind, string NewData)
{
    public override string ToString() => $"To ({Recipients.Count}) recipients, Object: {Object} Type: {Kind}";
}

// Loci related Info updates

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociData(List<UserData> Recipients, LociContainerData Data);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociStatuses(List<UserData> Recipients, List<LociStatusStruct> Statuses);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociPresets(List<UserData> Recipients, List<LociPresetStruct> Presets);

[MessagePackObject(keyAsPropertyName: true)]
public record PushStatusModified(List<UserData> Recipients, LociStatusStruct Status, bool Deleted);

[MessagePackObject(keyAsPropertyName: true)]
public record PushPresetModified(List<UserData> Recipients, LociPresetStruct Preset, bool Deleted);
