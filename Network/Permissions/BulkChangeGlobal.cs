using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Holds the new global permissions to be applied for <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeGlobal(UserData User, GlobalPerms NewPerms);
