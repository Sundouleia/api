using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Permissions;

/// <summary>
///     Holds the new global permissions to be applied for <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChangeAllGlobal(UserData User, GlobalPerms NewPerms);
