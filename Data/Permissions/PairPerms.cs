using MessagePack;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record PairPerms
{
    public bool         PauseVisuals    { get; set; } = false; // If all syncing should be paused with this person.

    public bool         AllowAnimations { get; set; } = true;  // if modded animation should sync.
    public bool         AllowSounds     { get; set; } = true;  // if modded sfx should should sync.
    public bool         AllowVfx        { get; set; } = true;  // if modded vfx should should sync.

    public MoodleAccess MoodleAccess    { get; set; } = MoodleAccess.None;
    public TimeSpan     MaxMoodleTime   { get; set; } = TimeSpan.Zero;
    public bool         ShareOwnMoodles { get; set; } = false;
}
