using MessagePack;
using SundouleiaAPI.Loci;

namespace SundouleiaAPI.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalPerms
{
    public bool         DefaultAllowAnimations  { get; set; } = true;
    public bool         DefaultAllowSounds      { get; set; } = true;
    public bool         DefaultAllowVfx         { get; set; } = true;
    
    public LociAccess   DefaultLociAccess       { get; set; } = LociAccess.None;
    public TimeSpan     DefaultMaxLociTime      { get; set; } = TimeSpan.Zero;
    public bool         DefaultShareOwnLociData { get; set; } = false;
}
