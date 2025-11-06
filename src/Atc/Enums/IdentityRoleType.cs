// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Represents different user roles and privilege levels in an identity/authentication system.
/// This is a flags enumeration that allows multiple roles to be combined.
/// </summary>
[SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
[Flags]
public enum IdentityRoleType
{
    /// <summary>
    /// No role specified.
    /// </summary>
    [LocalizedDescription(null, typeof(EnumResources))]
    None,

    /// <summary>
    /// Anonymous user with no authenticated identity.
    /// </summary>
    [LocalizedDescription("IdentityRoleTypeAnonymous", typeof(EnumResources))]
    Anonymous = 0x01,

    /// <summary>
    /// Standard authenticated user with basic privileges.
    /// </summary>
    [LocalizedDescription("IdentityRoleTypeUser", typeof(EnumResources))]
    User = 0x02,

    /// <summary>
    /// User with elevated privileges beyond a standard user.
    /// </summary>
    [LocalizedDescription("IdentityRoleTypeSuperUser", typeof(EnumResources))]
    SuperUser = 0x04,

    /// <summary>
    /// Administrator with management and configuration privileges.
    /// </summary>
    [LocalizedDescription("IdentityRoleTypeAdmin", typeof(EnumResources))]
    Admin = 0x08,

    /// <summary>
    /// Super administrator with full system access and highest-level privileges.
    /// </summary>
    [LocalizedDescription("IdentityRoleTypeSuperAdmin", typeof(EnumResources))]
    SuperAdmin = 0x10,
}