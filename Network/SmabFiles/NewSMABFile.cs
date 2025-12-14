using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Sends the GUID's for the Sundesmo to apply from the Sundesmo's moodle list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record NewSMABFile(Guid FileId, string EncryptedFileHash, string FileKey)
{
    public DateTime     ExpireTime    { get; set; } = DateTime.MaxValue; // Default to last forever (Until cleanup).
    public string       Password      { get; set; } = string.Empty;
    public List<string> AllowedHashes { get; set; } = [];
    public List<string> AllowedUids   { get; set; } = [];
}
