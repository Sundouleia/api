using System.Numerics;

namespace SundouleiaAPI.Profiles;

public enum PrimShapeType
{
    Circle = 0,
    Rect = 1,
    Gradient = 2,
    Quad = 3,

    Icon = 10,
    
    Line = 20,
    Path = 21,
}

/// <summary>
///   Required variables for PrimativeShapes
/// </summary>
public interface IPrimativeShape : IEquatable<IPrimativeShape>
{
    /// <summary>
    ///   The kind of PrimativeShape being drawn
    /// </summary>
    public PrimShapeType Type { get; }

    /// <summary>
    ///   Distinct Identifier for this shape. <br/>
    ///   Could've used ints but didnt want to deal with import/export id missmatch issues.
    /// </summary>
    public Guid Id { get; }

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

    /// <summary>
    ///   Creates a clone of the primative shape with a new GUID.
    /// </summary>>
    public IPrimativeShape Clone();
}

public class PrimativeCircle : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Circle;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Center { get; set; } = new Vector2(25);
    public float Radius { get; set; } = 10f;
    public int Edges { get; set; } = 0;
    public float Stroke { get; set; } = 0f;
    public IPrimativeShape Clone() => new PrimativeCircle
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Center = Center,
        Radius = Radius,
        Edges = Edges,
        Stroke = Stroke
    };
    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

public class PrimativeRect : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Rect;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = new Vector2(50);
    public float Rounding { get; set; } = 0f;
    public float Stroke { get; set; } = 0f;
    public CornerDrawFlags CornerFlags { get; set; } = CornerDrawFlags.RoundAll;
    public IPrimativeShape Clone() => new PrimativeRect
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Min = Min,
        Max = Max,
        Rounding = Rounding,
        Stroke = Stroke,
        CornerFlags = CornerFlags
    };
    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

/// <summary>
///   A rect with a color for each corner, allowing for gradients and color blending.
/// </summary>
public class PrimativeGradient : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Gradient;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;
    public uint Color1 { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF444444;
    public uint Color3 { get; set; } = 0xFFCCCCCC;
    public uint Color4 { get; set; } = 0xFF888888;

    public Vector2 Min { get; set; } = Vector2.Zero;
    public Vector2 Max { get; set; } = new Vector2(50);
    public float Stroke => 0f;
    public IPrimativeShape Clone() => new PrimativeGradient
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        Color3 = Color3,
        Color4 = Color4,
        Min = Min,
        Max = Max
    };
    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

/// <summary>
///   A Primative 4-Point rect.
/// </summary>
public class PrimativeQuad : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Quad;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = true;

    public uint Color1  { get; set; } = 0xFF000000;
    public uint Color2 { get; set; } = 0xFF555555;

    public Vector2 P1 { get; set; } = Vector2.Zero;
    public Vector2 P2 { get; set; } = new Vector2(0, 50);
    public Vector2 P3 { get; set; } = new Vector2(50);
    public Vector2 P4 { get; set; } = new Vector2(50, 0);
    public float Stroke { get; set; } = 0f;
    public IPrimativeShape Clone() => new PrimativeQuad
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Color1 = Color1,
        Color2 = Color2,
        P1 = P1,
        P2 = P2,
        P3 = P3,
        P4 = P4,
        Stroke = Stroke
    };

    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

public class PrimativeIcon : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Icon;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => true;
    public uint Color1 { get; set; } = 0xFFFFFFFF;

    public Vector2 Pos { get; set; } = Vector2.Zero;
    public float Size { get; set; } = 128f;
    public float Rounding { get; set; } = 90f;
    public float Stroke => 0;
    public IPrimativeShape Clone() => new PrimativeIcon
    {
        MoveWithExpand = MoveWithExpand,
        Color1 = Color1,
        Pos = Pos,
        Size = Size,
        Rounding = Rounding
    };

    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

public class PrimativeLine : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Line;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape => false;
    public uint Color1 { get; set; } = 0xFF000000;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public Vector2 End { get; set; } = new Vector2(50);
    public float Stroke { get; set; } = 0f;

    public IPrimativeShape Clone() => new PrimativeLine
    {
        MoveWithExpand = MoveWithExpand,
        Color1 = Color1,
        Start = Start,
        End = End,
        Stroke = Stroke
    };

    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}

public enum PrimativePathType
{
    LineTo,
    ArcBend,
    BezierTo,
}

public class PrimativePathNode
{
    public PrimativePathType Instruction;
    public Vector2 Point;
    public Vector2 CtrlPoint1;
    public Vector2 CtrlPoint2;
    public int Segments;
}

public class PrimativePath : IPrimativeShape
{
    public PrimShapeType Type => PrimShapeType.Path;
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool MoveWithExpand { get; set; } = false;
    public bool FillShape { get; set; } = false;
    public Vector2 Start { get; set; } = Vector2.Zero;
    public List<PrimativePathNode> Nodes { get; set; } = [];
    public uint Color1 { get; set; } = 0xFF000000;
    public float Stroke { get; set; } = 0f;

    public IPrimativeShape Clone() => new PrimativePath
    {
        MoveWithExpand = MoveWithExpand,
        FillShape = FillShape,
        Start = Start,
        Color1 = Color1,
        Stroke = Stroke,
        Nodes = [.. Nodes.Select(n => new PrimativePathNode
        {
            Instruction = n.Instruction,
            Point = n.Point,
            CtrlPoint1 = n.CtrlPoint1,
            CtrlPoint2 = n.CtrlPoint2,
            Segments = n.Segments
        })]
    };

    public bool Equals(IPrimativeShape? other) => other is not null && Id == other.Id && Type == other.Type;
    public override bool Equals(object? obj) => Equals(obj as IPrimativeShape);
    public override int GetHashCode() => HashCode.Combine(Id, Type);
}