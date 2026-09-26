using System.Collections.Frozen;
using System.Numerics;

namespace SundouleiaAPI.Profiles;

public enum Alignment
{
    Left,
    Center,
    Right
}

public enum TextFont
{
    Default,
    Scaled,
    Game,   
    Header,
    Subtitle,
    Title,
}

public enum CharaInterest
{
    Achievements,
    AllianceRaids,
    Art,
    BlueMage,
    CasualRaids,
    Crafting,
    CriterionDungeons,
    DeepDungeons,
    Eeping,
    Events,
    ExtremeTrials,
    Fishing,
    Gathering,
    Glamour,
    Gposing,
    Housing,
    Hunts,
    Immersion,
    IslandSanctuary,
    Lore,
    Maps,
    Modding,
    Music,
    Performance,
    PvP,
    Questing,
    Raiding,
    Roleplay,
    SavageRaids,
    Sightseeing,
    Socializing,
    Story,
    Streaming,
    Venues,
    UltimateRaids,
}

public enum SanctionTagCategory
{
    Type,
    Theme,
    Entertainment,
    Activities,
    GamesAndGambling,
    Benifits,
    RpStyle,
    Audience,
}

public enum SanctionTag
{
    // Type
    Arcade,
    ArtGallery,
    Asylum,
    Bakery,
    Bar,
    BathHouse,
    Boutique,
    Cafe,
    Casino,
    Church,
    Clinic,
    Concert,
    Courthouse,
    Den,
    Dojo,
    FightClub,
    Guildhall,
    Hospital,
    Inn,
    Jail,
    Library,
    Lounge,
    MaidCafe,
    Market,
    Museum,
    Nightclub,
    Office,
    PoliceStation,
    Restaurant,
    School,
    Shop,
    Shrine,
    Spa,
    Speakeasy,
    Tavern,
    TeaHouse,
    Temple,
    Theatre,

    // Setting
    Cozy,
    Cyberpunk,
    Eastern,
    Fantasy,
    Gothic,
    Indoor,
    Modern,
    OpenWorld,
    Outdoor,
    SciFi,
    Spooky,
    Steampunk,
    Tropical,
    Void,
    Western,

    // Entertainment
    Artists,
    Bards,
    Courtesans,
    Dancers,
    Disco,
    OpenStage,
    Performance,
    Strippers,
    Stylists,
    SyncDJ,
    Tarot,
    TwitchDJ,

    // Activies
    Events,
    Fashion,
    Glamour,
    Movies,
    Photography,
    Relaxing,
    Roleplay,
    Social,
    Tournament,
    Vibing,

    // Games & Gambling
    Bingo,
    Blackjack,
    Deathroll,
    Gambling,
    Poker,
    Roulette,
    TexasHoldem,
    TripleTriad,
    Trivia,
    TruthOrDare,

    // Perks & Access
    Giveaways,
    Inclusive,
    LGBTQIAFriendly,
    Open24h7d,
    Raffles,
    VIP,

    // RP Style
    ICFriendly,
    ICOnly,
    OOCFriendly,
    OOCOnly,

    // Audience & Rating
    Adult,
    Age18Plus,
    BDSM,
    Fetish,
    Hardcore,
    KinkFriendly,
    NSFL,
    NSFW,
    SFW,
}

/// <summary>
///   Defines which directions something should be applied to. <br/>
///   Designed for general use, but intended for top-left-down-right application.
/// </summary>
[Flags]
public enum DirectionFlags : int
{
    /// <summary> Does not apply to any direction. </summary>
    None = 0 << 0,

    /// <summary> applies to the top direction. </summary>
    Top = 1 << 1,

    /// <summary> applies to the left direction. </summary>
    Left = 1 << 2,

    /// <summary> applies to the right direction. </summary>
    Right = 1 << 3,

    /// <summary> applies to the bottom direction. </summary>
    Bottom = 1 << 4,

    /// <summary> applies to the top and bottom directions. </summary>
    Vertically = Top | Bottom,

    /// <summary> applies to the left and right directions. </summary>
    Horizontally = Left | Right,

    /// <summary> applies to all directions. </summary>
    All = Top | Left | Right | Bottom,
}

/// <summary>
///   Only the Corners properties of ImDrawFlags for API Use. <br/>
/// </summary>
[Flags]
public enum CornerDrawFlags : int
{
    /// <summary> Doesn't round anything. </summary>
    None = unchecked(0),

    /// <summary> Applies rounding to the TopLeft. </summary>
    TopLeft = unchecked(16),

    /// <summary> Applies rounding to the TopRight. </summary>
    TopRight = unchecked(32),

    /// <summary> Applies rounding to the BottomLeft. </summary>
    BottomLeft = unchecked(64),

    /// <summary> Applies rounding to the BottomRight. </summary>
    BottomRight = unchecked(128),

    /// <summary> Behaves the same as None. </summary>
    RoundingNone = unchecked(256),

    /// <summary> Applies rounding to the Top corners. </summary>
    Top = unchecked(48),

    /// <summary> Applies rounding to the Bottom corners. </summary>
    Bottom = unchecked(192),

    /// <summary> Applies rounding to the Left corners. </summary>
    Left = unchecked(80),

    /// <summary> Applies rounding to the Right corners. </summary>
    Right = unchecked(160),

    /// <summary> Applies rounding to all 4 corners. </summary>
    RoundAll = unchecked(240),
}

public static class SanctionTagExtensions
{
    public static readonly SanctionTag[] AllTags = Enum.GetValues<SanctionTag>();

    // Pre-computed lookup to map a tagname to its color
    private static readonly FrozenDictionary<string, uint> NameToColorMap =
        AllTags.ToFrozenDictionary(t => t.ToName(), t => t.ToColor(), StringComparer.OrdinalIgnoreCase);

    public static readonly (SanctionTagCategory Category, string Name, SanctionTag[] Tags)[] CategorizedTags =
        Enum.GetValues<SanctionTagCategory>()
            .Select(cat => (Category: cat, Name: cat.ToName(), Tags: AllTags.Where(t => t.GetCategory() == cat).ToArray())).ToArray();

    public static SanctionTagCategory GetCategory(this SanctionTag tag) => tag switch
    {
        <= SanctionTag.Theatre => SanctionTagCategory.Type,
        <= SanctionTag.Western => SanctionTagCategory.Theme,
        <= SanctionTag.TwitchDJ => SanctionTagCategory.Entertainment,
        <= SanctionTag.Vibing => SanctionTagCategory.Activities,
        <= SanctionTag.TruthOrDare => SanctionTagCategory.GamesAndGambling,
        <= SanctionTag.VIP => SanctionTagCategory.Benifits,
        <= SanctionTag.OOCOnly => SanctionTagCategory.RpStyle,
        _ => SanctionTagCategory.Audience,
    };

    /// <summary>
    ///   Retrieves the color by the tags name.
    /// </summary>
    public static uint GetColorByName(string tagName)
        => NameToColorMap.GetValueOrDefault(tagName, 0xFFAAAAAA);

    /// <summary>
    ///   Gets the static color associated with a SanctionTag.
    /// </summary>
    public static uint ToColor(this SanctionTag tag) => tag switch
    {
        SanctionTag.SFW => 0xFF66BB6Au,
        SanctionTag.NSFW or SanctionTag.Age18Plus or SanctionTag.Adult => 0xFF5350EFu,
        SanctionTag.NSFL or SanctionTag.Hardcore => 0xFF2F2FD3u,
        SanctionTag.LGBTQIAFriendly => 0xFFE082FFu,
        SanctionTag.VIP => 0xFF4FD5FFu,

        // Revise later, this is temporary
        _ => tag.GetCategory() switch
        {
            SanctionTagCategory.Type => 0xFFF7C34Fu,
            SanctionTagCategory.Theme => 0xFFD893CEu,
            SanctionTagCategory.Entertainment => 0xFFBA68C8u,
            SanctionTagCategory.Activities => 0xFF81C784u,
            SanctionTagCategory.GamesAndGambling => 0xFF4DB7FFu,
            SanctionTagCategory.Benifits => 0xFF80DEEAu,
            SanctionTagCategory.RpStyle => 0xFFFFB490u,
            SanctionTagCategory.Audience => 0xFF9090EFu,
            _ => 0xFFAAAAAA,
        }
    };

    public static string ToName(this SanctionTagCategory category) => category switch
    {
        SanctionTagCategory.Type => "Venue Type",
        SanctionTagCategory.Theme => "Theme",
        SanctionTagCategory.Entertainment => "Entertainment",
        SanctionTagCategory.Activities => "Activities",
        SanctionTagCategory.GamesAndGambling => "Games & Gambling",
        SanctionTagCategory.Benifits => "Benifits",
        SanctionTagCategory.RpStyle => "RP Style",
        SanctionTagCategory.Audience => "Audience",
        _ => "Other",
    };

    public static string ToName(this SanctionTag tag) => tag switch
    {
        // Type
        SanctionTag.Arcade => "Arcade",
        SanctionTag.ArtGallery => "Art Gallery",
        SanctionTag.Asylum => "Asylum",
        SanctionTag.Bakery => "Bakery",
        SanctionTag.Bar => "Bar",
        SanctionTag.BathHouse => "Bathhouse",
        SanctionTag.Boutique => "Boutique",
        SanctionTag.Cafe => "Cafe",
        SanctionTag.Casino => "Casino",
        SanctionTag.Church => "Church",
        SanctionTag.Clinic => "Clinic",
        SanctionTag.Concert => "Concert",
        SanctionTag.Courthouse => "Courthouse",
        SanctionTag.Den => "Den",
        SanctionTag.Dojo => "Dojo",
        SanctionTag.FightClub => "Fight Club",
        SanctionTag.Guildhall => "Guildhall",
        SanctionTag.Hospital => "Hospital",
        SanctionTag.Inn => "Inn",
        SanctionTag.Jail => "Jail",
        SanctionTag.Library => "Library",
        SanctionTag.Lounge => "Lounge",
        SanctionTag.MaidCafe => "Maid Cafe",
        SanctionTag.Market => "Market",
        SanctionTag.Museum => "Museum",
        SanctionTag.Nightclub => "Nightclub",
        SanctionTag.Office => "Office",
        SanctionTag.PoliceStation => "Police Station",
        SanctionTag.Restaurant => "Restaurant",
        SanctionTag.School => "School",
        SanctionTag.Shop => "Shop",
        SanctionTag.Shrine => "Shrine",
        SanctionTag.Spa => "Spa",
        SanctionTag.Speakeasy => "Speakeasy",
        SanctionTag.Tavern => "Tavern",
        SanctionTag.TeaHouse => "Tea House",
        SanctionTag.Temple => "Temple",
        SanctionTag.Theatre => "Theatre",

        // Theme
        SanctionTag.Cozy => "Cozy",
        SanctionTag.Cyberpunk => "Cyberpunk",
        SanctionTag.Eastern => "Eastern",
        SanctionTag.Fantasy => "Fantasy",
        SanctionTag.Gothic => "Gothic",
        SanctionTag.Indoor => "Indoor",
        SanctionTag.Modern => "Modern",
        SanctionTag.OpenWorld => "Open World",
        SanctionTag.Outdoor => "Outdoor",
        SanctionTag.SciFi => "Sci-Fi",
        SanctionTag.Spooky => "Spooky",
        SanctionTag.Steampunk => "Steampunk",
        SanctionTag.Tropical => "Tropical",
        SanctionTag.Void => "Void",
        SanctionTag.Western => "Western",

        // Entertainment
        SanctionTag.Artists => "Artists",
        SanctionTag.Bards => "Bards",
        SanctionTag.Courtesans => "Courtesans",
        SanctionTag.Dancers => "Dancers",
        SanctionTag.Disco => "Disco",
        SanctionTag.OpenStage => "Open Stage",
        SanctionTag.Performance => "Performance",
        SanctionTag.Strippers => "Strippers",
        SanctionTag.Stylists => "Stylists",
        SanctionTag.SyncDJ => "Sync DJ",
        SanctionTag.Tarot => "Tarot",
        SanctionTag.TwitchDJ => "Twitch DJ",

        // Activities
        SanctionTag.Events => "Events",
        SanctionTag.Fashion => "Fashion",
        SanctionTag.Glamour => "Glamour",
        SanctionTag.Movies => "Movies",
        SanctionTag.Photography => "Photography",
        SanctionTag.Relaxing => "Relaxing",
        SanctionTag.Roleplay => "Roleplay",
        SanctionTag.Social => "Social",
        SanctionTag.Tournament => "Tournament",
        SanctionTag.Vibing => "Vibing",

        // Games & Gambling
        SanctionTag.Bingo => "Bingo",
        SanctionTag.Blackjack => "Blackjack",
        SanctionTag.Deathroll => "Deathroll",
        SanctionTag.Gambling => "Gambling",
        SanctionTag.Poker => "Poker",
        SanctionTag.Roulette => "Roulette",
        SanctionTag.TexasHoldem => "Texas Hold'em",
        SanctionTag.TripleTriad => "Triple Triad",
        SanctionTag.Trivia => "Trivia",
        SanctionTag.TruthOrDare => "Truth or Dare",

        // Perks & Access
        SanctionTag.Giveaways => "Giveaways",
        SanctionTag.Inclusive => "Inclusive",
        SanctionTag.LGBTQIAFriendly => "LGBTQIA+ Friendly",
        SanctionTag.Open24h7d => "Open 24/7",
        SanctionTag.Raffles => "Raffles",
        SanctionTag.VIP => "VIP",

        // RP Style
        SanctionTag.ICFriendly => "IC Friendly",
        SanctionTag.ICOnly => "IC Only",
        SanctionTag.OOCFriendly => "OOC Friendly",
        SanctionTag.OOCOnly => "OOC Only",

        // Audience & Rating
        SanctionTag.Adult => "Adult",
        SanctionTag.Age18Plus => "18+",
        SanctionTag.BDSM => "BDSM",
        SanctionTag.Fetish => "Fetish",
        SanctionTag.Hardcore => "Hardcore",
        SanctionTag.KinkFriendly => "Kink Friendly",
        SanctionTag.NSFL => "NSFL",
        SanctionTag.NSFW => "NSFW",
        SanctionTag.SFW => "SFW",
        _ => "UNK",
    };


}