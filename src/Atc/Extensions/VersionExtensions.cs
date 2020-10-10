using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace System
{
    public static class VersionExtensions
    {
        /// <summary>
        /// Is 'version' greater then the 'otherVersion', where the significantParts is the stop part.
        /// Example significantParts=2, then only Major and Minor wil be taken into consideration.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="otherVersion">The other version.</param>
        /// <param name="significantParts">The significant parts.</param>
        /// <returns>-1, 0 or 1.</returns>
        /// <exception cref="ArgumentNullException">version.</exception>
        [SuppressMessage("Critical Code Smell", "S3776:Cognitive Complexity of methods should not be too high", Justification = "OK.")]
        public static int CompareTo(this Version version, Version otherVersion, int significantParts)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (otherVersion == null)
            {
                return 1;
            }

            if (version.Major != otherVersion.Major && significantParts >= 1)
            {
                return version.Major > otherVersion.Major ? 1 : -1;
            }

            if (version.Minor != otherVersion.Minor && significantParts >= 2)
            {
                return version.Minor > otherVersion.Minor ? 1 : -1;
            }

            if (version.Build != otherVersion.Build && significantParts >= 3)
            {
                return version.Build > otherVersion.Build ? 1 : -1;
            }

            if (version.Revision != otherVersion.Revision && significantParts >= 4)
            {
                return version.Revision > otherVersion.Revision ? 1 : -1;
            }

            return 0;
        }

        /// <summary>
        /// Is 'version' greater then the 'otherVersion'.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="otherVersion">The other version.</param>
        /// <returns>
        ///   <c>true</c> if 'otherVersion' is greater then the current 'version'; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">version.</exception>
        public static bool GreaterThan(this Version version, Version otherVersion)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }

            if (otherVersion == null)
            {
                return true;
            }

            return version.CompareTo(otherVersion, 4) > 0;
        }
    }
}