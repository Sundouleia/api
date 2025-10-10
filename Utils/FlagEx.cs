using SundouleiaAPI.Enums;

namespace SundouleiaAPI;

// We handle this through individual cases because its more efficient 
public static class FlagEx
{
    public static bool HasAny(this IpcKind flags, IpcKind check) => (flags & check) != 0;
    public static bool hasAny(this SundesmoState flags, SundesmoState check) => (flags & check) != 0;
    /// <returns> If only one flag in a flag enum is set. </returns>
    public static bool IsSingleFlagSet(byte value)
        => value != 0 && (value & (value - 1)) == 0;
}
