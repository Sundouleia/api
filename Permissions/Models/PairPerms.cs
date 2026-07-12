using MessagePack;
using SundouleiaAPI.Loci;

namespace SundouleiaAPI.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record PairPerms
{
    public bool FilterAnimations { get; set; } = false;
    public bool FilterSfx        { get; set; } = false; 
    public bool FilterVfx        { get; set; } = false;
    public bool FilterSidekicks  { get; set; } = false;
    public bool FilterPets       { get; set; } = false;
    public bool FilterCompanions { get; set; } = false;

    public bool         ShareLoci   { get; set; } = false;
    public LociAccess   LociAccess  { get; set; } = LociAccess.None;
    public TimeSpan     MaxLociTime { get; set; } = TimeSpan.Zero;
}
