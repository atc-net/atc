using System;
using System.Diagnostics.CodeAnalysis;
using Atc.Resources;

// ReSharper disable once CheckNamespace
namespace Atc
{
    /// <summary>
    /// Flag-Enumeration: IdentityRoleType.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames", Justification = "OK.")]
    [SuppressMessage("Minor Code Smell", "S2342:Enumeration types should comply with a naming convention", Justification = "OK.")]
    [Flags]
    public enum IdentityRoleType
    {
        /// <summary>
        /// Default None.
        /// </summary>
        [LocalizedDescription(null, typeof(EnumResources))]
        None,

        /// <summary>
        /// Indicates that the identity role is anonymous.
        /// </summary>
        [LocalizedDescription("IdentityRoleTypeAnonymous", typeof(EnumResources))]
        Anonymous = 0x01,

        /// <summary>
        /// Indicates that the identity role is a normal user.
        /// </summary>
        [LocalizedDescription("IdentityRoleTypeUser", typeof(EnumResources))]
        User = 0x02,

        /// <summary>
        /// Indicates that the identity role is a normal user.
        /// </summary>
        [LocalizedDescription("IdentityRoleTypeSuperUser", typeof(EnumResources))]
        SuperUser = 0x04,

        /// <summary>
        /// Indicates that the identity role is administrator.
        /// </summary>
        [LocalizedDescription("IdentityRoleTypeAdmin", typeof(EnumResources))]
        Admin = 0x08,

        /// <summary>
        /// Indicates that the identity role is super administrator.
        /// </summary>
        [LocalizedDescription("IdentityRoleTypeSuperAdmin", typeof(EnumResources))]
        SuperAdmin = 0x10
    }
}