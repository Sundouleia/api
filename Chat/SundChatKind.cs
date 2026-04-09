namespace SundouleiaAPI.Chat;

/// <summary>
///   Helps identify what purpose the sent chat message serves.
/// </summary>
public enum SundChatKind
{
    Radar = 0,
    SanctionedGroup = 1,
    Direct = 2,
}