namespace SundouleiaAPI.Reporting;

public enum ReportKind
{
    Profile = 0,
    Sanction = 1,
    RadarGroup = 2,
    Chat = 3,
}

public enum RepResetTarget
{
    All,
    ProfileViewing,
    ProfileEditing,
    Radar,
    Chat,
    FalseReports
}