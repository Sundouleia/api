using System.Numerics;

namespace SundouleiaAPI.Profiles;

public sealed class SanctionProfileTheme : IEquatable<SanctionProfileTheme>
{
    // Profile Window & Ruleset
    public uint BgColorTop { get; set; } = 0xFF444444;
    public uint BgColorBottom { get; set; } = 0xFF222222;
    public uint BorderColor { get; set; } = uint.MaxValue;
    public uint BorderFade { get; set; } = 0xFF000000;
    public uint BorderFadeInner { get; set; } = uint.MinValue;
    public float FadeDistance { get; set; } = 0f;
    public DirectionFlags FadeDirections { get; set; } = DirectionFlags.All;

    public uint DividerColor { get; set; } = 0xFF000000;
    public float DividerFadeDistance { get; set; } = 15f;
    public float DividerStroke { get; set; } = 1f;

    // Text Styles
    public PfpTextStyle StaticButtons { get; set; } = new();

    public PfpTextStyle MainText { get; set; } = new();
    public PfpTextStyle SIDText { get; set; } = new();
    public PfpTextStyle PunchlineText { get; set; } = new();
    public PfpTextStyle BioText { get; set; } = new();
    public PfpTextStyle TagText { get; set; } = new(); // Maybe remove.

    public Vector2 IconPos { get; set; } = Vector2.Zero;


    // Layout & Bounding Boxes
    public Vector2 DispNamePos { get; set; } = new Vector2(20);
    public Vector2 SIDPos { get; set; } = new Vector2(20, 40);
    public Vector2 LocationPos { get; set; } = new Vector2(20, 60);
    public Vector2 PunchlinePos { get; set; } = new Vector2(100, 200);

    public Vector2 TagsMin { get; set; } = new Vector2(150, 200);
    public Vector2 TagsMax { get; set; } = new Vector2(250, 300);

    public Vector2 BioMin { get; set; } = new Vector2(500, 75);
    public Vector2 BioMax { get; set; } = new Vector2(600, 150);

    public Vector2 BadgesMin { get; set; } = new Vector2(700, 25);
    public Vector2 BadgesMax { get; set; } = new Vector2(850, 125);

    // Behaviors
    public float IconSizeOverride { get; set; } = 63f; // 64-312 is size override range.
    public uint IconBorderColor { get; set; } = uint.MaxValue;
    public float IconBorderStroke { get; set; } = 4f;


    public bool TagBorders { get; set; } = false;
    public float TagPadding { get; set; } = 0f;
    public float TagRounding { get; set; } = 90f;
    public float TagGapX { get; set; } = 4f;
    public float TagGapY { get; set; } = 4f;
    public Alignment TagsAlignment { get; set; } = Alignment.Left;
    public Alignment BadgesAlignment { get; set; } = Alignment.Left;


    public bool Equals(SanctionProfileTheme? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return BgColorTop == other.BgColorTop &&
            BgColorBottom == other.BgColorBottom &&
            BorderColor == other.BorderColor &&
            BorderFade == other.BorderFade &&
            BorderFadeInner == other.BorderFadeInner &&
            FadeDistance == other.FadeDistance &&
            FadeDirections == other.FadeDirections &&
            DividerColor == other.DividerColor &&
            DividerFadeDistance == other.DividerFadeDistance &&
            DividerStroke == other.DividerStroke &&
            TagsAlignment == other.TagsAlignment &&
            BadgesAlignment == other.BadgesAlignment &&
            IconSizeOverride == other.IconSizeOverride &&
            IconBorderColor == other.IconBorderColor &&
            IconBorderStroke == other.IconBorderStroke &&

            TagBorders == other.TagBorders &&
            TagPadding == other.TagPadding &&
            TagRounding == other.TagRounding &&
            TagGapX == other.TagGapX &&
            TagGapY == other.TagGapY &&

            StaticButtons.Equals(other.StaticButtons) &&
            MainText.Equals(other.MainText) &&
            SIDText.Equals(other.SIDText) &&
            PunchlineText.Equals(other.PunchlineText) &&
            BioText.Equals(other.BioText) &&
            TagText.Equals(other.TagText) &&

            IconPos.Equals(other.IconPos) &&
            IconSizeOverride.Equals(other.IconSizeOverride) &&

            DispNamePos.Equals(other.DispNamePos) &&
            SIDPos.Equals(other.SIDPos) &&
            PunchlinePos.Equals(other.PunchlinePos) &&

            TagsMin.Equals(other.TagsMin) &&
            TagsMax.Equals(other.TagsMax) &&

            BioMin.Equals(other.BioMin) &&
            BioMax.Equals(other.BioMax);
    }

    public override bool Equals(object? obj)
        => Equals(obj as SanctionProfileTheme);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(BgColorTop);
        hash.Add(BorderColor);
        hash.Add(MainText);
        hash.Add(DispNamePos);
        hash.Add(TagsMin);
        hash.Add(BioMin);
        hash.Add(IconPos);
        hash.Add(TagBorders);
        hash.Add(TagPadding);
        hash.Add(TagRounding);
        hash.Add(TagGapX);
        hash.Add(TagGapY);
        return hash.ToHashCode();
    }
}