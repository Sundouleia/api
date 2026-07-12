namespace SundouleiaAPI.Profiles;

// Colors for a UserProfile.
public sealed class UserProfileColors
{
    public uint ButtonColor { get; set; }
    public uint ButtonShadow { get; set; }

    // Special for expanded windows
    public uint BottomColor { get; set; }

    public uint BorderColor { get; set; }
    public uint BorderFade { get; set; }

    // For Pills
    public uint PillColor { get; set; } // Inherits "Border Color"
    public uint PillBorder { get; set; } // Defaults to 0

    // Text
    public uint TextColor { get; set; } // "TextColor" (on reset)
    public uint TextShadow { get; set; } // Inherits ???

    // Interests Pill Text, for those who need seprate colors for contrast matching.
    public uint PillTextColor { get; set; } // Inherits "TextColor" (on reset)
    public uint PillTextShadow { get; set; } // Inherits "IdentifierShadow" (on reset)

    // Description text colors if contrast is needed.
    public uint AboutMeColor { get; set; }
    public uint AboutMeShadow { get; set; }
}

public sealed class SanctionProfileColors
{
    public uint ButtonColor { get; set; }
    public uint ButtonShadow { get; set; }

    public uint Divider { get; set; }
    public uint DividerFade { get; set; }

    public uint BackgroundTop { get; set; }
    public uint BackgroundBottom { get; set; }

    // Outer Border
    public uint Outline { get; set; }
    public uint InnerGlow { get; set; }

    public uint IconOutline { get; set; }

    public uint SID { get; set; }
    public uint SIDShadow { get; set; }

    public uint Title { get; set; }
    public uint TitleShadow { get; set; }

    public uint Punchline { get; set; }
    public uint PunchlineShadow { get; set; }

    public uint Tag { get; set; }
    public uint TagBorder { get; set; }
    public uint TagText { get; set; }
    public uint TagTextShadow { get; set; }

    // Description text colors if contrast is needed.
    public uint Description { get; set; }
    public uint DescriptionShadow { get; set; }
}
