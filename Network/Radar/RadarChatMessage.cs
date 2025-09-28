using SundouleiaAPI.Data;
using MessagePack;

namespace SundouleiaAPI.Network;

// When a chat message for a particular zone is sent back to other people
// in the radar range.
[MessagePackObject(keyAsPropertyName: true)]
public record RadarChatMessage(UserData Sender, ushort WorldId, ushort TerritoryId, string Message);
