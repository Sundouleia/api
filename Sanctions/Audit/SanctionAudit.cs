using MessagePack;

namespace SundouleiaAPI.Sanctions;

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAuditFetch(SanctionData Sanction, int MaxLogs = 75, string Filter = "", SanctionAuditAct ActFilter = SanctionAuditAct.None);

[MessagePackObject(keyAsPropertyName: true)]
public record SanctionAuditRecord(ulong EntryId, DateTime TimeUTC, string SID, SanctionAuditAct Action, string EnactorUID, string TargetUID, string Info);