using MessagePack;

namespace SundouleiaAPI.Files;

/// <summary>
///     Used when accessing data about a SMAB file we do not know the ID of.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SMABFileAccess(string FileDataHash)
{
    public string Password { get; set; } = string.Empty;
}
