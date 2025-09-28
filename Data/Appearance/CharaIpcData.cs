using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data;

// Lightweight data transfer that can be sent fairly frequently.
// Will rework later to have better update detection.
public class ClientIpcData
{
    public PlayerIpcData Player { get; set; } = new();
    public Dictionary<OwnedObject, NonPlayerIpcData> NonPlayers { get; set; } = new();

    public bool IsDifferent(ClientIpcData other)
    {
        if (Player.IsDifferent(other.Player))
            return true;
        if (NonPlayers.Count != other.NonPlayers.Count)
            return true;
        foreach (var (key, value) in NonPlayers)
            if (!other.NonPlayers.TryGetValue(key, out var otherValue) || value.IsDifferent(otherValue))
                return true;
        return false;
    }

    public void UpdateFrom(ClientIpcData other)
    {
        Player.UpdateFrom(other.Player);
        foreach (var (key, value) in other.NonPlayers)
            NonPlayers[key].UpdateFrom(value);
    }

    public string GetValue(OwnedObject obj, IpcKind type)
    {
        if (obj == OwnedObject.Player)
        {
            return type switch
            {
                IpcKind.CPlus => Player.CPlusData,
                IpcKind.Glamourer => Player.GlamourerState,
                IpcKind.ModManips => Player.ModManips,
                IpcKind.Moodles => Player.Moodles,
                IpcKind.Heels => Player.HeelsOffset,
                IpcKind.Honorific => Player.HonorificTitle,
                IpcKind.PetNames => Player.PetNicknames,
                _ => string.Empty,
            };
        }
        if (!NonPlayers.TryGetValue(obj, out var npcData))
            return string.Empty;
        return type switch
        {
            IpcKind.CPlus => npcData.CPlusData,
            IpcKind.Glamourer => npcData.GlamourerState,
            _ => string.Empty,
        };
    }
}

public class PlayerIpcData
{
    public IpcKind Updates { get; set; } = IpcKind.None;
    public string CPlusData { get; set; } = string.Empty;
    public string GlamourerState { get; set; } = string.Empty;
    public string ModManips { get; set; } = string.Empty;
    public string Moodles { get; set; } = string.Empty;
    public string HeelsOffset { get; set; } = string.Empty;
    public string HonorificTitle { get; set; } = string.Empty;
    public string PetNicknames { get; set; } = string.Empty;

    // Bitwise checking for differences.
    public bool IsDifferent(PlayerIpcData other)
        => (other.Updates & IpcKind.CPlus) != 0 && CPlusData != other.CPlusData
        || (other.Updates & IpcKind.Glamourer) != 0 && GlamourerState != other.GlamourerState
        || (other.Updates & IpcKind.ModManips) != 0 && ModManips != other.ModManips
        || (other.Updates & IpcKind.Moodles) != 0 && Moodles != other.Moodles
        || (other.Updates & IpcKind.Heels) != 0 && HeelsOffset != other.HeelsOffset
        || (other.Updates & IpcKind.Honorific) != 0 && HonorificTitle != other.HonorificTitle
        || (other.Updates & IpcKind.PetNames) != 0 && PetNicknames != other.PetNicknames;

    public void UpdateFrom(PlayerIpcData other)
    {
        if (other.Updates.HasAny(IpcKind.CPlus)) CPlusData = other.CPlusData;
        if (other.Updates.HasAny(IpcKind.Glamourer)) GlamourerState = other.GlamourerState;
        if (other.Updates.HasAny(IpcKind.ModManips)) ModManips = other.ModManips;
        if (other.Updates.HasAny(IpcKind.Moodles)) Moodles = other.Moodles;
        if (other.Updates.HasAny(IpcKind.Heels)) HeelsOffset = other.HeelsOffset;
        if (other.Updates.HasAny(IpcKind.Honorific)) HonorificTitle = other.HonorificTitle;
        if (other.Updates.HasAny(IpcKind.PetNames)) PetNicknames = other.PetNicknames;
    }
}

public class NonPlayerIpcData
{
    public IpcKind Updates { get; set; } = IpcKind.None;
    public string CPlusData { get; set; } = string.Empty;
    public string GlamourerState { get; set; } = string.Empty;

    // Bitwise checking for differences.
    public bool IsDifferent(NonPlayerIpcData other)
        => (other.Updates & IpcKind.CPlus) != 0 && CPlusData != other.CPlusData
        || (other.Updates & IpcKind.Glamourer) != 0 && GlamourerState != other.GlamourerState;

    public void UpdateFrom(NonPlayerIpcData other)
    {
        if (other.Updates.HasAny(IpcKind.CPlus)) CPlusData = other.CPlusData;
        if (other.Updates.HasAny(IpcKind.Glamourer)) GlamourerState = other.GlamourerState;
    }
}