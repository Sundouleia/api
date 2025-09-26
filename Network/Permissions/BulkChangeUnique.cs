using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     The new pair permissions to be set for <paramref name="User"/>. <para />
///     Note that this will never be enacted by the client, so we can assume it is for OtherPerms. <para />
///     Should be able to reference GSpeaks code if we want to make this bi-directional though.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeUnique(UserData User, PairPerms NewPerms) : UserDto(User);
