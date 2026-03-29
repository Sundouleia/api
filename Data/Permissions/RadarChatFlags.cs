namespace SundouleiaAPI.Data.Permissions;

/// <summary>
///   Defines how a user connects to the radar chat.
/// </summary>
[Flags]
public enum RadarChatFlags : ushort
{
    /// <summary>
    ///   Assume Lurker state. Others see you as Anon-User and cannot interact with you.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    ///   In place of an Anon-User name, use the vanity display name.  
    /// </summary>
    UseDisplayName = 1 << 0,

    /// <summary>
    ///   If others can view your profile from the chat. (this can be a matched name)
    /// </summary>
    AllowProfileViewing = 1 << 1,

    /// <summary>
    ///   If other users are able to send this person a direct message.
    /// </summary>
    AllowDirectMessages = 1 << 2,

    /// <summary>
    ///   If other users can send a pair request.
    /// </summary>
    AllowPairRequests = 1 << 3,
}
