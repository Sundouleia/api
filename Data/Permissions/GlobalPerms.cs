using MessagePack;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalPerms
{
    public bool         DefaultAllowAnimations  { get; set; } = false;
    public bool         DefaultAllowSounds      { get; set; } = false;
    public bool         DefaultAllowVfx         { get; set; } = false;

    public MoodleAccess DefaultMoodleAccess     { get; set; } = MoodleAccess.None;
    public TimeSpan     DefaultMaxMoodleTime    { get; set; } = TimeSpan.Zero;
    public bool         DefaultShareOwnMoodles  { get; set; } = false;
}
