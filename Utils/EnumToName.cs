using SundouleiaAPI.Files;
using SundouleiaAPI.Location;

namespace SundouleiaAPI;
public static class EnumToName
{
    public static string ToName(this DownloadSpeeds speeds)
        => speeds switch
        {
            DownloadSpeeds.Bps => "Byte/s",
            DownloadSpeeds.KBps => "KB/s",
            DownloadSpeeds.MBps => "MB/s",
            _ => "UNK"
        };

    public static string ToDisplayName(this XivIntendedUse use) => use switch
    {
        XivIntendedUse.Town => "Starting Towns",
        XivIntendedUse.Overworld => "Overworld",
        XivIntendedUse.Inn => "Inn",
        XivIntendedUse.Dungeon => "Dungeons",
        XivIntendedUse.VariantDungeon => "Variant Dungeons",
        XivIntendedUse.MordionGaol => "Mordion Gaol",
        XivIntendedUse.StartingArea => "Tutorial Areas",
        XivIntendedUse.QuestAreaBeforeTrialDungeon => "Pre-Content Quest Areas",
        XivIntendedUse.AllianceRaid => "Alliance Raids",
        XivIntendedUse.PreEwOverworldQuestBattle => "Quest Battles",
        XivIntendedUse.Trial => "Trials",
        XivIntendedUse.WaitingRoom => "Waiting Room",
        XivIntendedUse.HousingOutdoor => "Residential Areas",
        XivIntendedUse.HousingIndoor => "Indoor Housing",
        XivIntendedUse.SoloOverworldInstances => "Solo Instances",
        XivIntendedUse.Raid1 => "Raid Content A",
        XivIntendedUse.Raid2 => "Raid Content B",
        XivIntendedUse.Frontline => "Frontlines",
        XivIntendedUse.ChocoboSquareOld => "Chocobo Square (Old)",
        XivIntendedUse.ChocoboRacing => "Chocobo Racing",
        XivIntendedUse.Firmament => "The Firmament",
        XivIntendedUse.SanctumOfTheTwelve => "Sanctum of the Twelve",
        XivIntendedUse.GoldSaucer => "The Gold Saucer",
        XivIntendedUse.OriginalStepsOfFaith => "Steps of Faith (Old)",
        XivIntendedUse.LordOfVerminion => "Lord of Verminion",
        XivIntendedUse.ExploratoryMissions => "Exploratory Missions",
        XivIntendedUse.HallOfTheNovice => "Hall of the Novice",
        XivIntendedUse.CrystallineConflict or XivIntendedUse.CrystallineConflictCustomMatch => "Crystalline Conflict",
        XivIntendedUse.SoloDuty => "Solo Duties",
        XivIntendedUse.GrandCompanyBarracks => "Grand Company Barracks",
        XivIntendedUse.DeepDungeon => "Deep Dungeons",
        XivIntendedUse.Seasonal => "Seasonal Areas",
        XivIntendedUse.TreasureMapInstance => "Treasure Map Areas",
        XivIntendedUse.SeasonalInstancedArea => "Seasonal Instanced Area",
        XivIntendedUse.TripleTriadBattlehall => "Triple Triad",
        XivIntendedUse.ChaoticRaid => "Chaotic Raids",
        XivIntendedUse.HuntingGrounds => "Hunting Grounds",
        XivIntendedUse.RivalWings => "Rival Wings",
        XivIntendedUse.Eureka => "Eureka",
        XivIntendedUse.TheCalamityRetold => "The Calamity Retold",
        XivIntendedUse.LeapOfFaith => "Leap of Faith",
        XivIntendedUse.MaskedCarnival => "The Masked Carnival",
        XivIntendedUse.OceanFishing => "Ocean Fishing",
        XivIntendedUse.Diadem => "Diadem",
        XivIntendedUse.Bozja => "Bozja",
        XivIntendedUse.IslandSanctuary => "Island Sanctuary",
        XivIntendedUse.TripleTriadOpenTournament => "Triple Triad Tournament",
        XivIntendedUse.TripleTriadInvitationalParlor => "Triple Triad Parlor",
        XivIntendedUse.DelubrumReginae => "Delubrum Reginae",
        XivIntendedUse.DelubrumReginaeSavage => "Delubrum Reginae (Savage)",
        XivIntendedUse.EndwalkerMsqSoloOverworld => "Solo Instances (Endwalker)",
        XivIntendedUse.Elysion => "Elysion",
        XivIntendedUse.CriterionDungeon => "Criterion Dungeons",
        XivIntendedUse.CriterionDungeonSavage => "Criterion Dungeons (Savage)",
        XivIntendedUse.Blunderville => "Blunderville",
        XivIntendedUse.CosmicExploration => "Cosmic Explorations",
        XivIntendedUse.OccultCrescent => "Occult Crescent",

        // Unknown / unmapped cases
        XivIntendedUse.Unknown11 or
        XivIntendedUse.Unknown40 or
        XivIntendedUse.Unknown42 or
        XivIntendedUse.Unknown55 or
        XivIntendedUse.Unknown62 or
        XivIntendedUse.Unknown63 or
        XivIntendedUse.Unknown64 or
        XivIntendedUse.UNK => "Unknown",

        _ => "Unknown",
    };
}
