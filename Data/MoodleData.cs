using MessagePack;
#pragma warning disable CS0659, IDE1006

namespace GagspeakAPI.Data;

/// <summary> 
///     Stores information about a player's Moodles data. <para />
///     This data is trusted to paired players that are allowed to view them. <para />
///     Allowing view access indicates the user understands what information they are sharing, and that it can be copied.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class MoodleData
{
    public Dictionary<Guid, MoodlesStatusInfo> DataInfo { get; private set; } = new Dictionary<Guid, MoodlesStatusInfo>();
    public Dictionary<Guid, MoodlesStatusInfo> Statuses { get; private set; } = new Dictionary<Guid, MoodlesStatusInfo>();
    public Dictionary<Guid, MoodlePresetInfo> Presets { get; private set; } = new Dictionary<Guid, MoodlePresetInfo>();

    // Convenience access to collections.
    [IgnoreMember] public IEnumerable<MoodlesStatusInfo> DataInfoList => DataInfo.Values;
    [IgnoreMember] public IEnumerable<MoodlesStatusInfo> StatusList => Statuses.Values;
    [IgnoreMember] public IEnumerable<MoodlePresetInfo> PresetList => Presets.Values;

    public MoodleData()
    { }

    public MoodleData(MoodleData other)
    {
        DataInfo = new Dictionary<Guid, MoodlesStatusInfo>(other.DataInfo);
        Statuses = new Dictionary<Guid, MoodlesStatusInfo>(other.Statuses);
        Presets = new Dictionary<Guid, MoodlePresetInfo>(other.Presets);
    }

    public void UpdateDataInfo(IEnumerable<MoodlesStatusInfo> statuses)
        => DataInfo = statuses.ToDictionary(x => x.GUID, x => x);

    public bool TryUpdateStatus(MoodlesStatusInfo status)
    {
        if(Statuses.ContainsKey(status.GUID))
        {
            Statuses[status.GUID] = status;
            return true;
        }
        return false;
    }

    public bool TryUpdatePreset(MoodlePresetInfo preset)
    {
        if (Presets.ContainsKey(preset.GUID))
        {
            Presets[preset.GUID] = preset;
            return true;
        }
        return false;
    }

    public void SetStatuses(IEnumerable<MoodlesStatusInfo> statuses)
        => Statuses = statuses.ToDictionary(x => x.GUID, x => x);

    public void SetPresets(IEnumerable<MoodlePresetInfo> presets)
        => Presets = presets.ToDictionary(x => x.GUID, x => x);
}
#pragma warning restore CS0659, IDE1006
