using System.Text.Json.Serialization;

namespace SundouleiaAPI.Profiles;

// Colors for a UserProfile.
public sealed class UserProfileColors
{
    public uint ButtonColor { get; set; } = 0xFF000000; // Require Opaque
    public uint ButtonShadow { get; set; } = uint.MinValue;

    public uint BorderColor { get; set; } = 0xFF000000;
    public uint BorderFade { get; set; } = uint.MinValue;

    // Text
    public uint TextColor { get; set; } = 0xFF000000;
    public uint TextShadow { get; set; } = 0xFF000000;
    public float TextShadowOffset { get; set; } = 1f;
    public float TextShadowRadius { get; set; } = 1.5f;

    // For Pills
    public uint PillColor { get; set; } = 0xFF787878;
    public uint PillBorder { get; set; } = uint.MinValue;

    // Interests Pill Text, for those who need seprate colors for contrast matching.
    public uint PillTextColor { get; set; } = 0xFF000000; // Inherits "TextColor" (on reset)
    public uint PillTextShadow { get; set; } = 0xFF000000; // Inherits "IdentifierShadow" (on reset)
    public float PillTextShadowOffset { get; set; } = 1f;
    public float PillTextShadowRadius { get; set; } = 1.5f;

    // Description text colors if contrast is needed.
    public uint DescTextColor { get; set; } = 0xFF000000;
    public uint DescTextShadow { get; set; } = 0xFF000000;
    public float DescTextShadowOffset { get; set; } = 1f;
    public float DescTextShadowRadius { get; set; } = 1.5f;

    // Special for expanded windows
    public uint BottomColor { get; set; } = 0xFF000000;
}

public sealed class SanctionProfileColors
{
    public uint ButtonColor { get; set; } = 0xFF000000;
    public uint ButtonShadow { get; set; } = 0xFF000000;

    public uint Divider { get; set; } = 0xFF000000;
    public uint DividerFade { get; set; } = 0xFF000000;

    public uint BackgroundTop { get; set; } = 0xFF000000;
    public uint BackgroundBottom { get; set; } = 0xFF000000;

    // Outer Border
    public uint Outline { get; set; } = 0xFF000000;
    public uint InnerGlow { get; set; } = 0xFF000000;

    public uint IconOutline { get; set; } = 0xFF000000;

    public uint SID { get; set; } = 0xFF000000;
    public uint SIDShadow { get; set; } = 0xFF000000;

    public uint Title { get; set; } = 0xFF000000;
    public uint TitleShadow { get; set; } = 0xFF000000;

    public uint Punchline { get; set; } = 0xFF000000;
    public uint PunchlineShadow { get; set; } = 0xFF000000;

    public uint Tag { get; set; } = 0xFF000000;
    public uint TagBorder { get; set; } = 0xFF000000;
    public uint TagText { get; set; } = 0xFF000000;
    public uint TagTextShadow { get; set; } = 0xFF000000;

    // Description text colors if contrast is needed.
    public uint Description { get; set; } = 0xFF000000;
    public uint DescriptionShadow { get; set; } = 0xFF000000;
}
