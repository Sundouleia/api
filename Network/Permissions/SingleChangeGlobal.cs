using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates one GlobalPermission value.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeGlobal(UserData User, string PermName, object NewValue) : UserDto(User)
{
    public override string ToString() => $"PairGlobalPermChanged: {{{User.AliasOrUID}}} Changed -> [{PermName}] to [{NewValue}]";
}
