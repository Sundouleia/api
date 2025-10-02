using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateFull(UserData User, ModDataUpdate ModData, VisualDataUpdate IpcData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateMods(UserData User, ModDataUpdate ModData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateOther(UserData User, VisualDataUpdate IpcData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateSingle(UserData User, OwnedObject ObjType, IpcKind Type, string NewData) : UserDto(User);