namespace SundouleiaAPI.Radar;

/// <summary>
///   The areas that the client allows joining for RadarGroups.
/// </summary>
[Flags]
public enum RadarGroupAreas : ushort
{
    /// <summary>
    ///   Effectively 'Off'.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    ///   Any Housing player housing area.
    /// </summary>
    Residential = 1 << 0,

    /// <summary>
    ///   All Major Cities (Limsa, Gridania, Ul'dah, Ishgard, Kugane, Crystarium, Eulmore)
    /// </summary>
    MajorCities = 1 << 1,

    /// <summary>
    ///   Instanced content (Dungeons, Trials, Raids, Alliance Raids, etc)
    /// </summary>
    Duties = 1 << 2,

    /// <summary>
    ///   Frontlines, RivalWings, CC, ext.
    /// </summary>
    PVP = 1 << 3,

    /// <summary>
    ///   All other areas not covered by the above.
    /// </summary>
    Other = 1 << 4,


    All = Residential | MajorCities | Duties | PVP | Other,
}
