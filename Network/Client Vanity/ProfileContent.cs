using SundouleiaAPI.Enums;
using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary>
///     Data about the contents within a user's profile, without the image data.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ProfileContent
{
    public bool           IsPublic       { get; set; } = false;
    public bool           IsNSFW         { get; set; } = false;
    public bool           Flagged        { get; set; } = false;
    public PublicityScope AvatarVis      { get; set; } = PublicityScope.Private;
    public PublicityScope DescriptionVis { get; set; } = PublicityScope.Private;
    public PublicityScope DecorationVis  { get; set; } = PublicityScope.Private;
    public string         Description    { get; set; } = string.Empty;
    public int            CompletedTotal { get; set; } = 0; // How many achievements earned.
    public int            ChosenTitleId  { get; set; } = 0; // WIP, not installed yet.

    public PlateBG      MainBG              { get; set; } = PlateBG.Default;
    public PlateBorder  MainBorder          { get; set; } = PlateBorder.Default;
    public PlateBG      AvatarBG            { get; set; } = PlateBG.Default;
    public PlateBorder  AvatarBorder        { get; set; } = PlateBorder.Default;
    public PlateOverlay AvatarOverlay       { get; set; } = PlateOverlay.Default;
    public PlateBG      DescriptionBG       { get; set; } = PlateBG.Default;
    public PlateBorder  DescriptionBorder   { get; set; } = PlateBorder.Default;
    public PlateOverlay DescriptionOverlay  { get; set; } = PlateOverlay.Default;
}

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileContent
{
    public bool IsNSFW   { get; set; } = false;
    public bool Reported { get; set; } = false;
    
    public string Punchline   { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public uint BgColor        { get; set; } = 0xFF000000;
    public uint PrimaryColor   { get; set; } = 0xFF888888;
    public uint SecondaryColor { get; set; } = 0xFF444444;
    public uint AccentColor    { get; set; } = 0xFF770000;

    public byte  OpenDaysBitMask { get; set; } = 0;
    public int[] Tags            { get; set; } = [];
    public bool  VenueScope      { get; set; } = false;
}
