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