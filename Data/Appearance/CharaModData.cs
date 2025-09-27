using MessagePack;

namespace SundouleiaAPI.Data;

// Data transfer that contains the links of uploaded mod file emplacements.
// Could manipulate this to contain files to add and remove, or a separate
// class for removals so we can send them instantly.
[MessagePackObject(keyAsPropertyName: true)]
public class CharaModData
{
    // Something on mods to add here with the game path and file replacement path or whatever.

    // Something with mods to remove and their game path and file replacement path.

    // The goal here is that mod data updates do not send all mods but rather the ones to be added and removed.
    // This helps improve performance and reduce cluster calls.

    // Try to avoid doing a flag [all update] process.
    // Mod Data Changes & Removals.
    // Ideally if we can separate this enough a file emplacement removal
    // wouldn't even need to await the file uploads since it does not upload anything.
}
