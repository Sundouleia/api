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
    public bool Verified { get; set; } = false;

    public string Punchline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public uint BgColor { get; set; } = 0xFF000000;
    public uint PrimaryColor { get; set; } = 0xFF888888;
    public uint SecondaryColor { get; set; } = 0xFF444444;
    public uint AccentColor { get; set; } = 0xFF770000;
    public uint BorderColor { get; set; } = 0xFF770000;
    public bool UseGradient { get; set; } = false;

    public byte OpenDaysBitMask { get; set; } = 0;
    // Split via commas.
    public string[] Tags { get; set; } = [];
    public string VenueScopeKey { get; set; } = string.Empty;
}