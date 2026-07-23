namespace SundouleiaAPI.Profiles;

/// <summary>
///   The contents of a SanctionProfile outside validations and ImageData.
/// </summary>
public sealed class SanctionProfileV1 : IEquatable<SanctionProfileV1>
{
    public int Version { get; set; } = 1;

    public bool ShowAddress { get; set; } = true;
    public string Punchline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ColoredTag> Tags { get; set; } = [];
    public List<SanctionBadge> Badges { get; set; } = [];
    public SanctionProfileTheme Theme { get; set; } = new();

    public bool Equals(SanctionProfileV1? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        // Compare value types and strings
        return Version == other.Version &&
            ShowAddress == other.ShowAddress &&
            Punchline == other.Punchline &&
            Description == other.Description &&
            Tags.SequenceEqual(other.Tags) &&
            Badges.SequenceEqual(other.Badges) &&
            Theme.Equals(other.Theme);
    }

    public override bool Equals(object? obj)
        => Equals(obj as SanctionProfileV1);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Version);
        hash.Add(ShowAddress);
        hash.Add(Punchline);
        hash.Add(Description);
        hash.Add(Tags.Count);
        hash.Add(Badges.Count);
        hash.Add(Theme);
        return hash.ToHashCode();
    }
}

public record SanctionBadge(uint IconId, bool HQ, string Name, string Tooltip, DateTime EarnedAt, bool ShowTime);
