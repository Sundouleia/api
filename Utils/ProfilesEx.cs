using SundouleiaAPI.Profiles;
using SundouleiaAPI.User;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SundouleiaAPI;
#nullable enable

/// <summary>
///   Converter for PrimativeShapes using System.Text.Json over NewtonsoftJson. <br/>
///   Designed to hopefully prevent the Newtonsoft to be required for the API or server.
/// </summary>
public class PrimativeShapeConverter : JsonConverter<IPrimativeShape>
{
    public override IPrimativeShape? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        // Check for 'type' due to Note: We check for "type" (camelCase) because of our JsonSerializerOptions
        if (!root.TryGetProperty("type", out var typeProperty))
            throw new JsonException("Missing 'type' property on shape.");

        var shapeType = (PrimShapeType)typeProperty.GetInt32();
        var rawJson = root.GetRawText();

        return shapeType switch
        {
            PrimShapeType.Circle => JsonSerializer.Deserialize<PrimativeCircle>(rawJson, options),
            PrimShapeType.Rect => JsonSerializer.Deserialize<PrimativeRect>(rawJson, options),
            PrimShapeType.Gradient => JsonSerializer.Deserialize<PrimativeGradient>(rawJson, options),
            PrimShapeType.Quad => JsonSerializer.Deserialize<PrimativeQuad>(rawJson, options),
            PrimShapeType.Line => JsonSerializer.Deserialize<PrimativeLine>(rawJson, options),
            PrimShapeType.Path => JsonSerializer.Deserialize<PrimativePath>(rawJson, options),
            _ => throw new JsonException($"UNK PrimativeShapeType: {shapeType}")
        };
    }

    // Write to an (object) cast of the value so it reflects all properties of the concrete class.
    public override void Write(Utf8JsonWriter writer, IPrimativeShape value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, (object)value, options);
}


public enum ValidationError
{
    Valid,
    NamePos,
    PronounsPos,
    InterestsRectOutside,
    DescriptionRectOutside,
    RectOverlap,
    BadColorOpacity,
    BadShapes,
    EmptyWhitespace,
    TooManyShapes,
    InvalidPath,
    OtherError,
}

public static class ProfilesEx
{
    public const int MAX_DISPLAYNAME_LEN = 20;
    public const int MAX_PRONOUNS_LEN = 20;
    public const int MAX_DESCRIPTION_LEN = 800; // Maybe increase.
    public const int MAX_SHAPES = 50;

    // For UI
    public const float BASE_WIDTH = 400f;
    public const float BASE_HEIGHT = 711f;
    public const float SANCTION_BASE_WIDTH = 600f;
    public const float SANCTION_BASE_HEIGHT = 400f;
    public const float SANCTION_BANNER_HEIGHT = 200f;
    public const float ICON_WIDTH = 256f;

    // Raw ImageSize
    public static readonly Vector2 MaxIconSize = new Vector2(256, 256);
    public static readonly Vector2 MaxUserBackgroundSize = new Vector2(1080, 1920);
    public static readonly Vector2 MaxSanctionBannerSize = new Vector2(900, 300);

    public static ValidationError RunValidation(UserProfileV1 up, float borderSize)
    {
        var profileSize = new Vector2(BASE_WIDTH, BASE_HEIGHT);
        var frameSize = new Vector2(borderSize);
        var infoMin = frameSize;
        var infoMax = profileSize - frameSize;

        if (up.Theme.Shapes.Count > MAX_SHAPES)
            return ValidationError.TooManyShapes;
        if (up.DisplayName.Length > 0 && string.IsNullOrWhiteSpace(up.DisplayName))
            return ValidationError.EmptyWhitespace;
        if (up.Pronouns.Length > 0 && string.IsNullOrWhiteSpace(up.Pronouns))
            return ValidationError.EmptyWhitespace;
        if (up.Description.Length > 0 && string.IsNullOrWhiteSpace(up.Description))
            return ValidationError.EmptyWhitespace;
        if (OutOfBounds(up.Theme.NamePos))
            return ValidationError.NamePos;
        if (OutOfBounds(up.Theme.SubNamePos))
            return ValidationError.PronounsPos;
        if (OutOfBounds(up.Theme.InterestsMin) || OutOfBounds(up.Theme.InterestsMax))
            return ValidationError.InterestsRectOutside;
        if (OutOfBounds(up.Theme.BioMin) || OutOfBounds(up.Theme.BioMax))
            return ValidationError.DescriptionRectOutside;

        // Insure that the rect of the activities and description don't overlap.
        if (up.Theme.InterestsMin.X < up.Theme.BioMax.X && up.Theme.InterestsMax.X > up.Theme.BioMin.X &&
            up.Theme.InterestsMin.Y < up.Theme.BioMax.Y && up.Theme.InterestsMax.Y > up.Theme.BioMin.Y)
            return ValidationError.RectOverlap;

        // Should also validate colors.
        if (!IsOpaque(up.Theme.StaticButtons.Color) || !IsOpaque(up.Theme.BottomColor) || !IsOpaque(up.Theme.BorderColor) ||
            !IsOpaque(up.Theme.MainText.Color) || !IsOpaque(up.Theme.PillText.Color) || !IsOpaque(up.Theme.BioText.Color))
        {
            return ValidationError.BadColorOpacity;
        }

        if (up.Theme.Shapes.Any(s => s is PrimativePath path && path.Nodes.Count > 25))
            return ValidationError.InvalidPath;

        // We could do a check to see if the full shape is out of bounds though.
        return ValidationError.Valid;

        bool OutOfBounds(Vector2 pos)
            => pos.X < infoMin.X || pos.Y < infoMin.Y || pos.X > infoMax.X || pos.Y > infoMax.Y;
    }

    private static bool IsOpaque(uint color)
        => (color >> 24) == 0xFF;
}
#nullable disable