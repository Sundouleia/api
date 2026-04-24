namespace SundouleiaAPI.Sanctions;

public enum SanctionAuditAct : int
{
    RoleData = 0,
    UserRoles = 1,
    Visibility = 2,
    Preferences = 3,
    ProfileEdit = 4,
    Password = 5,
    NameChange = 6,
    Style = 7,
    UserAccess = 8,
    Ban = 9,
    Unban = 10,
    RemovedUser = 11,
    Cleanup = 12,
    AlertMade = 13,
    AlertRemoved = 14,
    None = int.MaxValue,
}