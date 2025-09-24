using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Flags;

namespace SundouleiaAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateFull(UserData User, CharaModData ModData, CharaIpcData IpcData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateMods(UserData User, CharaModData ModData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateOther(UserData User, CharaIpcData IpcData) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record IpcUpdateSingle(UserData User, IpcKind Type, string NewData) : UserDto(User);