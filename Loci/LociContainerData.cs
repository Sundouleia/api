using MessagePack;
using SundouleiaAPI.Loci;

namespace SundouleiaAPI.Locis;

/// <summary>
///   The GagspeakAPI equivalent of LociContainer, optimized for data transfer with helpers removed.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record LociContainerData(List<LociStatusStruct> SMInfo, List<LociStatusStruct> Statuses, List<LociPresetStruct> Presets);