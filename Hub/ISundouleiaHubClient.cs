using SundouleiaAPI.Alterations;
using SundouleiaAPI.Connection;
using SundouleiaAPI.Data;
using SundouleiaAPI.Loci;
using SundouleiaAPI.Permissions;
using SundouleiaAPI.Radar;
using SundouleiaAPI.Requests;
using SundouleiaAPI.Sanctions;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Hub;

/// <summary>
///     All OnCallback actions.
/// </summary>
public interface ISundouleiaHubClient : ISundouleiaHub
{
    #region Server Information
    void OnServerMessage(Action<MessageSeverity, string> act);
    void OnHardReconnectMessage(Action<MessageSeverity, string, ServerState> act);
    void OnRadarUserFlagged(Action<string> act);
    void OnServerInfo(Action<ServerInfoResponse> act);
    #endregion Server Information

    #region Pairs / Requests
    void OnAddPair(Action<UserPair> act);
    void OnRemovePair(Action<UserDto> act);
    void OnPersistPair(Action<UserDto> act);
    void OnAddRequest(Action<PairRequest> act);
    void OnRemoveRequest(Action<PairRequest> act);
    #endregion Pairs / Requests

    #region Sanctions
    void OnSanctionInfo(Action<SanctionInfo> act);
    void OnSanctionNamesUpdated(Action<SanctionNamesDto> act);
    void OnSanctionVisibilityUpdated(Action<SanctionVisibilityDto> act);
    void OnSanctionStyleModified(Action<SanctionStyleDto> act);
    void OnSanctionPreferencesModified(Action<SanctionPreferencesDto> act);
    void OnSanctionRolesUpdated(Action<SanctionRolesUpdate> act);
    void OnSanctionProfileUpdated(Action<SanctionDto> act);
    void OnSanctionMemberJoined(Action<SanctionPairFullDto> act);
    void OnSanctionMemberUpdated(Action<SanctionPairFullDto> act);
    void OnSanctionMemberLeft(Action<SanctionPairDto> act);
    void OnSanctionMembersLeft(Action<SanctionPairsDto> act);
    void OnSanctionDeleted(Action<SanctionDto> act);
    #endregion Sanctions

    #region Data Updates
    void OnIpcUpdateFull(Action<IpcUpdateFull> act);
    void OnIpcUpdateMods(Action<IpcUpdateMods> act);
    void OnIpcUpdateOther(Action<IpcUpdateOther> act);
    void OnIpcUpdateSingle(Action<IpcUpdateSingle> act);
    #endregion Data Updates

    #region Permission Updates
    void OnChangeGlobalPerm(Action<ChangeGlobalPerm> act);
    void OnBulkChangeGlobal(Action<ChangeAllGlobal> act);
    void OnChangeUniquePerm(Action<ChangeUniquePerm> act);
    void OnChangeUniquePerms(Action<ChangeUniquePerms> act);
    void OnChangeAllUnique(Action<ChangeAllUnique> act);
    #endregion Permission Updates

    #region Loci DataShare
    void OnPairLociDataUpdated(Action<LociDataUpdate> act);
    void OnPairLociStatusesUpdate(Action<LociStatusesUpdate> act);
    void OnPairLociPresetsUpdate(Action<LociPresetsUpdate> act);
    void OnPairLociStatusModified(Action<LociStatusModified> act);
    void OnPairLociPresetModified(Action<LociPresetModified> act);
    void OnApplyLociDataById(Action<ApplyLociDataById> act);
    void OnApplyLociStatus(Action<ApplyLociStatus> act);
    void OnRemoveLociData(Action<RemoveLociData> act);
    #endregion Loci DataShare

    #region Radar
    void OnRadarChatMessage(Action<LoggedRadarChatMessage> act);
    void OnRadarChatAddUpdateUser(Action<RadarChatMember> act);
    void OnRadarAddUpdateUser(Action<RadarMember> act);
    void OnRadarRemoveUser(Action<UserDto> act);
    void OnRadarGroupAddUpdateUser(Action<RadarGroupMember> act);
    void OnRadarGroupRemoveUser(Action<UserDto> act);
    #endregion Radar

    #region Chat
    void OnChatMessageReceived(Action<ReceivedChatMessage> act);
    #endregion Chat

    #region User State / Status
    void OnUserOnline(Action<OnlineUser> act);
    void OnUserIsUnloading(Action<UserDto> act);
    void OnUserOffline(Action<UserDto> act);
    void OnUserVanityUpdated(Action<UserDto> act);
    void OnProfileUpdated(Action<UserDto> act);
    void OnShowVerification(Action<VerificationCode> act);
    #endregion User State / Status
}
