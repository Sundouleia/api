using MessagePack;

namespace SundouleiaAPI.User;

/// <summary>
///   Allows anyone to update their alias! ^-^
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AliasUpdate(string NewAlias);

/// <summary>
///   Updates the display name and colors for a vanity user. <para/>
///   Changes are rejected if the sender is not a supporter.
/// </summary>
/// <remarks>
///   Vanity names can show in radar in place of Anon names,
///   as they aren't linked to pairing.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record VanityUpdate(string VanityName, uint NameColor, uint NameGlowColor);
