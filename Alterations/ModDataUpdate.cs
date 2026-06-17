using MessagePack;

namespace SundouleiaAPI.Alterations;

//// Contains data of any new mods to be added, or old ones to remove.
//// if not all sent is true, it means there will be additional files sent after, and they should be marked for uploading,
//// after the download is complete.
//[MessagePackObject(keyAsPropertyName: true)]
//public record NewModUpdates(List<ValidFileHash> NewReplacements, List<FileSwapData> NewSwaps, int FilesUploading)
//{
//    public List<string> HashesToRemove  { get; init; } = [];
//    public List<string> SwapsToRemove   { get; init; } = [];

//    public bool HasHashChanges => NewReplacements.Count != 0 || HashesToRemove.Count != 0;
//    public bool HasSwapChanges => NewSwaps.Count != 0 || SwapsToRemove.Count != 0;
//    public bool HasAnyChanges => HasHashChanges || HasSwapChanges;
//}

//[MessagePackObject(keyAsPropertyName: true)]
//public record ModUpdates(List<FileHashData> NewReplacements, List<FileSwapData> NewSwaps)
//{
//    public List<string> HashesToRemove { get; init; } = [];
//    public List<string> SwapsToRemove { get; init; } = [];

//    public bool HasHashChanges => NewReplacements.Count != 0 || HashesToRemove.Count != 0;
//    public bool HasSwapChanges => NewSwaps.Count != 0 || SwapsToRemove.Count != 0;
//    public bool HasAnyChanges  => HasHashChanges || HasSwapChanges;

//    public static ModUpdates Empty => new([], []);
//}

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

///// <summary>
/////   Represents a modded file entry used for ModUpdates.
///// </summary>
///// <param name="FileHash"> The hash of the modded file. </param>
///// <param name="GamePaths"> The game paths this mod affects. </param>
//[MessagePackObject(keyAsPropertyName: true)]
//public record FileHashData(string Hash, string[] GamePaths);

///// <summary>
/////   A FileModData verified via the Sundouleia FileHost for download.
///// </summary>
///// <param name="Hash"> The hash of the modded file. </param>
///// <param name="GamePaths"> The game paths this mod affects. </param>
///// <param name="Link"> Download link provided by the file if it requires download. </param>
//[MessagePackObject(keyAsPropertyName: true)]
//public record ValidFileHash(string Hash, string[] GamePaths, string Link);

///// <summary>
/////   Represents a modded file entry used for ModUpdates.
///// </summary>
///// <param name="FileHash"> The hash of the modded file. </param>
///// <param name="GamePaths"> The game paths this mod affects. </param>
//[MessagePackObject(keyAsPropertyName: true)]
//public record FileSwapData(string SwappedPath, string[] GamePaths);

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