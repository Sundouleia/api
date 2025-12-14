using MessagePack;
using SundouleiaAPI.Data;

namespace SundouleiaAPI.Network;

/// <summary>
///     Sends the GUID's for the Sundesmo to apply from the Sundesmo's moodle list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleId(UserData User, IEnumerable<Guid> Ids, bool IsPresets) : UserDto(User);

/// <summary>
///     Sends a set of MoodleStatusInfo tuples to the target Sundesmo for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleStatus(UserData User, IEnumerable<MoodlesStatusInfo> Statuses) : UserDto(User);

/// <summary>
///     The Moodle GUID's that should be removed from the target Sundesmo.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveMoodleId(UserData User, IEnumerable<Guid> Ids) : UserDto(User);
