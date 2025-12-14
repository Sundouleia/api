using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Sends the GUID's for the Sundesmo to apply from the Sundesmo's moodle list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleId(UserData Target, IEnumerable<Guid> Ids, bool IsPresets) : UserDto(Target);

/// <summary>
///     Sends a set of MoodleStatusInfo tuples to the target Sundesmo for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleStatus(UserData Target, IEnumerable<MoodlesStatusInfo> Statuses) : UserDto(Target);

/// <summary>
///     The Moodle GUID's that should be removed from the target Sundesmo.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveMoodleId(UserData Target, IEnumerable<Guid> Ids) : UserDto(Target);
