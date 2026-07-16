using System.Numerics;

namespace SundouleiaAPI.Profiles;

public sealed class UserProfileTheme : IEquatable<UserProfileTheme>
{
    // Profile Window & Ruleset
    public bool CanExpand { get; set; } = false;
    public uint BorderColor { get; set; } = uint.MaxValue;
    public uint BorderFade { get; set; } = 0xFF000000;
    public uint BorderFadeInner { get; set; } = uint.MinValue;
    public float FadeDistance { get; set; } = 5f;
    public DirectionFlags FadeDirections { get; set; } = DirectionFlags.All;
    public uint BottomColor { get; set; } = 0xFF000000;

    // Text Styles
    public PfpTextStyle StaticButtons { get; set; } = new();
    public PfpTextStyle MainText { get; set; } = new();
    public PfpTextStyle PillText { get; set; } = new();
    public PfpTextStyle BioText { get; set; } = new();

    // Layout & Bounding Boxes
    public Vector2 NamePos { get; set; } = Vector2.Zero;
    public bool NameMoveWithExpand { get; set; } = false;

    public Vector2 SubNamePos { get; set; } = Vector2.Zero;
    public bool SubNameMoveWithExpand { get; set; } = false;

    public Vector2 InterestsMin { get; set; } = Vector2.Zero;
    public Vector2 InterestsMax { get; set; } = Vector2.Zero;
    public bool InterestsMoveWithExpand { get; set; } = true;

    public Vector2 BioMin { get; set; } = Vector2.Zero;
    public Vector2 BioMax { get; set; } = Vector2.Zero;
    public bool BioMoveWithExpand { get; set; } = true;

    // Pill Shapes & Behaviors
    public uint PillColor { get; set; } = 0xFF787878;
    public uint PillBorder { get; set; } = uint.MinValue;
    public float PillPadding { get; set; } = 0f;
    public float PillRounding { get; set; } = 90f;
    public Alignment PillAlignment { get; set; } = Alignment.Left;
    public bool ShowInterestText { get; set; } = true;

    // UNLIMITED SHAPES
    public List<IPrimativeShape> Shapes { get; set; } = [];

    public bool Equals(UserProfileTheme? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return CanExpand == other.CanExpand &&
               FadeDistance == other.FadeDistance &&
               FadeDirections == other.FadeDirections &&
               BorderColor == other.BorderColor &&
               BorderFade == other.BorderFade &&
               BottomColor == other.BottomColor &&
               NameMoveWithExpand == other.NameMoveWithExpand &&
               SubNameMoveWithExpand == other.SubNameMoveWithExpand &&
               InterestsMoveWithExpand == other.InterestsMoveWithExpand &&
               BioMoveWithExpand == other.BioMoveWithExpand &&
               PillColor == other.PillColor &&
               PillBorder == other.PillBorder &&
               PillPadding == other.PillPadding &&
               PillRounding == other.PillRounding &&
               PillAlignment == other.PillAlignment &&
               ShowInterestText == other.ShowInterestText &&
               NamePos.Equals(other.NamePos) &&
               SubNamePos.Equals(other.SubNamePos) &&
               InterestsMin.Equals(other.InterestsMin) &&
               InterestsMax.Equals(other.InterestsMax) &&
               BioMin.Equals(other.BioMin) &&
               BioMax.Equals(other.BioMax) &&
               StaticButtons.Equals(other.StaticButtons) &&
               MainText.Equals(other.MainText) &&
               PillText.Equals(other.PillText) &&
               BioText.Equals(other.BioText) &&
               Shapes.SequenceEqual(other.Shapes);
    }

    public override bool Equals(object? obj)
        => Equals(obj as UserProfileTheme);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(CanExpand);
        hash.Add(BorderColor);
        hash.Add(NamePos);
        hash.Add(MainText);
        hash.Add(Shapes.Count);
        return hash.ToHashCode();
    }
}