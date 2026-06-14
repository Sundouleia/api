using MessagePack;
using SundouleiaAPI.Loci;
using SundouleiaAPI.Locis;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Alterations;

[MessagePackObject(keyAsPropertyName: true)]
public record IpcDeltas(UserData User, NewModDeltas ModDeltas, VisualDeltas VisualDeltas, bool InitData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcModDeltas(UserData User, ModDeltas ModDeltas, string ManipString) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcVisualDeltas(UserData User, VisualDeltas Deltas) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcVisualDeltaSingle(UserData User, OwnedObject ObjType, IpcKind Type, string NewData) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record LociDataUpdate(UserData User, LociContainerData Data) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusesUpdate(UserData User, List<LociStatusStruct> Statuses) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetsUpdate(UserData User, List<LociPresetStruct> Presets) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusModified(UserData User, LociStatusStruct Status, bool Deleted) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetModified(UserData User, LociPresetStruct Preset, bool Deleted) : UserDto(User);