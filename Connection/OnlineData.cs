using MessagePack;
using SundouleiaAPI.User;

namespace SundouleiaAPI.Connection;

/// <summary>
///   Compact record used when retrieving online data for a connected user. <br/>
///   Includes info about which user connections we have that are online,
///   who we paused, and who paused us.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineData(List<OnlineUser> OnlineUsers, List<PausedUser> PausedUsers, List<PausedUser> PausedBy);

/// <summary>
///   The Data Transfer Object for an online user. 
/// </summary>
/// <param name="User">The UserData object containing the UID</param>
/// <param name="Ident">The Identity of the online user, hashed for security. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUser(UserData User, string Ident) : UserDto(User);

/// <summary>
///   Gets the PauseState data for a user, including how long they are paused for.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PausedUser(UserData User, TimeSpan Duration) : UserDto(User);

/// <summary>
///   A list of <see cref="PausedUser"/> entries.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PausedUsers(List<PausedUser> Users);

/// <summary>
///   Pauses multiple users for a set duration
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkUserPause(List<UserData> Users, TimeSpan Duration);