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
    void OnServerInfo(Action<ServerInfoResponse> act);

    // --- Pair/Request ---
    void OnAddPair(Action<UserPair> act);
    void OnRemovePair(Action<UserDto> act);
    void OnAddRequest(Action<PendingRequest> act);
    void OnRemoveRequest(Action<PendingRequest> act);

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
    void OnRadarAddUser(Action<UserDto> act);
    void OnRadarRemoveUser(Action<UserDto> act);
    void OnRadarChat(Action<RadarChatMessage> act);

    // --- User Status Update ---
    void OnUserOffline(Action<UserDto> act);
    void OnUserOnline(Action<OnlineUser> act);
    void OnProfileUpdated(Action<UserDto> act);

    // --- InGame Account Verification ---
    void OnShowVerification(Action<VerificationCode> act);
}
