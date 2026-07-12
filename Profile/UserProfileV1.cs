using System.Numerics;

namespace SundouleiaAPI.Profiles;

public enum Alignment
{
    Left,
    Center,
    Right
}

/// <summary>
///   The contents of a UserProfile outside validations and ImageData.
/// </summary>
public class UserProfileV1
{
    public int Version { get; set; } = 1;

    // If we should allow the profile to expand when it should.
    public bool CanExpand { get; set; } = false;

    // Border Fade
    public float FadeDistance { get; set; } = 0f;
    public DirectionFlags FadeDirections { get; set; } = DirectionFlags.All;

    // A personalized name that appears only in the users profile.
    public string DisplayName { get; set; } = string.Empty;
    public Vector2 NamePos { get; set; } = Vector2.Zero;
    public bool NameMoveWithExpand { get; set; } = false;

    // Optional Pronouns displayfield.
    public string Pronouns { get; set; } = string.Empty;
    public Vector2 SubNamePos { get; set; } = Vector2.Zero;
    public bool SubNameMoveWithExpand { get; set; } = false;

    // Interest Pills
    public bool ShowInterestText { get; set; } = true;
    public List<string> Interests { get; set; } = [];
    public float PillPadding { get; set; } = 0f; // 0f means use default height.
    public float PillRounding { get; set; } = 90f;
    public Alignment PillAlignment { get; set; } = Alignment.Left;
    public Vector2 InterestsMin { get; set; } = Vector2.Zero;
    public Vector2 InterestsMax { get; set; } = Vector2.Zero;
    public bool InterestsMoveWithExpand { get; set; } = true;

    // Description Area
    public string Description { get; set; } = string.Empty;
    public Vector2 DescriptionMin { get; set; } = Vector2.Zero;
    public Vector2 DescriptionMax { get; set; } = Vector2.Zero;
    public bool DescriptionMoveWithExpand { get; set; } = true;

    // Coloring
    public UserProfileColors Colors { get; set; } = new();

    // Custom Stylization Shapes
    public List<IPrimativeShape> CustomShapes { get; set; } = [];
}

/// <summary>
///   Defines which directions something should be applied to. <br/>
///   Designed for general use, but intended for top-left-down-right application.
/// </summary>
[Flags]
public enum DirectionFlags : int
{
    /// <summary> Does not apply to any direction. </summary>
    None = 0 << 0,

    /// <summary> applies to the top direction. </summary>
    Top = 1 << 1,

    /// <summary> applies to the left direction. </summary>
    Left = 1 << 2,

    /// <summary> applies to the right direction. </summary>
    Right = 1 << 3,

    /// <summary> applies to the bottom direction. </summary>
    Bottom = 1 << 4,

    /// <summary> applies to the top and bottom directions. </summary>
    Vertically = Top | Bottom,

    /// <summary> applies to the left and right directions. </summary>
    Horizontally = Left | Right,

    /// <summary> applies to all directions. </summary>
    All = Top | Left | Right | Bottom,
}

/// <summary>
///   Only the Corners properties of ImDrawFlags for API Use. <br/>
/// </summary>
[Flags]
public enum CornerDrawFlags : int
{
    /// <summary> Doesn't round anything. </summary>
    None = unchecked(0),

    /// <summary> Applies rounding to the TopLeft. </summary>
    TopLeft = unchecked(16),

    /// <summary> Applies rounding to the TopRight. </summary>
    RoundCornersTopRight = unchecked(32),

    /// <summary> Applies rounding to the BottomLeft. </summary>
    RoundCornersBottomLeft = unchecked(64),

    /// <summary> Applies rounding to the BottomRight. </summary>
    RoundCornersBottomRight = unchecked(128),

    /// <summary> Behaves the same as None. </summary>
    RoundCornersNone = unchecked(256),

    /// <summary> Applies rounding to the Top corners. </summary>
    RoundCornersTop = unchecked(48),

    /// <summary> Applies rounding to the Bottom corners. </summary>
    RoundCornersBottom = unchecked(192),

    /// <summary> Applies rounding to the Left corners. </summary>
    RoundCornersLeft = unchecked(80),

    /// <summary> Applies rounding to the Right corners. </summary>
    RoundCornersRight = unchecked(160),

    /// <summary> Applies rounding to all 4 corners. </summary>
    RoundCornersAll = unchecked(240),
}