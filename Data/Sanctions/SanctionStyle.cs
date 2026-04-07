using MessagePack;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class SanctionStyle
{
    public int IconId { get; set; } = 0;
    public uint IconColor { get; set; } = 0xFFFFFFFF;
    public uint LabelColor { get; set; } = 0xFFFFFFFF;
    public uint BorderColor { get; set; } = 0xFFFFFFFF;
    public uint GradientColor { get; set; } = 0xFF222222;
}