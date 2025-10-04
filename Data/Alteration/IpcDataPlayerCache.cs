using MessagePack;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class IpcDataPlayerCache
{
    public Dictionary<IpcKind, string> Data { get; private set; } = new();
    public IpcDataPlayerCache()
    {
        Data = new Dictionary<IpcKind, string>
        {
            [IpcKind.ModManips] = string.Empty,
            [IpcKind.Glamourer] = string.Empty,
            [IpcKind.Heels] = string.Empty,
            [IpcKind.CPlus] = string.Empty,
            [IpcKind.Honorific] = string.Empty,
            [IpcKind.Moodles] = string.Empty,
            [IpcKind.PetNames] = string.Empty
        };
    }

    public IpcDataPlayerUpdate ToUpdateApi()
    {
        var all = IpcKind.ModManips | IpcKind.Glamourer | IpcKind.Heels | IpcKind.CPlus | IpcKind.Honorific | IpcKind.Moodles | IpcKind.PetNames;
        return new IpcDataPlayerUpdate(all)
        {
            ModManips = Data[IpcKind.ModManips],
            GlamourState = Data[IpcKind.Glamourer],
            HeelsOffset = Data[IpcKind.Heels],
            CPlusState = Data[IpcKind.CPlus],
            TitleData = Data[IpcKind.Honorific],
            Moodles = Data[IpcKind.Moodles],
            PetNicks = Data[IpcKind.PetNames]
        };
    }

    /// <summary>
    ///     Both updates the cache with the data updates, 
    ///     and returns which updates had different data.
    /// </summary>
    public IpcKind UpdateCache(IpcDataPlayerUpdate update)
    {
        var changed = IpcKind.None;
        if (update.Updates.HasAny(IpcKind.ModManips) && !string.Equals(Data[IpcKind.ModManips], update.ModManips, StringComparison.Ordinal))
        {
            Data[IpcKind.ModManips] = update.ModManips;
            changed |= IpcKind.ModManips;
        }
        if (update.Updates.HasAny(IpcKind.Glamourer) && !string.Equals(Data[IpcKind.Glamourer], update.GlamourState, StringComparison.Ordinal))
        {
            Data[IpcKind.Glamourer] = update.GlamourState;
            changed |= IpcKind.Glamourer;
        }
        if (update.Updates.HasAny(IpcKind.Heels) && !string.Equals(Data[IpcKind.Heels], update.HeelsOffset, StringComparison.Ordinal))
        {
            Data[IpcKind.Heels] = update.HeelsOffset;
            changed |= IpcKind.Heels;
        }
        if (update.Updates.HasAny(IpcKind.CPlus) && !string.Equals(Data[IpcKind.CPlus], update.CPlusState, StringComparison.Ordinal))
        {
            Data[IpcKind.CPlus] = update.CPlusState;
            changed |= IpcKind.CPlus;
        }
        if (update.Updates.HasAny(IpcKind.Honorific) && !string.Equals(Data[IpcKind.Honorific], update.TitleData, StringComparison.Ordinal))
        {
            Data[IpcKind.Honorific] = update.TitleData;
            changed |= IpcKind.Honorific;
        }
        if (update.Updates.HasAny(IpcKind.Moodles) && !string.Equals(Data[IpcKind.Moodles], update.Moodles, StringComparison.Ordinal))
        {
            Data[IpcKind.Moodles] = update.Moodles;
            changed |= IpcKind.Moodles;
        }
        if (update.Updates.HasAny(IpcKind.PetNames) && !string.Equals(Data[IpcKind.PetNames], update.PetNicks, StringComparison.Ordinal))
        {
            Data[IpcKind.PetNames] = update.PetNicks;
            changed |= IpcKind.PetNames;
        }
        return changed;
    }

    /// <summary>
    ///     Both updates the cache with the data updates, 
    ///     and returns if it had different data.
    /// </summary>
    public bool UpdateCacheSingle(IpcKind kind, string data)
    {
        if (!string.Equals(Data[kind], data, StringComparison.Ordinal))
        {
            Data[kind] = data;
            return true;
        }
        return false;
    }
}