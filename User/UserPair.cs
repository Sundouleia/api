using MessagePack;
using SundouleiaAPI.Connection;
using SundouleiaAPI.Permissions;

// (( Could maybe make this into a modifiable class but idk, probably best to keep as record. ))
namespace SundouleiaAPI.User;

/// <summary>
///     A helper record for a return function on accepting a request, 
///     compiling the send online call and add pair call into one!
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AddedUserPair(UserPair Pair, OnlineUser? OnlineInfo);


/// <summary>
///     Holds all essential information of permissions and information between 
///     2 paired users.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPair(UserData User, PairPerms OwnPerms, GlobalPerms Globals, PairPerms Perms, DateTime CreatedAt, string TempAccepterUID) : UserDto(User)
{
    // Perms the Client has for this User
    public PairPerms OwnPerms { get; set; } = OwnPerms;

    // Permissions this User has for the Client
    public GlobalPerms Globals { get; set; } = Globals;
    public PairPerms Perms { get; set; } = Perms;

    public bool IsTemporary => !string.IsNullOrEmpty(TempAccepterUID);
}
