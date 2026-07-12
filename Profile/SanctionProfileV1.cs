using System.Numerics;

namespace SundouleiaAPI.Profiles;

/// <summary>
///   The contents of a SanctionProfile outside validations and ImageData.
/// </summary>
public sealed class SanctionProfileV1
{
    public int Version { get; set; } = 1;

    public float InnerGlowDistance { get; set; } = 0f;
    public DirectionFlags InnerGlowEdges { get; set; } = DirectionFlags.None;
    public float BannerFadeHeight { get; set; } = 0f;

    public Vector2 IconPos { get; set; } = Vector2.Zero;
    public Vector2 IconSizeOverride { get; set; } = Vector2.Zero;
    public float IconStroke { get; set; } = 0f;

    // Where the SID is listed.
    public Vector2 SIDPos { get; set; } = Vector2.Zero;

    // The large text that shows the SanctionData.DisplayName.
    public Vector2 DispNamePos { get; set; } = Vector2.Zero;

    // Punchline
    public string Punchline { get; set; } = string.Empty;
    public Alignment PunchlineAlignment {get; set; } = Alignment.Left;
    public Vector2 PunchlineMin { get; set; } = Vector2.Zero;
    public Vector2 PunchlineMax { get; set; } = Vector2.Zero;

    // Sanction Tags
    public List<string> Tags { get; set; } = [];
    public float TagPadding { get; set; } = 0f;
    public float TagRounding { get; set; } = 0f;
    public Alignment TagsAlignment { get; set; } = Alignment.Left;
    public Vector2 TagsMin { get; set; } = Vector2.Zero;
    public Vector2 TagsMax { get; set; } = Vector2.Zero;

    // Description Space.
    public string Description { get; set; } = string.Empty;
    public Vector2 DescriptionMin { get; set; } = Vector2.Zero;
    public Vector2 DescriptionMax { get; set; } = Vector2.Zero;

    public List<SanctionBadge> Badges { get; set; } = [];
    public Vector2 BadgesMin { get; set; } = Vector2.Zero;
    public Vector2 BadgesMax { get; set; } = Vector2.Zero;

    public SanctionProfileColors Colors { get; set; } = new();

    public byte OpenDaysBitMask { get; set; } = 0;
    public string VenueScopeKey { get; set; } = string.Empty; // Future VenueScope IPC
}

public record SanctionBadge(uint IconId, bool HQ, string Name, string Tooltip, DateTime EarnedAt, bool ShowTime);
