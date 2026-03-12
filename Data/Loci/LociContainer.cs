using MessagePack;

namespace SundouleiaAPI.Data;

/// <summary> 
///   Holds information about a players Loci data. <para />
///   This data is stored in dictionary form to help with fast lookup.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class LociContainer
{
    public Dictionary<Guid, LociStatusStruct> DataInfo { get; set; } = [];
    public Dictionary<Guid, LociStatusStruct> Statuses { get; set; } = [];
    public Dictionary<Guid, LociPresetStruct> Presets { get; set; } = [];

    // Convenience access to collections.
    [IgnoreMember] public IEnumerable<LociStatusStruct> DataInfoList => DataInfo.Values;
    [IgnoreMember] public IEnumerable<LociStatusStruct> StatusList => Statuses.Values;
    [IgnoreMember] public IEnumerable<LociPresetStruct> PresetList => Presets.Values;

    public LociContainer()
    { }

    public LociContainer(LociContainer other)
    {
        DataInfo = new Dictionary<Guid, LociStatusStruct>(other.DataInfo);
        Statuses = new Dictionary<Guid, LociStatusStruct>(other.Statuses);
        Presets = new Dictionary<Guid, LociPresetStruct>(other.Presets);
    }

    public void SetDataInfo(IEnumerable<LociStatusStruct> statuses)
        => DataInfo = statuses.ToDictionary(x => x.GUID, x => x);
    public void SetStatuses(IEnumerable<LociStatusStruct> statuses)
        => Statuses = statuses.ToDictionary(x => x.GUID, x => x);
    public void SetPresets(IEnumerable<LociPresetStruct> presets)
        => Presets = presets.ToDictionary(x => x.GUID, x => x);
}

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LociStatusStruct
{
    public int Version { get; init; }
    public Guid GUID { get; init; }
    public uint IconID { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string CustomVFXPath { get; init; }
    public long ExpireTicks { get; init; }
    public byte Type { get; init; }
    public int Stacks { get; init; }
    public int StackSteps { get; init; }
    public int StackToChain { get; init; }
    public uint Modifiers { get; init; }
    public Guid ChainedGUID { get; init; }
    public byte ChainType { get; init; }
    public int ChainTrigger { get; init; }
    public string Applier { get; init; }
    public string Dispeller { get; init; }
}

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LociPresetStruct
{
    public int Version { get; init; }
    public Guid GUID { get; init; }
    public List<Guid> Statuses { get; init; }
    public byte ApplicationType { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
}
