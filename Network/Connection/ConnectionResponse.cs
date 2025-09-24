using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary> 
///     The data send to a client that just successfully connected to Sundouleia servers.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionResponse(UserData User) : UserDto(User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }

    public GlobalPerms GlobalPerms { get; init; } = new();
    public AccountReputation Reputation { get; set; } = new();

    // All Auth Uids associated with the connected user.
    public List<string> ActiveAccountUidList { get; init; } = new();
}
