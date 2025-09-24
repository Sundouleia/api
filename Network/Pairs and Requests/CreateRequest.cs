using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary> 
///     The User we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequest(UserData User, bool IsTemp, string Message) : UserDto(User);
