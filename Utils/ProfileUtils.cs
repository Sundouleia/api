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
    OtherError,
}

public static class ProfileUtils
{
    public const int MAX_DISPLAYNAME_LEN = 20;
    public const int MAX_PRONOUNS_LEN = 20;
    public const int MAX_DESCRIPTION_LEN = 500; // Maybe increase.
    public const int MAX_SHAPES = 50;

    public const float BASE_WIDTH = 400f;
    public const float BASE_HEIGHT = 711f;
    // Temp placeholders
    public const float SANCTION_BASE_WIDTH = 600f;
    public const float SANCTION_BASE_HEIGHT = 250f;
    public const float SANCTION_ICON_LENGTH = 256f;

    private static readonly JsonSerializerOptions Settings = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        // Forgiveness Settings (To be more graceful like Newtonsoft, but can remove later)
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
        // Ensure PrimativeShapeConverter exists.
        Converters = { new PrimativeShapeConverter() }
    };

    /// <summary>
    ///   Retrieves the UserProfileV1 from a JSON string.
    /// </summary>
    /// <exception cref="JsonException">Thrown when the JSON is invalid or cannot be deserialized.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the input JSON string is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the deserialization fails for reasons other than invalid JSON.</exception>
    public static UserProfileV1 GetUserV1FromJson(string? jsonData)
    {
        jsonData = (jsonData ?? string.Empty).Trim();
        if (jsonData.StartsWith("{", StringComparison.Ordinal))
            return JsonSerializer.Deserialize<UserProfileV1>(jsonData, Settings) ?? new UserProfileV1();
        // Debug output for invalid format.
        return new UserProfileV1 { Version = 1, Description = jsonData };
    }

    public static string WriteToJson(this UserProfileV1 profileV1)
    {
        profileV1 ??= new UserProfileV1();
        return JsonSerializer.Serialize(profileV1, Settings);
    }

    public static SanctionProfileV1 GetSanctionV1FromJson(string? jsonData)
    {
        jsonData = (jsonData ?? string.Empty).Trim();
        if (jsonData.StartsWith("{", StringComparison.Ordinal))
            return JsonSerializer.Deserialize<SanctionProfileV1>(jsonData, Settings) ?? new SanctionProfileV1();
        // Debug output for invalid format.
        return new SanctionProfileV1 { Version = 1, Description = jsonData };
    }

    public static string WriteToJson(this SanctionProfileV1 profileV1)
    {
        profileV1 ??= new SanctionProfileV1();
        return JsonSerializer.Serialize(profileV1, Settings);
    }

    public static ValidationError RunValidation(UserProfileV1 up, float borderSize)
    {
        var profileSize = new Vector2(BASE_WIDTH, BASE_HEIGHT);
        var frameSize = new Vector2(borderSize);
        var infoMin = frameSize;
        var infoMax = profileSize - frameSize;

        if (up.CustomShapes.Count > MAX_SHAPES)
            return ValidationError.TooManyShapes;
        if (up.DisplayName.Length > 0 && string.IsNullOrWhiteSpace(up.DisplayName))
            return ValidationError.EmptyWhitespace;
        if (up.Pronouns.Length > 0 && string.IsNullOrWhiteSpace(up.Pronouns))
            return ValidationError.EmptyWhitespace;
        if (up.Description.Length > 0 && string.IsNullOrWhiteSpace(up.Description))
            return ValidationError.EmptyWhitespace;
        if (OutOfBounds(up.NamePos))
            return ValidationError.NamePos;
        if (OutOfBounds(up.SubNamePos))
            return ValidationError.PronounsPos;
        if (OutOfBounds(up.InterestsMin) || OutOfBounds(up.InterestsMax))
            return ValidationError.InterestsRectOutside;
        if (OutOfBounds(up.DescriptionMin) || OutOfBounds(up.DescriptionMax))
            return ValidationError.DescriptionRectOutside;

        // Insure that the rect of the activities and description don't overlap.
        if (up.InterestsMin.X < up.DescriptionMax.X && up.InterestsMax.X > up.DescriptionMin.X && up.InterestsMin.Y < up.DescriptionMax.Y && up.InterestsMax.Y > up.DescriptionMin.Y)
            return ValidationError.RectOverlap;

        // Should also validate colors.
        if (!IsOpaque(up.Colors.ButtonColor) || !IsOpaque(up.Colors.BottomColor) || !IsOpaque(up.Colors.BorderColor) ||
            !IsOpaque(up.Colors.TextColor) || !IsOpaque(up.Colors.PillTextColor) || !IsOpaque(up.Colors.AboutMeColor))
        {
            return ValidationError.BadColorOpacity;
        }
        // We could do a check to see if the full shape is out of bounds though.
        return ValidationError.Valid;

        bool OutOfBounds(Vector2 pos)
            => pos.X < infoMin.X || pos.Y < infoMin.Y || pos.X > infoMax.X || pos.Y > infoMax.Y;
    }

    private static bool IsOpaque(uint color)
        => (color >> 24) == 0xFF;
}
#nullable disable