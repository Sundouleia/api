using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

// (( Could maybe make this into a modifiable class but idk, probably best to keep as record. ))
namespace SundouleiaAPI.Network;

/// <summary>
///     Holds all essential information of permissions and information between 
///     2 paired users.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPair(UserData User, PairPerms OwnPerms, GlobalPerms Globals, PairPerms Perms) : UserDto(User)
{
    // Perms the Client has for this User
    public PairPerms OwnPerms { get; set; } = OwnPerms;

    // Permissions this User has for the Client
    public GlobalPerms Globals { get; set; } = Globals;
    public PairPerms Perms { get; set; } = Perms;
}
