namespace SundouleiaAPI.Radar;

/// <summary>
///   Defines how a user connects to the public radar
/// </summary>
[Flags]
public enum RadarFlags : ushort
{
    /// <summary>
    ///   Assume Lurker state.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    ///   In place of an Anon-User name, use the vanity display name.  
    /// </summary>
    UseDisplayName = 1 << 0,

    /// <summary>
    ///   Let others know when you are rendered nearby.
    /// </summary>
    ShowVisibility = 1 << 1,

    /// <summary>
    ///   Allows others to focus target on hover, set focus target, or target.
    /// </summary>
    AllowTargeting = 1 << 2,

    /// <summary>
    ///   Allows others to view your profile (matches Anon-Name)
    /// </summary>
    AllowProfileViewing = 1 << 3,

    /// <summary>
    ///   Allows others from radar to send you a direct message.
    /// </summary>
    AllowDirectMessages = 1 << 4,

    /// <summary>
    ///   Allows others to send you a pair request.
    /// </summary>
    AllowRequests = 1 << 5,

    /// <summary>
    ///   Enforce requests sent to you as permanent, to become temporary instead.
    /// </summary>
    EnforceTemporary = 1 << 6,

    /// <summary>
    ///   Automatically accept sent radar requests.
    /// </summary>
    AutoAcceptRequests = 1 << 7,
}
