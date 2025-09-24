using MessagePack;

namespace SundouleiaAPI.Hub;

/// <summary> Generic Return Codes for API calls. </summary>
/// <remarks> Value can be null or nonexistant. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HubResponse(SundouleiaApiEc ErrorCode);


/// <summary> Generic Return Codes for API calls. </summary>
/// <remarks> Value can be null or nonexistant. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HubResponse<T>(SundouleiaApiEc ErrorCode) : HubResponse(ErrorCode)
{
    public T? Value { get; set; }
}
