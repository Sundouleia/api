using MessagePack;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record VisualUpdate
{
    public IpcDataPlayerUpdate? PlayerChanges { get; set; } = null;
    public IpcDataUpdate?       MinionMountChanges { get; set; } = null;
    public IpcDataUpdate?       PetChanges { get; set; } = null;
    public IpcDataUpdate?       CompanionChanges { get; set; } = null;

    public bool HasData()
        => PlayerChanges != null 
        || MinionMountChanges != null 
        || PetChanges != null 
        || CompanionChanges != null;
}


/// <summary>
///     Lightweight record for IPC data update transfer.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record IpcDataPlayerUpdate(IpcKind Updates) : IpcDataUpdate(Updates)
{
    public string ModManips     { get; set; } = string.Empty;
    public string HeelsOffset   { get; set; } = string.Empty;
    public string TitleData     { get; set; } = string.Empty;
    public string Moodles       { get; set; } = string.Empty;
    public string PetNicks      { get; set; } = string.Empty;
}

/// <summary>
///     Lightweight record for IPC data update transfer.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record IpcDataUpdate(IpcKind Updates)
{
    public string GlamourState  { get; set; } = string.Empty;
    public string CPlusState    { get; set; } = string.Empty;
}