using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data;

// Lightweight data transfer that can be sent fairly frequently.
public class CharaIpcData
{
    // Maybe split out of dictionary since we only have 4 items to scan.
    public Dictionary<OwnedObject, string> CPlusData { get; set; } = new();
    public Dictionary<OwnedObject, string> GlamourerState { get; set; } = new();
    public string ModManips { get; set; } = string.Empty;
    public string HeelsOffset { get; set; } = string.Empty;
    public string HonorificTitle { get; set; } = string.Empty;
    public string PetNicknames { get; set; } = string.Empty;

    // Could make this nullable and have update non-nulls for update logic,
    // but find out later.

    // Could do dataHashing comparisons or we could use some other method for comparison, if we find a better structure.
}
