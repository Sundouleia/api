using MessagePack;

namespace SundouleiaAPI.Data;

// Contains data of any new mods to be added, or old ones to remove.
// if not all sent is true, it means there will be additional files sent after, and they should be marked for uploading,
// after the download is complete.
[MessagePackObject(keyAsPropertyName: true)]
public record NewModUpdates(List<VerifiedModFile> FilesToAdd, List<string> HashesToRemove, int FilesUploading)
{
    public bool HasChanges => FilesToAdd.Count > 0 || HashesToRemove.Count > 0;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ModUpdates(List<ModFile> FilesToAdd, List<string> HashesToRemove)
{
    public bool HasChanges => FilesToAdd.Count > 0 || HashesToRemove.Count > 0;
}

// Used in calls, does not include download links. This is handled via the server.
[MessagePackObject(keyAsPropertyName: true)]
public record ModFile(string Hash, string[] GamePaths, string SwappedPath);

/// <summary>
///     Represents a mod file that has been verified via the Sundouleia FileHost. <para />
///     This record is only in server callbacks and not included in any server calls.
///     This is done intentionally to prevent malicious clients from sending download links.
/// </summary>
/// <param name="Hash"> The FileHash of the ModFile being sent. </param>
/// <param name="Link"> The Authorized Upload/Download Link. </param>
/// <param name="GamePaths"> The game paths this mod affects. </param>
/// <param name="SwappedPath"> The new path this mod is swapped to. </param>
/// <remarks> Callbacks hold download links, responces hold authorized upload links. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record VerifiedModFile(string Hash, string Link, string[] GamePaths, string SwappedPath);
