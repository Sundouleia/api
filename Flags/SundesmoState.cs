namespace SundouleiaAPI.Enums;

// === Flag-Enum Of Sundesmo State ===
[Flags]
public enum SundesmoState
{
    // Could add HasData to here if we have premature disconnection issues)
    Offline = 0 << 0,
    Online = 1 << 0,
    Visible = 1 << 1,
    // Can tell us if they timed out or not?
    HasData = 1 << 2,

    // BitMasks
    OfflineVisible = Offline | Visible,
    OnlineVisible = Online | Visible,
    VisibleWithData = Visible | HasData,
}