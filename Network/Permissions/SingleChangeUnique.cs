using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates a single unique permission on the callers PairPermissions for the specified <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeUnique(UserData User, string PermName, object NewValue) : UserDto(User)
{
    public override string ToString() => $"SingleChangeUnique: Target -> {User.AliasOrUID}, Changed [{PermName}] to [{NewValue}]";
}
