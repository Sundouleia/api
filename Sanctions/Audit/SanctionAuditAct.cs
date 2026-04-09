namespace SundouleiaAPI.Sanctions;

public enum SanctionAuditAct : int
{
    RoleData = 0,
    UserRoles = 1,
    Visibility = 2,
    Preferences = 3,
    ProfileEdit = 4,
    Password = 5,
    ChatName = 6,
    Name = 7,
    Style = 8,
    UserAccess = 9,
    Ban = 10,
    Unban = 11,
    Removal = 12,
    Cleanup = 13,
    AlertMade = 14,
    AlertRemoved = 15,
    None = int.MaxValue,
}