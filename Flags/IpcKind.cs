namespace SundouleiaAPI.Enums;

/// <summary>
///     What kinds of caches are in queue for processing. <para />
///     Arranged in the order we want to delay things by.
/// </summary>
[Flags]
public enum IpcKind : byte
{
    None      = 0 << 0,
    Mods      = 1 << 0, // 1000ms delay
    Glamourer = 1 << 1, // 750ms delay
    Heels     = 1 << 2, // 750ms delay
    CPlus     = 1 << 3, // 750ms delay
    Honorific = 1 << 4, // 500ms delay
    Moodles   = 1 << 5, // 250ms delay
    ModManips = 1 << 6, // 250ms delay
    PetNames  = 1 << 7, // 150ms delay
}
