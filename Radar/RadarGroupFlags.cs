namespace SundouleiaAPI.Radar;

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
    ///   Use vanity display name over Anon-User.
    /// </summary>
    UseDisplayName = 1 << 0,

    /// <summary>
    ///   Inform others when in visible range.
    /// </summary>
    ShowVisibility = 1 << 1,

    /// <summary>
    ///   Allow others to use Target/FocusTarget/SoftTarget.
    /// </summary>
    Targetable = 1 << 2,

    /// <summary>
    ///   Allows others to view your profile (shows Anon-Name)
    /// </summary>
    AllowProfileViewing = 1 << 3,

    /// <summary>
    ///   Allows others from radar to send you a DM. (WIP)
    /// </summary>
    AllowMessaging = 1 << 4,

    /// <summary>
    ///  Enforce ProfileViewing and DMing to RadarPairs and Sundesmos only.
    /// </summary>
    RestrictAllowancesToPairs = 1 << 5,
}
