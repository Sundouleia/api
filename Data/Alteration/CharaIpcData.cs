using MessagePack;
using SundouleiaAPI.Enums;

namespace SundouleiaAPI.Data;

// NOTE:
// Right now it is not as efficiently optimized as id like it to be, but this will work for now.
// If we wanted to optimize it, we would do something similar to GSpeaks memory packed moodles or aliasTrigger records.
// Where certain records were composite packed records containing additional data.
// We could then easily fit these into changes objects.
/// <summary>
///     Lightweight appearance data transfer object. <para />
///     These can double as current cache, or pending updates to be applied. <para />
///     If used as a cache, assume the data is the state as-in.
///     If used in transit, assume all data is the pending data to update.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class VisualDataUpdate
{
    public ObjectIpcData Player { get; set; } = new(); // Everything but Mods
    public ObjectIpcData MinionMount { get; set; } = new(); // Only CPlus & Glamourer
    public ObjectIpcData Pet { get; set; } = new(); // Only CPlus & Glamourer
    public ObjectIpcData Companion { get; set; } = new(); // Only CPlus & Glamourer

    /// <summary>
    ///     Compares two ObjectIpcData, returning what exactly about them is different, if anything. <para />
    ///     Useful for updating VisualDataUpdate in parallel.
    /// </summary>
    public IpcKind WhatIsDifferent(OwnedObject obj, ObjectIpcData other)
        => obj switch
        {
            OwnedObject.Player        => Player.WhatIsDifferent(other),
            OwnedObject.MinionOrMount => MinionMount.WhatIsDifferent(other),
            OwnedObject.Pet           => Pet.WhatIsDifferent(other),
            OwnedObject.Companion     => Companion.WhatIsDifferent(other),
            _                         => IpcKind.None,
        };

    /// <summary>
    ///     Applies <paramref name="obj"/>'s <paramref name="other"/> ObjectIpcData data. <para />
    ///     If the data was different, that IpcKind is appended to the return value. <para />
    ///     Useful for updating VisualDataUpdate in parallel.
    /// </summary>
    public IpcKind ApplyChanged(OwnedObject obj, ObjectIpcData other)
        => obj switch
        {
            OwnedObject.Player        => Player.ApplyChanged(other),
            OwnedObject.MinionOrMount => MinionMount.ApplyChanged(other),
            OwnedObject.Pet           => Pet.ApplyChanged(other),
            OwnedObject.Companion     => Companion.ApplyChanged(other),
            _                         => IpcKind.None,
        };

    /// <summary>
    ///     Tries to apply a single data update.
    /// </summary>
    public bool TryApplyKind(OwnedObject obj, IpcKind kind, string data)
        => obj switch
        {
            OwnedObject.Player        => Player.TryApplyChanged(kind, data),
            OwnedObject.MinionOrMount => MinionMount.TryApplyChanged(kind, data),
            OwnedObject.Pet           => Pet.TryApplyChanged(kind, data),
            OwnedObject.Companion     => Companion.TryApplyChanged(kind, data),
            _ => false,
        };

    /// <summary>
    ///     Bulk, full check. Reuturns the IpcKind changes for each OwnedObject.
    /// </summary>
    public Dictionary<OwnedObject, IpcKind> WhatIsDifferent(VisualDataUpdate other)
        => new()
        {
            { OwnedObject.Player, Player.WhatIsDifferent(other.Player) },
            { OwnedObject.MinionOrMount, MinionMount.WhatIsDifferent(other.MinionMount) },
            { OwnedObject.Pet, Pet.WhatIsDifferent(other.Pet) },
            { OwnedObject.Companion, Companion.WhatIsDifferent(other.Companion) },
        };

    /// <summary>
    ///     Bulk, full update. Reuturns the IpcKind changes for each OwnedObject.
    /// </summary>
    public Dictionary<OwnedObject, IpcKind> ApplyChanged(VisualDataUpdate other)
        => new()
        {
            { OwnedObject.Player, Player.ApplyChanged(other.Player) },
            { OwnedObject.MinionOrMount, MinionMount.ApplyChanged(other.MinionMount) },
            { OwnedObject.Pet, Pet.ApplyChanged(other.Pet) },
            { OwnedObject.Companion, Companion.ApplyChanged(other.Companion) },
        };
}

[MessagePackObject(keyAsPropertyName: true)]
public class ObjectIpcData
{
    /// <summary>
    ///     IPC Datastrings attached to this object. If going into transit, or coming from 
    ///     transit, these are pending. Otherwise, they are current state.
    /// </summary>
    public Dictionary<IpcKind, string> Data { get; set; } = new();

    /// <summary>
    ///     Compares two ObjectIpcData, returning what exactly about them is different, if anything.
    /// </summary>
    public IpcKind WhatIsDifferent(ObjectIpcData other)
    {
        IpcKind diff = IpcKind.None;
        foreach (var (kind, str) in other.Data)
            if (!Data.TryGetValue(kind, out var val) || !string.Equals(val, str, StringComparison.Ordinal))
                diff |= kind;
        return diff;
    }

    /// <summary>
    ///     Applies <paramref name="other"/>'s data to the new object. <para />
    ///     If the data was different, that IpcKind is appended to the return value.
    /// </summary>
    public IpcKind ApplyChanged(ObjectIpcData other)
    {
        var changed = IpcKind.None;
        // If a new key was added, or the values were different, mark as changed.
        foreach (var (kind, str) in other.Data)
            if (!Data.TryGetValue(kind, out var val) || !string.Equals(val, str, StringComparison.Ordinal))
            {
                Data[kind] = str;
                changed |= kind;
            }
        return changed;
    }

    /// <summary>
    ///     Applies a single change. Returns true if the value was different.
    /// </summary>
    public bool TryApplyChanged(IpcKind kind, string data)
    {
        var diff = !Data.TryGetValue(kind, out var val) || !string.Equals(val, data, StringComparison.Ordinal);
        Data[kind] = data;
        return diff;
    }
}