namespace SundouleiaAPI.Enums;


/// <summary>
///     Can rearrange the order these are listed in the folder 
///     to adjust sort priority.
/// </summary>
public enum FolderSortFilter
{
    Rendered,       // Rendered sundesmos first.
    Online,         // Online sundesmos first.
    Favorite,       // Favorite sundesmos first.
    Alphabetical,   // Default behavior.
    Temporary,      // Temporary sundesmos first.
    DateAdded,      // When the pair was established.
}