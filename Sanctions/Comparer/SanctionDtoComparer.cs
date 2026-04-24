namespace SundouleiaAPI.Sanctions;

/// <summary>
///   Compares two SanctionDto objects based on their SID.
/// </summary>
public class SanctionDtoComparer : IEqualityComparer<SanctionDto>
{
    private static SanctionDtoComparer _instance = new();

    private SanctionDtoComparer()
    { }

    public static SanctionDtoComparer Instance => _instance;

    /// <summary>
    ///   Determines if the SanctionDto objects are equal based on their SID.
    /// </summary>
    public bool Equals(SanctionDto? x, SanctionDto? y)
    {
        if (x is null || y is null)
            return false;
        return x.Sanction.SID.Equals(y.Sanction.SID, StringComparison.Ordinal);
    }

    public int GetHashCode(SanctionDto obj)
        => obj.Sanction.SID.GetHashCode();
}
