using MessagePack;

namespace SundouleiaAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record PairPerms
{
    public bool PauseVisuals    { get; set; } = false; // If all syncing should be paused with this person.

    // Maybe dont implement this until later if it becomes an issue.
    //public bool AllowCPlus      { get; set; } = true;  // if modded c+ should sync.
    //public bool AllowHeels      { get; set; } = true;  // if modded heels should sync.
    //public bool AllowTitles     { get; set; } = true;  // if modded titles should sync.
    //public bool AllowMoodles    { get; set; } = true;  // if modded moodles should sync.
    //public bool AllowPetNicks   { get; set; } = true;  // if modded pet nicknames should sync.

    public bool AllowAnimations { get; set; } = true;  // if modded animation should sync.
    public bool AllowSounds     { get; set; } = true;  // if modded sfx should should sync.
    public bool AllowVfx        { get; set; } = true;  // if modded vfx should should sync.
}
