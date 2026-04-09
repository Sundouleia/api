namespace SundouleiaAPI.Requests;
#pragma warning disable IDE1006 // Naming Styles
public class RequestComparer : IEqualityComparer<PairRequest>
{
    private static readonly RequestComparer _instance = new();

    private RequestComparer()
    { }

    public static RequestComparer Instance => _instance;

    public bool Equals(PairRequest? x, PairRequest? y)
    {
        if (x is null || y is null) return false;
        return x.User.UID.Equals(y.User.UID, StringComparison.Ordinal)
            && x.Target.UID.Equals(y.Target.UID, StringComparison.Ordinal);
    }

    public int GetHashCode(PairRequest obj)
    {
        return HashCode.Combine(obj.User.UID, obj.Target.UID);
    }
}
#pragma warning restore IDE1006 // Naming Styles
