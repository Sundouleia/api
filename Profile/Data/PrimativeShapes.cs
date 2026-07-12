using System.Numerics;

namespace SundouleiaAPI.Profiles;

public enum PrimShapeType
{
    Circle,
    Rect,
    Gradient,
    Quad,
    Line,
    Path,
    // Could add more in the future like dotted lines ext.
}

/// <summary>
///   Required variables for PrimativeShapes
/// </summary>
public interface IPrimativeShape
{
    /// <summary>
    ///   The kind of PrimativeShape being drawn
    /// </summary>
    public PrimShapeType Type { get; }

    /// <summary>
    ///   Shift down this shapes offset when expanded.
    /// </summary>
    public bool MoveWithExpand { get; }

    /// <summary>
    ///   If we only draw the outline, or fill it as a solid.
    /// </summary>
    public bool FillShape { get; }

    /// <summary>
    ///   The Primary color used by the primative shape.
    /// </summary>
    public uint Color1 { get; }

    /// <summary>
    ///   0 Defaults to no stroke
    /// </summary>
    public float Stroke { get; }
}

public class PrimativeCircle : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Circle;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Center { get; set; } = Vector2.Zero;
    public float Radius { get; set; } = 0f;
    public float Stroke { get; set; } = 0f;
}

public class PrimativeRect : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Rect;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = Vector2.Zero;
    public float Rounding { get; set; } = 0f;
    public float Stroke { get; set; } = 0f;
    public CornerDrawFlags CornerFlags { get; set; } = CornerDrawFlags.RoundCornersAll;
}

/// <summary>
///   A rect with a color for each corner, allowing for gradients and color blending.
/// </summary>
public class PrimativeGradient : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Gradient;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF444444;
    public uint Color3 { get; set; } = 0xFF888888;
    public uint Color4 { get; set; } = 0xFFCCCCCC;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = Vector2.Zero;
    public float Stroke { get; set; } = 0f;
}

/// <summary>
///   A Primative 4-Point rect.
/// </summary>
public class PrimativeQuad : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Quad;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;

    public uint Color1  { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 P1 { get; set; } = Vector2.Zero;
    public Vector2 P2 { get; set; } = Vector2.Zero;
    public Vector2 P3 { get; set; } = Vector2.Zero;
    public Vector2 P4 { get; set; } = Vector2.Zero;
    public float Stroke { get; set; } = 0f;
}

public class PrimativeLine : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Line;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => false;
    public uint Color1 { get; set; } = 0xFF000000;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public Vector2 End { get; set; } = Vector2.Zero;
    public float Stroke { get; set; } = 0f;
}

public enum PrimativePathType
{
    LineTo,
    ArcTo,
    BezierTo,
}

public class PrimativePathNode
{
    public PrimativePathType Instruction;
    public Vector2 DestPoint;
    public Vector2 Control1; // For Bezier
    public Vector2 Control2; // For Bezier
    public float Radius;     // For ArcTo
}

public class PrimativePath : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Path;
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => false;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public List<PrimativePathNode> Nodes { get; set; } = [];
    public uint Color1 { get; set; } = 0xFF000000;
    public float Stroke { get; set; } = 0f;
}