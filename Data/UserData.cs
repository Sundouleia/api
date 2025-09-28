using SundouleiaAPI.Enums;
using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///     The primary record used to represent a Sundouleia user.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null, CkVanityTier? Tier = CkVanityTier.NoRole, DateTime? CreatedOn = null)
{
    [IgnoreMember] public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
    [IgnoreMember] public string AnonName => "Anon.User-" + UID[..4];
}
