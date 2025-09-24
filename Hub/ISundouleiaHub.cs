using SundouleiaAPI.Enums;
using SundouleiaAPI.Data;
using SundouleiaAPI.Network;

namespace SundouleiaAPI.Hub;

/// <summary>
///     The contract that defines which methods must be provided by any signalR hub using it.
/// </summary>
public interface ISundouleiaHub
{
    const int ApiVersion = 1;
    const string Path = "/sundouleia";

    // Keeps a clients connection alive.
    Task<bool> HealthCheck();
    Task<ConnectionResponse> GetConnectionResponse();

    #region Callbacks
    Task Callback_ServerMessage(MessageSeverity severity, string message);
    Task Callback_HardReconnectMessage(MessageSeverity severity, string message, ServerState state);
    Task Callback_ServerInfo(ServerInfoResponse info);

    // --- Pair/Request Callbacks ---
    Task Callback_AddPair(UserPair dto);
    Task Callback_RemovePair(UserDto dto);
    Task Callback_AddRequest(PendingRequest dto);
    Task Callback_RemoveRequest(PendingRequest dto);

    // -- Moderation Utility Callbacks ---
    Task Callback_Blocked(UserDto dto);
    Task Callback_Unblocked(UserDto dto);

    // --- Data Update Callbacks ---
    Task Callback_IpcUpdateFull(IpcUpdateFull dto);
    Task Callback_IpcUpdateMods(IpcUpdateMods dto);
    Task Callback_IpcUpdateOther(IpcUpdateOther dto);
    Task Callback_IpcUpdateSingle(IpcUpdateSingle dto);
    Task Callback_SingleChangeGlobal(SingleChangeGlobal dto);
    Task Callback_BulkChangeGlobal(BulkChangeGlobal dto);
    Task Callback_SingleChangeUnique(SingleChangeUnique dto);
    Task Callback_BulkChangeUnique(BulkChangeUnique dto);

    // --- Radar Callbacks ---
    Task Callback_RadarAddUser(UserDto dto);
    Task Callback_RadarRemoveUser(UserDto dto);
    Task Callback_RadarChat(RadarChatMessage dto);


    // --- User Status Update Callbacks ---
    Task Callback_UserOffline(UserDto dto);
    Task Callback_UserOnline(OnlineUser dto);
    Task Callback_ProfileUpdated(UserDto dto);

    // --- InGame Account Verification ---
    Task Callback_ShowVerification(VerificationCode dto);
    #endregion Callbacks


    // --- Data Retrievals ---
    Task<List<OnlineUser>> UserGetOnlinePairs();
    Task<List<UserPair>> UserGetAllPairs();
    Task<List<PendingRequest>> UserGetPendingRequests();
    Task<FullProfileData> UserGetProfileData(UserDto user);


    // --- Data Updates ---
    // TODO: Add methods here for updating a users dataHash cache so we can know what to send and what not to.
    Task<HubResponse> UserPushIpcFull(PushIpcFull dto); // Push all mod file replacement data and other visual display data.
    Task<HubResponse> UserPushIpcMods(PushIpcMods dto); // Push only mod file updates, containing file replacement data.
    Task<HubResponse> UserPushIpcOther(PushIpcOther dto); // Push only non-mod updates, for faster handling.
    Task<HubResponse> UserPushIpcSingle(PushIpcSingle dto); // Push a single change to IPC appearance (useful for things like heels ext.)
    Task<HubResponse> UserUpdateProfileContent(ProfileContent dto);
    Task<HubResponse> UserUpdateProfilePicture(ProfileImage dto);    
    Task<HubResponse> UserDelete();


    // --- Pair/Request Interactions ---
    Task<HubResponse> UserSendRequest(CreateRequest dto);
    Task<HubResponse> UserCancelRequest(UserDto user);
    Task<HubResponse> UserAcceptRequest(UserDto user);
    Task<HubResponse> UserRejectRequest(UserDto user);
    Task<HubResponse> UserRemovePair(UserDto UserDto);

    // -- Permission Changes ---
    Task<HubResponse> UserChangeGlobalsSingle(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeGlobalsBulk(BulkChangeGlobal dto);
    Task<HubResponse> UserChangeUniqueSingle(SingleChangeUnique dto);
    Task<HubResponse> UserChangeUniqueBulk(BulkChangeUnique dto);


    // --- Radar Exchanges ---
    Task<HubResponse<RadarZoneInfo>> UserSendRadarUpdate(RadarZoneUpdate dto);
    Task<HubResponse> UserSendRadarChat(ushort zoneId, string message);

    // --- Reporting ---
    Task<HubResponse> UserReportProfile(ProfileReport dto); // hopefully this is never used x-x...
    Task<HubResponse> UserReportRadar(RadarReport dto); // hopefully this is never used x-x...
    Task<HubResponse> UserReportChat(RadarChatReport dto); // hopefully this is never used x-x...
}
