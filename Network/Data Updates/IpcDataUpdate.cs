using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateFull(UserData User, NewModUpdates ModData, VisualUpdate IpcData, bool IsInitialData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateMods(UserData User, NewModUpdates ModData, string ManipString) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateOther(UserData User, VisualUpdate IpcData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateSingle(UserData User, OwnedObject ObjType, IpcKind Type, string NewData) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record LociDataUpdate(UserData User, LociData Data) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusesUpdate(UserData User, List<LociStatusInfo> Statuses) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetsUpdate(UserData User, List<LociPresetInfo> Presets) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusModified(UserData User, LociStatusInfo Status, bool Deleted) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetModified(UserData User, LociPresetInfo Preset, bool Deleted) : UserDto(User);