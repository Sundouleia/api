using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates a single perm in the <paramref name="User"/>'s OtherPerms entry
///     from your list of pairs. <para />
///
///     Note that this will never be enacted by the client, so we can assume it is for OtherPerms. <para />
///     Should be able to reference GSpeaks code if we want to make this bi-directional though.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeUnique(UserData User, string PermName, object NewValue) : UserDto(User)
{
    public override string ToString() => $"SingleChangeUnique: Target -> {User.AliasOrUID}, Changed [{PermName}] to [{NewValue}]";
}
