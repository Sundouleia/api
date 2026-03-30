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
    Task Callback_RadarUserFlagged(string flaggedUserUid); // Maybe remove
    Task Callback_ServerInfo(ServerInfoResponse info);

    // --- Pair/Request Callbacks ---
    Task Callback_AddPair(UserPair dto);
    Task Callback_RemovePair(UserDto dto);
    Task Callback_PersistPair(UserDto dto);
    Task Callback_AddRequest(SundesmoRequest dto);
    Task Callback_RemoveRequest(SundesmoRequest dto);

    // --- Loci Integration Callbacks ---
    Task Callback_PairLociDataUpdated(LociDataUpdate dto);
    Task Callback_PairLociStatusesUpdate(LociStatusesUpdate dto);
    Task Callback_PairLociPresetsUpdate(LociPresetsUpdate dto);
    Task Callback_PairLociStatusModified(LociStatusModified dto);
    Task Callback_PairLociPresetModified(LociPresetModified dto);
    Task Callback_ApplyLociDataById(ApplyLociDataById dto);
    Task Callback_ApplyLociStatus(ApplyLociStatus dto);
    Task Callback_RemoveLociData(RemoveLociData dto);

    // --- Data Update Callbacks ---
    Task Callback_IpcUpdateFull(IpcUpdateFull dto);
    Task Callback_IpcUpdateMods(IpcUpdateMods dto);
    Task Callback_IpcUpdateOther(IpcUpdateOther dto);
    Task Callback_IpcUpdateSingle(IpcUpdateSingle dto);
    Task Callback_ChangeGlobalPerm(ChangeGlobalPerm dto);
    Task Callback_ChangeAllGlobal(ChangeAllGlobal dto);
    Task Callback_ChangeUniquePerm(ChangeUniquePerm dto);
    Task Callback_ChangeUniquePerms(ChangeUniquePerms dto);
    Task Callback_ChangeAllUnique(ChangeAllUnique dto);

    // --- SanctionedGroup Callbacks ---
    // WIP...


    // --- Radar Callbacks ---
    Task Callback_RadarChatMessage(LoggedRadarChatMessage dto);
    Task Callback_RadarChatAddUpdateUser(RadarChatMember dto); // name is placeholder
    Task Callback_RadarAddUpdateUser(RadarMember dto);
    Task Callback_RadarRemoveUser(UserDto dto);
    Task Callback_RadarGroupAddUpdateUser(RadarGroupMember dto);
    Task Callback_RadarGroupRemoveUser(UserDto dto);

    // Placeholder while we figure out the DTO for this.
    Task Callback_ChatMsgReceived(ReceivedChatMessage dto);

    // --- User Status Update Callbacks ---
    Task Callback_UserIsUnloading(UserDto dto);
    Task Callback_UserOffline(UserDto dto);
    Task Callback_UserOnline(OnlineUser dto);
    Task Callback_UserVanityUpdate(UserDto dto); // Enforce a refresh on all vanity status for the pair.
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
    // IPC updates.
    Task<HubResponse<List<ValidFileHash>>> UserPushIpcFull(PushIpcFull dto); // Push all mod file replacement data and other visual display data.
    Task<HubResponse<List<ValidFileHash>>> UserPushIpcMods(PushIpcMods dto); // Push only mod file updates, containing file replacement data.
    Task<HubResponse> UserPushIpcOther(PushIpcOther dto); // Push only non-mod updates, for faster handling.
    Task<HubResponse> UserPushIpcSingle(PushIpcSingle dto); // Push a single change to IPC appearance (useful for things like heels ext.)
    // Loci updates.
    Task<HubResponse> UserPushLociData(PushLociData dto);         // Share all data with allowed sundesmos.
    Task<HubResponse> UserPushLociStatuses(PushLociStatuses dto); // Share all Statuses data.
    Task<HubResponse> UserPushLociPresets(PushLociPresets dto);   // Share all Presets data.
    Task<HubResponse> UserPushStatusModified(PushStatusModified dto);   // A LociStatus was modified, created, or deleted.
    Task<HubResponse> UserPushPresetModified(PushPresetModified dto);   // A LociPreset was modified, created, or deleted.
    
    // Other updates.
    Task<HubResponse> UserSetAlias(AliasUpdate dto);
    Task<HubResponse> UserSetVanity(VanityUpdate dto);
    Task<HubResponse> UserUpdateProfileContent(ProfileContent dto);
    Task<HubResponse> UserUpdateProfilePicture(ProfileImage dto);
    Task<HubResponse> UserDelete();
    Task<HubResponse> UserNotifyIsUnloading(); // Used on plugin shutdown, or any method that clears all sundesmo data.
    #endregion Data Updates

    // --- Pair/Request Interactions ---
    #region Pair/Request Interactions
    Task<HubResponse<SundesmoRequest>> UserSendRequest(CreateRequest dto);
    Task<HubResponse<List<SundesmoRequest>>> UserSendRequests(CreateRequests dto);

    /// <remarks> If successful, remove the request they wished to cancel. </remarks>
    Task<HubResponse> UserCancelRequest(UserDto user);

    /// <remarks> If successful, remove all requests they wished to cancel. </remarks>
    Task<HubResponse> UserCancelRequests(UserListDto users);

    /// <remarks> If EC "AlreadyPaired" is returned, remove the request from your pending list. </remarks>
    /// <returns> The new UserPair to add, if the request was properly accepted.</returns>
    Task<HubResponse<AddedUserPair>> UserAcceptRequest(RequestResponse response);

    /// <remarks> If successful, remove all requests for users passed in, regardless of outcome. </remarks>
    Task<HubResponse<List<AddedUserPair>>> UserAcceptRequests(RequestResponses responses);

    /// <remarks> Remove the request if successful. </remarks>
    Task<HubResponse> UserRejectRequest(UserDto user);

    /// <remarks> Remove the requests for all users passed in if successful. </remarks>
    Task<HubResponse> UserRejectRequests(UserListDto users);

    /// <remarks> Remove pair if result is successful. </remarks>
    Task<HubResponse> UserRemovePair(UserDto user);

    /// <remarks> Remove pairs for all users passed in if result is successful. </remarks>
    Task<HubResponse> UserRemovePairs(UserListDto users);

    /// <summary> Converts a temporary pair to a permanent one </summary>
    /// <remarks> Can only be done by the accepter. </remarks>
    Task<HubResponse> UserPersistPair(UserDto user);

    // Functionality not yet implemented (and may be kept client side)
    Task<HubResponse> UserBlock(UserDto user);
    Task<HubResponse> UserUnblock(UserDto user);

    /// <summary> Informs another pair to apply their own status(s) to themselves. </summary>
    Task<HubResponse> UserApplyLociData(ApplyLociDataById dto);

    /// <summary> Informs another pair to apply a list of StatusInfo tuples to themselves. </summary>
    Task<HubResponse> UserApplyLociStatusTuples(ApplyLociStatus dto);

    /// <summary> Informs another pair to remove a status/preset from themselves. </summary>
    Task<HubResponse> UserRemoveLociData(RemoveLociData dto);

    #endregion Pair/Request Interactions

    // -- Permission Changes ---
    #region Permission Changes
    // Keep in mind that all of the permission changes do not return the resulting permissions to you.
    // Instead, it only returns the hub response. If successful, assume the update set properly.
    Task<HubResponse> UserChangeGlobalsSingle(ChangeGlobalPerm dto); // Rename this to match format later.
    Task<HubResponse> UserChangeAllGlobals(GlobalPerms newPerms);
    Task<HubResponse> UserChangeUniquePerm(ChangeUniquePerm dto);
    Task<HubResponse> UserChangeUniquePerms(ChangeUniquePerms dto);
    Task<HubResponse> UserChangeAllUnique(ChangeAllUnique dto);
    Task<HubResponse> UserBulkChangeUniquePerm(BulkChangeUniquePerm dto);
    Task<HubResponse> UserBulkChangeUniquePerms(BulkChangeUniquePerms dto);
    Task<HubResponse> UserBulkChangeAllUnique(BulkChangeAllUnique dto);
    #endregion Permission Changes


    // --- Radar and Chat Exchanges ---
    #region Radar and Chat Exchanges

    Task<HubResponse> UserSendChatDM(DirectChatMessage message);

    Task<HubResponse<LocationUpdateResult>> UpdateLocation(LocationUpdate updateDto);

    // Returns the recent messages for the area.
    Task<HubResponse<List<LoggedRadarChatMessage>>> RadarChatJoin(RadarChatMember joinDto);
    Task<HubResponse> RadarChatPermissionChange(RadarChatMember updateDto);
    Task<HubResponse> RadarSendChat(SentRadarMessage messageDto);
    Task<HubResponse> RadarChatLeave();
    // No reason to add info about who is in the chat yet (?), but can easily add to the join later)

    Task<HubResponse<List<RadarMember>>> RadarAreaJoin(RadarMember joinDto);
    Task<HubResponse> RadarAreaPermissionChange(RadarMember updateDto);
    Task<HubResponse> RadarAreaLeave(); // Will also leave the group as well...

    Task<HubResponse<List<RadarGroupMember>>> RadarGroupJoin(RadarGroupMember joinDto);
    Task<HubResponse> RadarGroupPermissionChange(RadarGroupMember updateDto);
    Task<HubResponse> RadarGroupLeave();
    #endregion Radar and Chat Exchanges

    // --- SMA File Sharing ---
    #region SMA File Sharing
    // As everything is with security, whoever you give access to this, know you give your appearance up to them.
    // When you allow someone to open the base file, you are effectively giving away your appearance.
    // Nothing can prevent anyone from tampering or sharing the decrypted data afterwards.
    Task<HubResponse<SMABFileInfo>> AccessFile(SMABFileAccess dto);
    Task<HubResponse<List<string>>> GetAllowedHashes(Guid FileId); // If we know the ID, we had access to the file.

    // File Management.
    Task<HubResponse> CreateProtectedSMAB(NewSMABFile dto); // Could further secure this by having it generate on the server end and encrypt but that would strain the server hard.
    Task<HubResponse> UpdateFileDataHash(SMABDataUpdate dto); // Would need to return the new fileKey maybe? 
    Task<HubResponse> UpdateFilePassword(SMABDataUpdate dto); // Empty string to remove password.
    Task<HubResponse> UpdateAllowedHashes(SMABAccessUpdate dto);
    Task<HubResponse> UpdateAllowedUids(SMABAccessUpdate dto);
    Task<HubResponse> UpdateExpireTime(SMABExpireTime dto);
    Task<HubResponse> RemoveProtectedFile(Guid FileId);
    #endregion SMA File Sharing

    // --- Reporting ---
    #region Reporting
    Task<HubResponse> UserReportProfile(ProfileReport dto); // hopefully this is never used x-x...

    // may not need until more utility is added.
    Task<HubResponse> UserReportRadar(RadarReport dto);
    Task<HubResponse> UserReportChat(RadarChatReport dto); // hopefully this is never used x-x...
    #endregion Reporting
}