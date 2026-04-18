using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Permissions;

/// <summary>
///     Updates one GlobalPermission value.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChangeGlobalPerm(UserData User, string PermName, object NewValue) : UserDto(User)
{
    public override string ToString() => $"PairGlobalPermChanged: {{{User.AliasOrUID}}} Changed -> [{PermName}] to [{NewValue}]";
}
