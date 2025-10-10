namespace SundouleiaAPI.Data;

// Preferably, the FileUrls class should be moved into this folder of the API project to help with organization and accessibility via the other serverside services.
public record ModFileUrlResult(List<VerifiedModFile> DownloadFiles, List<VerifiedModFile> RequiresUpload);
