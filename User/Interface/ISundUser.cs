namespace SundouleiaAPI.User;

/// <summary>
///   A User who is a Sundesmo or in a joined Sanction. <br/>
///   Users in the PublicRadar and RadarGroup are considered 'loose pairs'
/// </summary>
public interface IPairedUser : IComparable<IPairedUser>
{
    public UserData User { get; }
}

/// <summary>
///   Defines any SundouleiaUser that comes from a Radar source.
/// </summary>
public interface IRadarSyncMember
{
    public string RadarId { get; }
    public UserData User { get; }
    public string HashedIdent { get; }
    public string RadarName { get; }
}

public interface ISundouleiaUser
{
    public UserData User { get; }
}