namespace SundouleiaAPI.Hub;

public static class HubResponseBuilder
{
    // Success.
    public static HubResponse Yippee() => new(SundouleiaApiEc.Success);
    public static HubResponse<T> Yippee<T>(T value) => new(SundouleiaApiEc.Success) { Value = value };
    
    // Fail.
    public static HubResponse AwDangIt(SundouleiaApiEc error) => new(error);
    public static HubResponse<T> AwDangIt<T>(SundouleiaApiEc error) => new(error) { Value = default };
    public static HubResponse<T> AwDangIt<T>(SundouleiaApiEc error, T value) => new(error) { Value = value };
}
