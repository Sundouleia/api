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
    public bool           Disabled       { get; set; } = false;
    public PublicityScope AvatarVis      { get; set; } = PublicityScope.Private;
    public PublicityScope DescriptionVis { get; set; } = PublicityScope.Private;
    public PublicityScope DecorationVis  { get; set; } = PublicityScope.Private;
    public string         Description    { get; set; } = string.Empty;
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
