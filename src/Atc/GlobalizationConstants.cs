using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Atc
{
    /// <summary>
    /// GlobalizationConstants.
    /// </summary>
    public static class GlobalizationConstants
    {
        /// <summary>
        /// DateTimeIso8601.
        /// </summary>
        public const string DateTimeIso8601 = "s";

        /// <summary>
        /// EnglishCultureInfo.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Reviewed.")]
        public static readonly CultureInfo EnglishCultureInfo = new CultureInfo("en-US");

        /// <summary>
        /// DanishCultureInfo.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Reviewed.")]
        public static readonly CultureInfo DanishCultureInfo = new CultureInfo("da-DK");
    }
}