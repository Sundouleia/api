using SundouleiaAPI.Enums;
using SundouleiaAPI.Network;

namespace SundouleiaAPI.Hub;

/// <summary>
///     All OnCallback actions.
/// </summary>
public interface ISundouleiaHubClient : ISundouleiaHub
{
    // --- Server Messages ---
    void OnServerMessage(Action<MessageSeverity, string> act);
    void OnHardReconnectMessage(Action<MessageSeverity, string, ServerState> act);
    void OnRadarUserFlagged(Action<string> act);
    void OnServerInfo(Action<ServerInfoResponse> act);

    // --- Pair/Request ---
    void OnAddPair(Action<UserPair> act);
    void OnRemovePair(Action<UserDto> act);
    void OnPersistPair(Action<UserDto> act);
    void OnAddRequest(Action<SundesmoRequest> act);
    void OnRemoveRequest(Action<SundesmoRequest> act);

    // --- Moderation Utility ---
    void OnBlocked(Action<UserDto> act);
    void OnUnblocked(Action<UserDto> act);

    // -- Loci Integration --
    void OnPairLociDataUpdated(Action<LociDataUpdate> act);
    void OnPairLociStatusesUpdate(Action<LociStatusesUpdate> act);
    void OnPairLociPresetsUpdate(Action<LociPresetsUpdate> act);
    void OnPairLociStatusModified(Action<LociStatusModified> act);
    void OnPairLociPresetModified(Action<LociPresetModified> act);
    void OnApplyLociDataById(Action<ApplyLociDataById> act);
    void OnApplyLociStatus(Action<ApplyLociStatus> act);
    void OnRemoveLociData(Action<RemoveLociData> act);

    // -- Data Updates --
    void OnIpcUpdateFull(Action<IpcUpdateFull> act);
    void OnIpcUpdateMods(Action<IpcUpdateMods> act);
    void OnIpcUpdateOther(Action<IpcUpdateOther> act);
    void OnIpcUpdateSingle(Action<IpcUpdateSingle> act);

    // Need to update GlobalPerm names to match new format and stuff.
    void OnSingleChangeGlobal(Action<ChangeGlobalPerm> act);
    void OnBulkChangeGlobal(Action<ChangeAllGlobal> act);
    void OnChangeUniquePerm(Action<ChangeUniquePerm> act);
    void OnChangeUniquePerms(Action<ChangeUniquePerms> act);
    void OnChangeAllUnique(Action<ChangeAllUnique> act);

    // -- Radar --
    void OnUserSendDirectMessage(Action<DirectChatMessage> act);
    void OnUpdateLocation(Action<LocationUpdate> act);
    void OnRadarChatJoin(Action<RadarChatMember> act);
    void OnRadarChatPermissionChanged(Action<RadarChatMember> act);
    void OnRadarChatMessage(Action<LoggedRadarChatMessage> act);
    void OnRadarChatLeave(Action act);
    void OnRadarZoneJoin(Action<RadarMember> act);
    void OnRadarZonePermissionChanged(Action<RadarMember> act);
    void OnRadarZoneLeave(Action act);
    void OnRadarGroupJoin(Action<RadarGroupMember> act);
    void OnRadarGroupPermissionChanged(Action<RadarGroupMember> act);
    void OnRadarGroupLeave(Action act);

    // --- User Status Update ---
    void OnUserIsUnloading(Action<UserDto> act);
    void OnUserOffline(Action<UserDto> act);
    void OnUserOnline(Action<OnlineUser> act);
    void OnProfileUpdated(Action<UserDto> act);
    void OnShowVerification(Action<VerificationCode> act);
}
