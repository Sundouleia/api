using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates all Global Permissions for the <paramref name="User"/> to the new permissions.
/// </summary>
/// <remarks>
///     If used in a callback, the <paramref name="User"/> is <u>the User that made the change</u>,
///     if used in a server call, <paramref name="User"/> is <u>the target User to make the changes to</u>.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeGlobal(UserData User, GlobalPerms NewPerms);
