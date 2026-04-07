namespace SundouleiaAPI.Radar;

/// <summary>
///   The type of owned housing location
/// </summary>
public enum SanctionHouseType : sbyte
{
    Apartment = 0,
    Personal = 1,
    FreeCompany = 2,
}

/// <summary>
///   The ClientStructs TerritoryIntendedUse enum, relayed in server-side context.
/// </summary>
public enum IntendedUse : byte
{
    Town = 0, // Forbid
    Overworld = 1,
    Inn = 2,
    Dungeon = 3,
    VariantDungeon = 4,
    MordionGaol = 5,
    StartingArea = 6,
    QuestAreaBeforeTrialDungeon = 7,
    AllianceRaid = 8,
    PreEwOverworldQuestBattle = 9,
    Trial = 10,
    Unknown11 = 11,
    WaitingRoom = 12,
    HousingOutdoor = 13,
    HousingIndoor = 14, // Forbid
    SoloOverworldInstances = 15, // Quest Instanced Areas
    Raid1 = 16,
    Raid2 = 17,
    Frontline = 18, // Forbid
    ChocoboSquareOld = 19, // Old
    ChocoboRacing = 20,
    Firmament = 21,
    SanctumOfTheTwelve = 22,
    GoldSaucer = 23,
    OriginalStepsOfFaith = 24, // Old
    LordOfVerminion = 25,
    ExploratoryMissions = 26, // Only Diadem?
    HallOfTheNovice = 27,
    CrystallineConflict = 28, // Forbid
    SoloDuty = 29,
    GrandCompanyBarracks = 30,
    DeepDungeon = 31,
    Seasonal = 32,
    TreasureMapInstance = 33,
    SeasonalInstancedArea = 34,
    TripleTriadBattlehall = 35,
    ChaoticRaid = 36,
    CrystallineConflictCustomMatch = 37, // Forbid
    HuntingGrounds = 38,
    RivalWings = 39, // Forbid
    Unknown40 = 40,
    Eureka = 41,
    Unknown42 = 42,
    TheCalamityRetold = 43,
    LeapOfFaith = 44,
    MaskedCarnival = 45,
    OceanFishing = 46,
    Diadem = 47,
    Bozja = 48,
    IslandSanctuary = 49,
    TripleTriadOpenTournament = 50,
    TripleTriadInvitationalParlor = 51,
    DelubrumReginae = 52,
    DelubrumReginaeSavage = 53,
    EndwalkerMsqSoloOverworld = 54, // Endwalker Quest Instanced Areas
    Unknown55 = 55,
    Elysion = 56, // Tribal Instance
    CriterionDungeon = 57,
    CriterionDungeonSavage = 58,
    Blunderville = 59, // Fall Guys :o
    CosmicExploration = 60,
    OccultCrescent = 61,
    Unknown62 = 62,
    Unknown63 = 63,
    Unknown64 = 64,

    UNK = byte.MaxValue
}

/// <summary>
///   Stores a struct of information in relation to a TerritoryId.
/// </summary>
/// <param name="Id"> The Territories PlaceRegionID </param>
/// <param name="RegionName"> The Territories PlaceRegion Name </param>
/// <param name="TerritoryId"> The TerritoryID </param>
/// <param name="TerritoryName"> The name of that Territory </param>
public readonly record struct PlaceRegionData(ushort Id, string RegionName, ushort TerritoryId, string TerritoryName);