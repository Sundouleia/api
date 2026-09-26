namespace SundouleiaAPI.Profiles;

/// <summary>
///   The contents of a SanctionProfile outside validations and ImageData.
/// </summary>
public sealed class SanctionProfileV2 : IEquatable<SanctionProfileV2>
{
    public int Version { get; set; } = 2;

    public bool ShowAddress { get; set; } = true;
    public string Punchline { get; set; } = string.Empty;
    public List<SanctionBadge> Badges { get; set; } = [];
    public SanctionProfileTheme Theme { get; set; } = new();

    public bool Equals(SanctionProfileV2? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        // Compare value types and strings
        return Version == other.Version &&
            ShowAddress == other.ShowAddress &&
            Punchline == other.Punchline &&
            Badges.SequenceEqual(other.Badges) &&
            Theme.Equals(other.Theme);
    }

    public override bool Equals(object? obj)
        => Equals(obj as SanctionProfileV2);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Version);
        hash.Add(ShowAddress);
        hash.Add(Punchline);
        hash.Add(Badges.Count);
        hash.Add(Theme);
        return hash.ToHashCode();
    }
}

public record SanctionBadge(uint IconId, bool HQ, string Name, string Tooltip, DateTime EarnedAt, bool ShowTime);
