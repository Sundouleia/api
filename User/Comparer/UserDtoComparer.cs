namespace SundouleiaAPI.User;

/// <summary>
///   Compares two UserDto objects based on their UID.
/// </summary>
public class UserDtoComparer : IEqualityComparer<UserDto>
{
    private static UserDtoComparer _instance = new();

    private UserDtoComparer()
    { }

    public static UserDtoComparer Instance => _instance;

    /// <summary>
    ///   Determines if the UserDto objects are equal based on their UID.
    /// </summary>
    public bool Equals(UserDto? x, UserDto? y)
    {
        if (x is null || y is null)
            return false;
        return x.User.UID.Equals(y.User.UID, StringComparison.Ordinal);
    }

    public int GetHashCode(UserDto obj)
        => obj.User.UID.GetHashCode();
}
