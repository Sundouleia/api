using SundouleiaAPI.Enums;
using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///     Effective Information about a user in a Sundouleia Radar.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RadarUser(UserData User, string HashedCID);
