using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using SundouleiaAPI.Enums;
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
    Task Callback_RadarUserFlagged(string flaggedUserUid); // Ensures any inappropriate behavior is immediately censored.
    Task Callback_ServerInfo(ServerInfoResponse info);

    // --- Pair/Request Callbacks ---
    Task Callback_AddPair(UserPair dto);
    Task Callback_RemovePair(UserDto dto);
    Task Callback_PersistPair(UserDto dto);
    Task Callback_AddRequest(SundesmoRequest dto);
    Task Callback_RemoveRequest(SundesmoRequest dto);

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
    Task Callback_RadarAddUpdateUser(OnlineUser dto);
    Task Callback_RadarRemoveUser(UserDto dto);
    Task Callback_RadarChat(RadarChatMessage dto);


    // --- User Status Update Callbacks ---
    Task Callback_UserIsUnloading(UserDto dto);
    Task Callback_UserOffline(UserDto dto);
    Task Callback_UserOnline(OnlineUser dto);
    Task Callback_ProfileUpdated(UserDto dto);
    Task Callback_ShowVerification(VerificationCode dto);
    #endregion Callbacks


    // --- Data Retrievals ---
    Task<List<OnlineUser>> UserGetOnlinePairs();
    Task<List<UserPair>> UserGetAllPairs();
    Task<List<SundesmoRequest>> UserGetSundesmoRequests();
    Task<FullProfileData> UserGetProfileData(UserDto user, bool allowNSFW);


    // --- Data Updates ---
    #region Data Updates
    Task<HubResponse<List<VerifiedModFile>>> UserPushIpcFull(PushIpcFull dto); // Push all mod file replacement data and other visual display data.
    Task<HubResponse<List<VerifiedModFile>>> UserPushIpcMods(PushIpcMods dto); // Push only mod file updates, containing file replacement data.
    Task<HubResponse> UserPushIpcOther(PushIpcOther dto); // Push only non-mod updates, for faster handling.
    Task<HubResponse> UserPushIpcSingle(PushIpcSingle dto); // Push a single change to IPC appearance (useful for things like heels ext.)
    Task<HubResponse> UserUpdateProfileContent(ProfileContent dto);
    Task<HubResponse> UserUpdateProfilePicture(ProfileImage dto);
    Task<HubResponse> UserDelete();
    Task<HubResponse> UserNotifyIsUnloading(); // Used on plugin shutdown, or any method that clears all sundesmo data.
    #endregion Data Updates

    // --- Pair/Request Interactions ---
    #region Pair/Request Interactions
    Task<HubResponse<SundesmoRequest>> UserSendRequest(CreateRequest dto);

    /// <summary>
    ///     If successful, remove the request they wished to cancel.
    /// </summary>
    Task<HubResponse> UserCancelRequest(UserDto user);

    /// <summary>
    ///     If EC "AlreadyPaired" is returned, remove the request from your pending list.
    /// </summary>
    /// <returns> The new UserPair to add, if the request was properly accepted.</returns>
    Task<HubResponse<AddedUserPair>> UserAcceptRequest(UserDto user);
    
    /// <summary>
    ///     You are expected to remove the request from your pending list if successful.
    ///     (Helps save extra server calls)
    /// </summary>
    Task<HubResponse> UserRejectRequest(UserDto user);

    /// <summary>
    ///     If successful, you should remove the pair from your list of pairs.
    /// </summary>
    Task<HubResponse> UserRemovePair(UserDto user);

    /// <summary>
    ///     Converts a temporary sundesmo into a permanent one. Can only be done by the accepter.
    /// </summary>
    Task<HubResponse> UserPersistPair(UserDto user);

    /// <summary>
    ///     Permanently block a user.
    /// </summary>
    Task<HubResponse> UserBlock(UserDto user);

    /// <summary>
    ///     Unblock a blocked user.
    /// </summary>
    Task<HubResponse> UserUnblock(UserDto user);

    #endregion Pair/Request Interactions

    // -- Permission Changes ---
    #region Permission Changes
    // Keep in mind that all of the permission changes do not return the resulting permissions to you.
    // Instead, it only returns the hub response. If successful, assume the update set properly.
    Task<HubResponse> UserChangeGlobalsSingle(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeGlobalsBulk(GlobalPerms newPerms);
    Task<HubResponse> UserChangeUniqueSingle(SingleChangeUnique dto);
    Task<HubResponse> UserChangeUniqueBulk(BulkChangeUnique newPerms);
    #endregion Permission Changes

    // --- Radar Exchanges ---
    #region Radar Exchanges
    Task<HubResponse<RadarZoneInfo>> RadarZoneJoin(RadarZoneUpdate joinInfo); //
    Task<HubResponse> RadarZoneLeave(); //
    Task<HubResponse> RadarUpdateState(RadarState stateUpdate);
    Task<HubResponse> RadarChatMessage(RadarChatMessage chatDto);
    #endregion Radar Exchanges

    // --- Reporting ---
    #region Reporting
    Task<HubResponse> UserReportProfile(ProfileReport dto); // hopefully this is never used x-x...

    // will be more useful when we add metric gauges for tracking zone areas.
    Task<HubResponse> UserReportRadar(RadarReport dto);
    Task<HubResponse> UserReportChat(RadarChatReport dto); // hopefully this is never used x-x...
    #endregion Reporting
}