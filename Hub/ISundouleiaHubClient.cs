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

    // -- Data Updates --
    void OnIpcUpdateFull(Action<IpcUpdateFull> act);
    void OnIpcUpdateMods(Action<IpcUpdateMods> act);
    void OnIpcUpdateOther(Action<IpcUpdateOther> act);
    void OnIpcUpdateSingle(Action<IpcUpdateSingle> act);
    void OnSingleChangeGlobal(Action<SingleChangeGlobal> act);
    void OnBulkChangeGlobal(Action<BulkChangeGlobal> act);
    void OnSingleChangeUnique(Action<SingleChangeUnique> act);
    void OnBulkChangeUnique(Action<BulkChangeUnique> act);

    // -- Radar --
    void OnRadarAddUpdateUser(Action<OnlineUser> act);
    void OnRadarRemoveUser(Action<UserDto> act);
    void OnRadarChat(Action<RadarChatMessage> act);

    // --- User Status Update ---
    void OnUserIsUnloading(Action<UserDto> act);
    void OnUserOffline(Action<UserDto> act);
    void OnUserOnline(Action<OnlineUser> act);
    void OnProfileUpdated(Action<UserDto> act);
    void OnShowVerification(Action<VerificationCode> act);
}
