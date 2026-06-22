using MessagePack;

namespace SundouleiaAPI.Alterations;

[MessagePackObject(keyAsPropertyName: true)]
public record NewModDeltas(List<ValidModFileDto> Added, List<ValidModFileDto> Removed, int UploadingCount)
{
    public bool HasChanges => Added.Count is not 0 || Removed.Count is not 0;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ModDeltas(List<ModFileDto> Added, List<ModFileDto> Removed)
{
    public bool HasChanges => Added.Count is not 0 || Removed.Count is not 0;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ValidModFileDto(string ResolvedPath, string[] GamePaths, bool IsFileSwap)
{
    public string Hash { get; init; } = string.Empty;
    public OwnedObject Source { get; init; } = OwnedObject.Player;
    public string Link { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ModFileDto(string ResolvedPath, string[] GamePaths, bool IsFileSwap)
{
    public string Hash { get; init; } = string.Empty;
    public OwnedObject Source { get; init; } = OwnedObject.Player;
}

public static class DtoExtensions
{
    public static ValidModFileDto ToValid(this ModFileDto file)
        => new(file.ResolvedPath, file.GamePaths, file.IsFileSwap)
        {
            Hash = file.Hash,
            Source = file.Source,
        };

    public static ValidModFileDto ToValid(this ModFileDto file, string link)
        => new(file.ResolvedPath, file.GamePaths, file.IsFileSwap)
        {
            Hash = file.Hash,
            Source = file.Source,
            Link = link
        };

    public static ModFileDto ToBase(this ValidModFileDto valid)
        => new(valid.ResolvedPath, valid.GamePaths, valid.IsFileSwap)
        {
            Hash = valid.Hash,
            Source = valid.Source,
        };
}