namespace SundouleiaAPI.Enums;

public enum DataEventType
{
    /// <summary>
    ///     No Specific Type. Could be Miscellaneous or Unknown.
    /// </summary>
    None,

    /// <summary>
    ///     Sundesmo has entered render distance and been marked as visible. <para />
    ///     Do not confuse this with the indication of if they should send data or not.
    /// </summary>
    NowRendered,

    /// <summary>
    ///     Sundesmo has left render distance and is no longer visible. <para />
    ///     Doesn't mean you should revert their state or dispose of their data yet.
    /// </summary>
    NoLongerRendered,

    /// <summary>
    ///     Sundesmo has been not been rendered for long enough to warrant a data revert. <para />
    ///     Only displays if any data was applied. (?)
    /// </summary>
    AppliedDataReverted,

    /// <summary>
    ///     Received a full data update from the sundesmo.
    /// </summary>
    FullDataReceive,

    /// <summary>
    ///     Received a mod data update from the sundesmo, containing data hashes to add,
    ///     and which to remove, from their temporary collection.
    /// </summary>
    ModDataReceive,

    /// <summary>
    ///     Received a non-mod data update from the sundesmo, containing other visual IPC modifications.
    /// </summary>
    VisualDataReceive,

    /// <summary>
    ///     Received a single visual data update string from the sundesmo.
    /// </summary>
    SingleVisualReceive,

    /// <summary>
    ///     The data you got from another sundesmo was declined for some reason.
    /// </summary>
    ReceivedDataDeclined,

    /// <summary>
    ///     The Paused state of the sundesmo has changed. Could have been by you, or them.
    /// </summary>
    PauseStateChange,

    /// <summary>
    ///     A PairPerm from your end or the sundesmos end has changed.
    /// </summary>
    PermissionChange,

    /// <summary>
    ///     Sundesmo was disposed of.
    /// </summary>
    Disposed,
}

public enum InteractionFilter
{
    All,
    Applier,
    Interaction,
    Content,
}