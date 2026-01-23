using MessagePack;
using SundouleiaAPI.Data;
using SundouleiaAPI.Data.Permissions;

namespace SundouleiaAPI.Network;

/// <summary>
///     Updates a single perm in the <paramref name="User"/>'s OtherPerms entry
///     from your list of pairs. <para />
///
///     Note that this will never be enacted by the client, so we can assume it is for OtherPerms. <para />
///     Should be able to reference GSpeaks code if we want to make this bi-directional though.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChangeUniquePerm(UserData User, string PermName, object NewValue) : UserDto(User)
{
    public override string ToString() => $"ChangeUniquePerm: Target -> {User.AliasOrUID}, Changed [{PermName}] to [{NewValue}]";
}

[MessagePackObject(keyAsPropertyName: true)]
public record ChangeUniquePerms(UserData User, Dictionary<string, object> Changes) : UserDto(User)
{
    public override string ToString() => $"ChangeUniquePerms: Target -> {User.AliasOrUID}, Changed [{string.Join(", ", Changes.Select(kv => $"{kv.Key} -> {kv.Value}"))}]";
}

/// <summary>
///     The new pair permissions to be set for <paramref name="User"/>. <para />
///     Note that this will never be enacted by the client, so we can assume it is for OtherPerms. <para />
///     Should be able to reference GSpeaks code if we want to make this bi-directional though.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChangeAllUnique(UserData User, PairPerms NewPerms) : UserDto(User)
{
    public override string ToString() => $"ChangeAllUnique: Target -> {User.AliasOrUID}, NewPerms -> {NewPerms}";
}

// ----------------------------------------------------------------------------
// ------------------- Bulk Versions ------------------------------------------
// ----------------------------------------------------------------------------
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeUniquePerm(List<UserData> Users, string PermName, object NewValue)
{
    public override string ToString() => $"BulkChangeUniquePerm: Targets -> {Users.Count}, Changed [{PermName}] to [{NewValue}]";
}

[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeUniquePerms(List<UserData> Users, Dictionary<string, object> Changes)
{
    public override string ToString() => $"BulkChangeUniquePerms: Targets -> {Users.Count}, Changed [{string.Join(", ", Changes.Select(kv => $"{kv.Key} -> {kv.Value}"))}]";
}

[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeAllUnique(List<UserData> Users, PairPerms NewPerms)
{
    public override string ToString() => $"BulkChangeAllUnique: Targets -> {Users.Count}, NewPerms -> {NewPerms}";
}