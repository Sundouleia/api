namespace SundouleiaAPI.Sanctions;

public class SanctionDataComparer : IEqualityComparer<SanctionData>
{
    private static SanctionDataComparer _instance = new();

    private SanctionDataComparer()
    { }

    public static SanctionDataComparer Instance => _instance;

    public bool Equals(SanctionData? x, SanctionData? y)
    {
        if (x is null || y is null)
            return false;
        return x.SID.Equals(y.SID, StringComparison.Ordinal);
    }

    public int GetHashCode(SanctionData obj)
        => obj.SID.GetHashCode();
}
