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
    const int ApiVersion = 2;
    const string Path = "/sundouleia";

    Task<bool> HealthCheck();
    Task<ConnectionResponse> GetConnectionResponse();
    Task<HubResponse> UserNotifyIsUnloading(); // Used on plugin shutdown, or any method that clears all sundesmo data.

    #region CALLBACKS

    #region Callbacks (Server Information)
    Task Callback_ServerMessage(MessageSeverity severity, string message);
    Task Callback_HardReconnectMessage(MessageSeverity severity, string message, ServerState state);
    Task Callback_RadarUserFlagged(string flaggedUserUid); // Maybe remove
    Task Callback_ServerInfo(ServerInfoResponse info);

    #endregion Callbacks (Server Information)

    #region Callbacks (Pairs/Requests)
    Task Callback_AddPair(UserPair dto);
    Task Callback_RemovePair(UserDto dto);
    Task Callback_PersistPair(UserDto dto);
    Task Callback_AddRequest(PairRequest dto);
    Task Callback_RemoveRequest(PairRequest dto);
    #endregion Callbacks (Pairs/Requests)

    #region Callbacks (Sanctions)
    Task Callback_SanctionInfoUpdated(SanctionInfo dto); // Updates last validation, location, IsPublic, and chatlogId
    // Unsure yet when this will be called ^^^
    Task Callback_SanctionNamesUpdated(SanctionNamesDto dto);
    Task Callback_SanctionVisibilityUpdated(SanctionVisibilityDto dto);
    Task Callback_SanctionStyleModified(SanctionStyleDto dto);
    Task Callback_SanctionPreferencesModified(SanctionPreferencesDto dto);
    Task Callback_SanctionRolesUpdated(SanctionRolesUpdate dto); // Updates to the roles, and their permissions
    Task Callback_SanctionProfileUpdated(SanctionDto dto); // Triggers a refresh
    // Task Callback_SanctionAlertsUpdated(); // WIP - Let Sanctions make alert notifications to subscribed members.
    Task Callback_SanctionMemberJoined(SanctionPairFullDto dto); // When someone joins the sanction
    Task Callback_SanctionMemberUpdated(SanctionPairFullDto dto); // Information regarding this user was updated. Maybe split into subcalls.
    Task Callback_SanctionMemberLeft(SanctionPairDto dto); // When someone leaves the sanction
    Task Callback_SanctionMembersLeft(SanctionPairsDto dto);
    Task Callback_SanctionDeleted(SanctionDto dto); // On the deletion of a Sanction
    // Called by the cleanup ^^^
    #endregion Callbacks (Sanctions)

    #region Callbacks (Data Updates)
    Task Callback_IpcUpdateFull(IpcUpdateFull dto);
    Task Callback_IpcUpdateMods(IpcUpdateMods dto);
    Task Callback_IpcUpdateOther(IpcUpdateOther dto);
    Task Callback_IpcUpdateSingle(IpcUpdateSingle dto);
    #endregion Callbacks (Data Updates)

    #region Callbacks (Permission Updates)
    Task Callback_ChangeGlobalPerm(ChangeGlobalPerm dto);
    Task Callback_ChangeAllGlobal(ChangeAllGlobal dto);
    Task Callback_ChangeUniquePerm(ChangeUniquePerm dto);
    Task Callback_ChangeUniquePerms(ChangeUniquePerms dto);
    Task Callback_ChangeAllUnique(ChangeAllUnique dto);
    #endregion Callbacks (Permission Updates)

    #region Callbacks (Loci DataShare)
    Task Callback_PairLociDataUpdated(LociDataUpdate dto);
    Task Callback_PairLociStatusesUpdate(LociStatusesUpdate dto);
    Task Callback_PairLociPresetsUpdate(LociPresetsUpdate dto);
    Task Callback_PairLociStatusModified(LociStatusModified dto);
    Task Callback_PairLociPresetModified(LociPresetModified dto);
    Task Callback_ApplyLociDataById(ApplyLociDataById dto);
    Task Callback_ApplyLociStatus(ApplyLociStatus dto);
    Task Callback_RemoveLociData(RemoveLociData dto);
    #endregion Callbacks (Loci DataShare)

    #region Callbacks (Radar)
    Task Callback_RadarChatMessage(LoggedRadarChatMessage dto);
    Task Callback_RadarChatAddUpdateUser(RadarChatMember dto); // name is placeholder
    Task Callback_RadarAddUpdateUser(RadarMember dto);
    Task Callback_RadarRemoveUser(UserDto dto);
    Task Callback_RadarGroupAddUpdateUser(RadarGroupMember dto);
    Task Callback_RadarGroupRemoveUser(UserDto dto);
    #endregion Callbacks (Radar)

    #region Callbacks (Chat)
    Task Callback_ChatMessageReceived(ReceivedChatMessage dto);
    #endregion Callbacks (Chat)

    #region Callbacks (User State/Status)
    Task Callback_UserOnline(OnlineUser dto);
    Task Callback_UserIsUnloading(UserDto dto);
    Task Callback_UserOffline(UserDto dto);
    Task Callback_UserVanityUpdated(UserDto dto); // Enforce a refresh on all vanity status for the pair.
    Task Callback_UserProfileUpdated(UserDto dto);
    Task Callback_ShowVerification(VerificationCode dto);
    #endregion Callbacks (User State/Status)

    #endregion CALLBACKS

    #region SERVER_CALLS

    #region Bulk Data Retrieval
    Task<List<UserPair>> GetAllSundesmos();
    Task<List<OnlineUser>> GetOnlineSundesmos();
    // Maybe conjoin these into a single call to avoid thousands of users opening 5 calls on connections.
    Task<List<PairRequest>> GetRequests();
    Task<List<BlockedUser>> GetBlockedUsers();
    Task<List<SanctionDataFull>> GetJoinedSanctions();
    #endregion Bulk Data Retrieval

    #region Vanity & Cosmetics
    /// <summary> Retrieve the ProfileData for a User. Can filter if NSFW is allowed </summary>
    Task<UserProfileData> UserGetProfileData(UserDto user, bool allowNSFW);
    /// <summary> Retrieve the ProfileData for a Sanction. Can filter if NSFW is allowed </summary>
    Task<SanctionProfileData> UserGetSanctionProfile(SanctionDto sanction, bool allowNSFW);
    /// <summary> Allows anyone to freely update their UserData alias </summary>
    Task<HubResponse> UserSetAlias(AliasUpdate dto);
    /// <summary> Updates the DisplayName and colors for a user. Supporter exclusive </summary>
    Task<HubResponse> UserSetVanity(VanityUpdate dto);
    // Modify as we update the profile layout...
    /// <summary> Update the image contents of your ProfileData, check image validity server-side. </summary>
    Task<HubResponse> UserUpdateProfilePicture(ProfileImageData dto);
    /// <summary> Update the contents of your ProfileData. </summary>
    Task<HubResponse> UserUpdateProfileContent(ProfileContentData dto);
    /// <summary> Sends a chat message to a SanctionedGroup. </summary>
    Task<HubResponse> UserSendSanctionChat(SentSanctionMessage message);
    /// <summary> Sends a direct chat message to another user, if allowed. </summary>
    Task<HubResponse> UserSendChatDM(SentDirectMessage message);
    #endregion Vanity & Cosmetics

    #region User Permissions
    Task<HubResponse> UserChangeGlobalPerm(ChangeGlobalPerm dto);
    Task<HubResponse> UserChangeAllGlobals(GlobalPerms newPerms);
    Task<HubResponse> UserChangeUniquePerm(ChangeUniquePerm dto);
    Task<HubResponse> UserChangeUniquePerms(ChangeUniquePerms dto);
    Task<HubResponse> UserChangeAllUnique(ChangeAllUnique dto);
    Task<HubResponse> UserBulkChangeUniquePerm(BulkChangeUniquePerm dto);
    Task<HubResponse> UserBulkChangeUniquePerms(BulkChangeUniquePerms dto);
    Task<HubResponse> UserBulkChangeAllUnique(BulkChangeAllUnique dto);
    #endregion User Permissions

    #region PlayerData Updates
    Task<HubResponse<List<ValidFileHash>>> UserPushIpcFull(PushIpcFull dto); // Full data push.
    Task<HubResponse<List<ValidFileHash>>> UserPushIpcMods(PushIpcMods dto); // Penumbra related update only
    Task<HubResponse> UserPushIpcOther(PushIpcOther dto);   // Updates excluding file replacements
    Task<HubResponse> UserPushIpcSingle(PushIpcSingle dto); // Individual IPC update for fast transit
    #endregion PlayerData Updates

    #region Loci
    Task<HubResponse> UserPushLociData(PushLociData dto);             // Share all data with allowed sundesmos.
    Task<HubResponse> UserPushLociStatuses(PushLociStatuses dto);     // Share all Statuses data.
    Task<HubResponse> UserPushLociPresets(PushLociPresets dto);       // Share all Presets data.
    Task<HubResponse> UserPushStatusModified(PushStatusModified dto); // A LociStatus was modified, created, or deleted.
    Task<HubResponse> UserPushPresetModified(PushPresetModified dto); // A LociPreset was modified, created, or deleted.
    /// <summary> Informs another pair to apply their own status(s) to themselves. </summary>
    Task<HubResponse> UserApplyLociData(ApplyLociDataById dto);
    /// <summary> Informs another pair to apply a list of StatusInfo tuples to themselves. </summary>
    Task<HubResponse> UserApplyLociStatusTuples(ApplyLociStatus dto);
    /// <summary> Informs another pair to remove a status/preset from themselves. </summary>
    Task<HubResponse> UserRemoveLociData(RemoveLociData dto);
    #endregion Loci

    #region Pairs
    Task<HubResponse<PairRequest>> UserSendRequest(CreateRequest dto);
    Task<HubResponse<List<PairRequest>>> UserSendRequests(CreateRequests dto);
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
    /// <summary> Converts a temporary pair to a permanent one. (Can only be done by the accepter) </summary>
    Task<HubResponse> UserPersistPair(UserDto user);
    /// <remarks> Remove pair if result is successful. </remarks>
    Task<HubResponse> UserRemovePair(UserDto user);
    /// <remarks> Remove pairs for all users passed in if result is successful. </remarks>
    Task<HubResponse> UserRemovePairs(UserListDto users);
    /// <summary> Explodes your logged in user from the Database, and all associated data with it. </summary>
    /// <remarks> Removing your primary profile deletes all other profiles linked to your account. </remarks>
    Task<HubResponse> UserDelete();
    /// <summary> Blocks a users AccountUID, restricting view from them or any other profiles. </summary>
    /// <remarks> Blocking will prevent seeing their chat messages, visibility in Radar, and data exchange. </summary>
    Task<HubResponse> UserBlockAccount(UserDto user);
    /// <summary> Unblocks a user, restoring functionality disabled by <see cref="UserBlockAccount(UserDto)"/> </summary>
    Task<HubResponse> UserUnblockAccount(UserDto user);
    #endregion Pairs

    #region Sanctions
    /// <summary> Updates the server with all current owned estates. </summary>
    /// <returns> The owned Sanction info, even if location is no longer valid.
    Task<HubResponse<List<SanctionInfo>>> UpdateOwnedSanctions(OwnedEstates dto);

    /// <summary> Retrieves the Audit log for a Sanction. </summary>
    Task<HubResponse<List<SanctionAuditRecord>>> GetSanctionAuditLog(SanctionAuditFetch dto);

    /// <summary> Retrieves the banned users for a Sanction. </summary>
    Task<HubResponse<List<SanctionBannedUser>>> GetSanctionBannedUsers(SanctionDto sanction);

    /// <summary> Updates the Roles via addition, removal, or updating existing. </summary>
    Task<HubResponse> SanctionRolesUpdate(SanctionRolesUpdate dto);

    /// <summary> Updates a SanctionPairs roles. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.AssignRoles"/></remarks>
    Task<HubResponse<SanctionPairInfo>> SanctionSetUserRoles(SanctionPairRoles dto);

    /// <summary> Marks a Sanction as public or private. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeVisibility"/></remarks>
    Task<HubResponse> SanctionSetVisibility(SanctionVisibilityDto dto);

    /// <summary> Sets the datasync preferences of a sanction. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangePreferences"/></remarks>
    Task<HubResponse> SanctionSetPreferences(SanctionPreferencesDto dto);

    /// <summary> Updates the sanctions profile images. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeProfile"/></remarks>
    Task<HubResponse> SanctionSetProfileImages(SanctionProfileImagesDto dto);

    /// <summary> Updates the sanctions profiles contents. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeProfile"/></remarks>
    Task<HubResponse> SanctionSetProfileContent(SanctionProfileContentDto dto);

    /// <summary> Sets or clears the SanctionGroups password. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangePassword"/></remarks>
    Task<HubResponse> SanctionSetPassword(SanctionPasswordDto dto);

    /// <summary> Updates the SanctionName or ChatlogName. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeNames"/></remarks>
    Task<HubResponse> SanctionSetName(SanctionNamesDto dto);

    /// <summary> Updates the Icon, IconColor, LabelColor, BorderColor, GradientColor. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeStyle"/></remarks>
    Task<HubResponse> SanctionSetStyle(SanctionStyleDto dto);

    /// <summary> Changes the <see cref="SanctionAccess"/> of another SanctionPair. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.ChangeUserAccess"/></remarks>
    Task<HubResponse> SanctionSetUserAccess(SanctionUserAccessDto dto);

    /// <summary> Bans a SanctionedPair from the SanctionedGroup for a spesified or infinite time. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.BanMembers"/></remarks>
    Task<HubResponse> SanctionBanUser(SanctionBanDto dto);

    /// <summary> Unbans a SanctionedPair from the SanctionedGroup. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.BanMembers"/></remarks>
    Task<HubResponse> SanctionUnbanUser(SanctionPairDto dto);

    /// <summary> Removes the specified users from the SanctionedGroup. </summary>
    /// <remarks> Action requires <see cref="SanctionAccess.RemoveMembers"/></remarks>
    Task<HubResponse> SanctionRemoveUsers(SanctionCleanupDto dto);

    /// <summary> Join a SanctionedGroup for the given ID and optional password. </summary>
    /// <returns> The current SanctionPairs, online, offline, and visible, and associated data. </returns>
    Task<HubResponse<SanctionDataFull>> SanctionJoin(SanctionDto sanction, string password);

    /// <summary>
    ///   Leave a SanctionedGroup, optionally unpairing with the Groups 
    ///   users not paired with elsewhere, if provided. Other paramaters can be included.
    /// </summary>
    Task<HubResponse> SanctionLeave(SanctionDto sanction);
    #endregion Sanctions

    #region Radar
    /// <summary>
    ///   Updates the server via Redis of the clients current location. <para/>
    ///   In addition the client should provide which radar features 
    ///   they opted into, so the returned result can contain the data 
    ///   for the new location.
    /// </summary>
    /// <returns>
    ///   The resulting data for the new location based on your Opt-In settings, including:
    ///   <list type="bullet">
    ///     <item> <b>ChatHistory</b> - The most recent chat history validated by the server. </item>
    ///     <item> <b>RadarUsers</b> - The list of RadarMembers in the area. </item>
    ///     <item> <b>RadarGroupUsers</b> - The list of RadarGroupMembers in the area. </item>
    ///   </list>
    /// </returns>
    Task<HubResponse<LocationUpdateResult>> UpdateLocation(LocationUpdate updateDto);
    /// <summary> Joins the RadarChat for the location stored on the server. </summary>
    /// <param name="joinDto"> Info for your client that will be stored via Redis for this location. </param>
    /// <returns> Returns the recent messages for the area, if the join was valid. </returns>
    Task<HubResponse<List<LoggedRadarChatMessage>>> RadarChatJoin(RadarChatMember joinDto);
    /// <summary> Update the stored permissions on redis, and inform others of this change. </summary>
    Task<HubResponse> RadarChatPermissionChange(RadarChatMember updateDto);
    /// <summary> Sends a chat message to the RadarChat in the current location. </summary>
    Task<HubResponse> RadarSendChat(SentRadarMessage messageDto);
    /// <summary> Manually leaves the RadarChat for the current area </summary>
    Task<HubResponse> RadarChatLeave();
    /// <summary> Joins the PublicRadar for the current location. All locations should be valid. </summary>
    /// <param name="joinDto"> The permissions for the PublicRadar to store on Redis. </param>
    /// <returns> The list of RadarMembers in this area aside from yourself. </returns>
    /// <remarks> This is not a RadarGroup, it is like an Anonymous locator. </remarks>
    Task<HubResponse<List<RadarMember>>> RadarAreaJoin(RadarMember joinDto);
    /// <summary> Update the stored permissions on redis, and inform others of this change. </summary>
    Task<HubResponse> RadarAreaPermissionChange(RadarMember updateDto);
    /// <summary> Leaves the current PublicRadar. (TODO: Maybe have this leave the RadarGroup as well?) </summary>
    Task<HubResponse> RadarAreaLeave();
    /// <summary>
    ///   Joins the public RadarGroup. <br/>
    ///   This automatically creates RadarPairs with the returned 
    ///   users, excluding those blocked or paused. <para />
    ///   You are able to pause these users with a 3 hour timeout. <br/>
    ///   RadarGroup pauses expire after 5 hours of inactivity.
    /// </summary>
    /// <param name="joinDto"> The permissions for the RadarGroup to store on Redis. </param>
    /// <returns> The other RadarGroup Members currently present, aside from yourself. </returns>
    /// <remarks> <b>RadarGroups are not allowed in residential areas.</b></remarks>
    Task<HubResponse<List<RadarGroupMember>>> RadarGroupJoin(RadarGroupJoin joinDto);
    /// <summary> Update the stored permissions on redis, and inform others of this change. </summary>
    Task<HubResponse> RadarGroupPermissionChange(RadarGroupMember updateDto);
    /// <summary> Leaves the current RadarGroup </summary>
    Task<HubResponse> RadarGroupLeave();
    #endregion Radar

    #region Reporting
    Task<HubResponse> UserReportProfile(ProfileReport dto);
    Task<HubResponse> UserReportSanction(SanctionReport dto);
    Task<HubResponse> UserReportRadar(RadarReport dto);
    Task<HubResponse> UserReportChat(RadarChatReport dto);
    #endregion Reporting

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

    #endregion SERVER_CALLS
}

