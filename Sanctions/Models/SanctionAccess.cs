namespace SundouleiaAPI.Sanctions;

/// <summary>
///   What a user in a SanctionedGroup can do
/// </summary>
[Flags]
public enum SanctionAccess : int
{
    /// <summary> This role is purely cosmetic, and has no permissions. </summary>
    None = 0,

    /// <summary> Can change the sanction and chat name </summary>
    ChangeNames = 1 << 0,

    /// <summary> Can change the sanction profile (description, avatar, etc) </summary>
    ChangeProfile = 1 << 1,

    /// <summary> Can change the sanction preferences </summary>
    ChangePreferences = 1 << 2,

    /// <summary> Can change public/private status </summary>
    ChangeVisibility = 1 << 3,

    /// <summary> Can change the sanction password </summary>
    ChangePassword = 1 << 4,

    /// <summary> Can make alerts that get sent out to all members of the sanction. </summary>
    PostAlerts = 1 << 5,

    /// <summary> Can remove existing alerts. </summary>
    RemoveAlerts = 1 << 6,

    /// <summary> Can moderate the sanction chat </summary>
    ChatModeration = 1 << 7,

    /// <summary> Can update required roles for Sync or Chat, and also change roles that assigned to new users. </summary>
    EditRoleRequirements = 1 << 8,

    /// <summary> Can edit role permissions. (Cannot reorder roles) </summary>
    EditRoleData = 1 << 9,

    /// <summary> Can assign roles to other users. </summary>
    /// <remarks> Can't set roles higher than the callers) </remarks>
    AssignRoles = 1 << 10,

    /// <summary> Can remove roles from other users. (Cannot remove roles higher than your own) </summary>
    RemoveRoles = 1 << 11,

    /// <summary> Can change the permission access of others in the group. </summary>
    /// <remarks> Ineffective against users of the same or higher role. (?) </remarks>
    ChangeUserAccess = 1 << 12,

    /// <summary> Can remove other SanctionedPairs from the SanctionedGroup. </summary>
    /// <remarks> Cannot remove users from a role higher than your own. </remarks>
    KickMembers = 1 << 13,

    /// <summary> Can give others the b00t. (Can only be granted by the owner) </summary>
    BanMembers = 1 << 14,

    /// <summary> Reserved usually for the Owner. Be careful who has this. </summary>
    Admin = 1 << 30,

    All = ChangeNames | ChangeProfile | ChangePreferences | ChangeVisibility | ChangePassword | PostAlerts
        | RemoveAlerts | ChatModeration | EditRoleRequirements | EditRoleData | AssignRoles | RemoveRoles
        | ChangeUserAccess | KickMembers | BanMembers | Admin
}

