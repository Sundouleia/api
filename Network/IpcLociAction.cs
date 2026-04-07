using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Sends the GUID's for the Sundesmo to apply from the Sundesmo's LociStatusStruct list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyLociDataById(UserData User, IEnumerable<Guid> Ids, bool IsPresets) : UserDto(User);

/// <summary>
///     Sends a set of LociStatusStruct tuples to the target Sundesmo for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyLociStatus(UserData User, IEnumerable<LociStatusStruct> Statuses) : UserDto(User);

/// <summary>
///     The LociStatus GUID's that should be removed from the target Sundesmo.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveLociData(UserData User, IEnumerable<Guid> Ids) : UserDto(User);
