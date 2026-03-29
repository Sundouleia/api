namespace SundouleiaAPI.Data.Permissions;

/// <summary>
///   How a user interacts with other users when in a radar group. <para/>
///   An important distinction to make is that a RadarGroup has RadarUsers and RadarPairs. <br/>
///   <b>Radar Users:</b> Can see eachother in the group, but do not share data. <br/>
///   <b>Radar Pairs:</b> Are temporarily 'paired' via the radar group, allowing shared data.
/// </summary>
/// <remarks><b>Note: This is not the same as a Sacntioned Group.</b></remarks>
[Flags]
public enum RadarGroupFlags : ushort
{
    /// <summary>
    ///   Assume Lurker state.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    ///   When not paired, use vanity display name over Anon-User.
    /// </summary>
    UseDisplayName = 1 << 0,

    /// <summary>
    ///   Inform others when in visible range.
    /// </summary>
    ShowVisibility = 1 << 1,

    /// <summary>
    ///   Allows others to focus target on hover, set focus target, or target.
    /// </summary>
    Targetable = 1 << 2,

    /// <summary>
    ///   Allows others to view your profile (matches displayed radar name in profile)
    /// </summary>
    AllowProfileViewing = 1 << 3,

    /// <summary>
    ///   Allows others from radar to send you a direct message.
    /// </summary>
    AllowMessaging = 1 << 4,

    /// <summary>
    ///  Enforce ProfileViewing and Messaging to radar pairs and direct pairs only.
    /// </summary>
    RestrictAllowancesToPairs = 1 << 5,

    // ----- Pairing Flags -----
    /// <summary>
    ///   Automatically pair with other rendered radar users in the group. <br/>
    ///   You unpair upon leaving the radar group if not paired directly.
    /// </summary>
    AutoRadarPairing = 1 << 6,

    /// <summary>
    ///   Enforce others to require a radar request to radar pair. <br/>
    ///   If this is false, and auto pairing is false, requesting is blocked.
    /// </summary>
    RequireRequest = 1 << 7,
}
