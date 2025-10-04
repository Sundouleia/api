using MessagePack;

namespace SundouleiaAPI.Data;

// Contains data of any new mods to be added, or old ones to remove.
[MessagePackObject(keyAsPropertyName: true)]
public record RecievedModUpdate(List<ModFileData> NewModsToAdd, List<string> HashesToRemove);

[MessagePackObject(keyAsPropertyName: true)]
public record SentModUpdate(List<ModFileInfo> NewModsToAdd, List<string> HashesToRemove);

// Used in calls, does not include download links. This is handled via the server.
[MessagePackObject(keyAsPropertyName: true)]
public record ModFileInfo(string Hash, string[] GamePaths, string SwappedPath);

// Only used on callbacks, not on server calls. Nessisary for security.
[MessagePackObject(keyAsPropertyName: true)]
public record ModFileData(string Hash, string[] GamePaths, string SwappedPath, string DownloadLink);
