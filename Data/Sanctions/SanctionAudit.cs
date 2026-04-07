using MessagePack;

namespace SundouleiaAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAuditFetch(SanctionData Sanction, int MaxLogs = 75, string Filter = "", SanctionAuditAct ActFilter = SanctionAuditAct.None);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAuditRecord(ulong EntryId, DateTime TimeUTC, string SID, SanctionAuditAct Action, string EnactorUID, string TargetUID, string Info);

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