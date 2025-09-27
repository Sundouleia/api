using MessagePack;

namespace SundouleiaAPI.Network;

/// <summary>
///     Stores the base64 compressed image data for the callers profile data.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ProfileImage(string NewBase64Image);
