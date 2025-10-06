using MessagePack;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SundouleiaAPI.Data;

// Just doing this to try and digest the file transfer process.
[MessagePackObject(keyAsPropertyName: true)]
public class PlaceholderLazyFileData
{
    public PlaceholderLazyFileData()
    {
        DataHash = new(() =>
        {
            var json = JsonSerializer.Serialize(this);
            using var cryptoProvider = SHA256.Create();
            return BitConverter.ToString(cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(json))).Replace("-", "", StringComparison.Ordinal);
        });
    }

    [JsonIgnore]
    public Lazy<string> DataHash { get; }
    public string FileSwapPath { get; set; } = string.Empty;
    public string[] GamePaths { get; set; } = Array.Empty<string>();
    public string Hash { get; set; } = string.Empty;
}