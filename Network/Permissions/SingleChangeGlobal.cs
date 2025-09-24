using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates one GlobalPermission value.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeGlobal(string PermName, object NewValue)
{
    public override string ToString() => $"SingleChangeGlobal: Changed -> [{PermName}] to [{NewValue}]";
}
