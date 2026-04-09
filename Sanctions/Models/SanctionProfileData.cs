using MessagePack;

namespace SundouleiaAPI.Sanctions;

/// <summary> A SanctionedGroups profile image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileImageData(string Base64Logo = "", string Base64Banner = "");

/// <summary> A SanctionedGroups profile content data, excluding the image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SanctionProfileContentData
{
    public bool IsNSFW { get; set; } = false;
    public bool Reported { get; set; } = false;

    public string Punchline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public uint BgColor { get; set; } = 0xFF000000;
    public uint PrimaryColor { get; set; } = 0xFF888888;
    public uint SecondaryColor { get; set; } = 0xFF444444;
    public uint AccentColor { get; set; } = 0xFF770000;

    public byte OpenDaysBitMask { get; set; } = 0;
    public int[] Tags { get; set; } = [];
    public bool VenueScope { get; set; } = false;
}