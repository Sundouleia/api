using MessagePack;

namespace SundouleiaAPI.Data;

// Data transfer that contains the links of uploaded mod file emplacements.
// Could manipulate this to contain files to add and remove, or a separate
// class for removals so we can send them instantly.
[MessagePackObject(keyAsPropertyName: true)]
public class CharaModData
{
    // TODO: Find format for this later.

    // Try to avoid doing a flag [all update] process.
    // Mod Data Changes & Removals.
    // Ideally if we can separate this enough a file emplacement removal
    // wouldn't even need to await the file uploads since it does not upload anything.
}
