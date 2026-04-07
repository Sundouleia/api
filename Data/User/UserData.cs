using SundouleiaAPI.Enums;
using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///   Reflects the main information of a Sundouleia user. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(
    string       UID,
    string?      Alias      = null,
    string?      VanityName = null,
    uint         Color      = 0xFFFFFFFF,
    uint         GlowColor  = 0x00000000,
    CkVanityTier Tier       = CkVanityTier.NoRole,
    DateTime?    CreatedOn  = null)
{
    [IgnoreMember] public string DisplayName => VanityName ?? Alias ?? UID;
    [IgnoreMember] public string AnonName => VanityName ?? "Anon.User-" + UID[^4..];
    [IgnoreMember] public string AnonTag => UID[^4..];
}
