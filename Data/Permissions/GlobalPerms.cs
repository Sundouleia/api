using MessagePack;

namespace SundouleiaAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalPerms
{
    // Placeholder Setting.
    public bool DummySetting { get; set; } = false;
}
