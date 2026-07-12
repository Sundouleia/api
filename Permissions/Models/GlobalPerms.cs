using MessagePack;
using SundouleiaAPI.Loci;

namespace SundouleiaAPI.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalPerms
{
    public bool DefaultFilterAnims      { get; set; } = false;
    public bool DefaultFilterSfx        { get; set; } = false;
    public bool DefaultFilterVfx        { get; set; } = false;
    public bool DefaultFilterSidekicks  { get; set; } = false;
    public bool DefaultFilterPets       { get; set; } = false;
    public bool DefaultFilterCompanions { get; set; } = false;

    public bool         DefaultShareLoci    { get; set; } = false;
    public LociAccess   DefaultLociAccess   { get; set; } = LociAccess.None;
    public TimeSpan     DefaultMaxLociTime  { get; set; } = TimeSpan.Zero;
}
