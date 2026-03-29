namespace SundouleiaAPI.Data.Permissions;

/// <summary>
///   What a user in a sanctioned group can do
/// </summary>
[Flags]
public enum SanctionAccess : ushort
{
    /// <summary> This role is purely cosmetic, and has no permissions. </summary>
    None = 0,

    /// <summary> Can assign roles to other users. </summary>
    AssignRoles = 1 << 0,

    /// <summary> Can moderation the groups chat </summary>
    ChatModeration = 1 << 1,

    /// <summary> Can change public/private status </summary>
    ChangeVisibility = 1 << 2,

    /// <summary> Can change the groups preferences </summary>
    ChangePreferences = 1 << 3,

    /// <summary> Can change the groups password </summary>
    ChangePassword = 1 << 4,

    /// <summary> Can change the groups profile (description, avatar, etc) </summary>
    ChangeProfile = 1 << 5,

    /// <summary> Can change the permission access of others in the group, excluding the owner. </summary>
    ChangePermissions = 1 << 6,

    /// <summary> Can give others the b00t. (Can only be granted by the owner) </summary>
    BanMembers = 1 << 7,

    /// <summary> Can only be used by the Owner. Wipes the group of its users, placing it on a clean slate. </summary>
    WipeGroup = 1 << 8,
}

