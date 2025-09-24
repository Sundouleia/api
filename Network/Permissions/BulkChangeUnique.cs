using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates the PairPerms for the <paramref name="User"/> to their new values in bulk.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeUnique(UserData User, PairPerms NewPerms) : UserDto(User);
