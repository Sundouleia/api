using MessagePack;

namespace SundouleiaAPI.Alterations;

[MessagePackObject(keyAsPropertyName: true)]
public class IpcDataCache
{
    public Dictionary<IpcKind, string> Data { get; private set; } = new();

    public IpcDataCache()
    {
        Data = new Dictionary<IpcKind, string>
        {
            [IpcKind.Glamourer] = string.Empty,
            [IpcKind.CPlus] = string.Empty,
            [IpcKind.Loci] = string.Empty,
        };
    }

    public IpcDataUpdate ToUpdateApi()
    {
        return new IpcDataUpdate(IpcKind.Glamourer | IpcKind.CPlus | IpcKind.Loci)
        {
            GlamourState = Data[IpcKind.Glamourer],
            CPlusState = Data[IpcKind.CPlus],
            Loci = Data[IpcKind.Loci],
        };
    }

    /// <summary>
    ///     Both updates the cache with the data updates, 
    ///     and returns which updates had different data.
    /// </summary>
    public IpcKind UpdateCache(IpcDataUpdate update)
    {
        var changed = IpcKind.None;
        if (update.Updates.HasAny(IpcKind.Glamourer) && !string.Equals(Data[IpcKind.Glamourer], update.GlamourState, StringComparison.Ordinal))
        {
            Data[IpcKind.Glamourer] = update.GlamourState;
            changed |= IpcKind.Glamourer;
        }
        if (update.Updates.HasAny(IpcKind.CPlus) && !string.Equals(Data[IpcKind.CPlus], update.CPlusState, StringComparison.Ordinal))
        {
            Data[IpcKind.CPlus] = update.CPlusState;
            changed |= IpcKind.CPlus;
        }
        if (update.Updates.HasAny(IpcKind.Loci) && !string.Equals(Data[IpcKind.Loci], update.Loci, StringComparison.Ordinal))
        {
            Data[IpcKind.Loci] = update.Loci;
            changed |= IpcKind.Loci;
        }
        return changed;
    }

    /// <summary>
    ///     Both updates the cache with the data updates, 
    ///     and returns if there was different data.
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