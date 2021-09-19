using System.Linq;
using Atc.Math.UnitOfDigitalInformation;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// Gets the files count.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchOption">The search option.</param>
        public static long GetFilesCount(
            this DirectoryInfo directoryInfo,
            string searchPattern = "*.*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            if (string.IsNullOrEmpty(searchPattern))
            {
                searchPattern = "*.*";
            }

            return directoryInfo
                .GetFiles(searchPattern, searchOption)
                .Length;
        }

        /// <summary>
        /// Gets the folders count.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchOption">The search option.</param>
        public static long GetFoldersCount(
            this DirectoryInfo directoryInfo,
            string searchPattern = "*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            if (string.IsNullOrEmpty(searchPattern))
            {
                searchPattern = "*";
            }

            return directoryInfo
                .GetDirectories(searchPattern, searchOption)
                .Length;
        }

        /// <summary>
        /// Gets the byte size.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchOption">The search option.</param>
        public static long GetByteSize(
            this DirectoryInfo directoryInfo,
            string searchPattern = "*.*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            if (string.IsNullOrEmpty(searchPattern))
            {
                searchPattern = "*.*";
            }

            return directoryInfo
                .GetFiles(searchPattern, searchOption)
                .Sum(x => x.Length);
        }

        /// <summary>
        /// Gets the byte size as pretty formatted text like '1.82 GB'.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchOption">The search option.</param>
        public static string GetPrettySize(
            this DirectoryInfo directoryInfo,
            string searchPattern = "*.*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            var totalBytes = directoryInfo
                .GetByteSize(searchPattern, searchOption);

            var byteSizeFormatter = new ByteSizeFormatter
            {
                NumberOfDecimals = 2,
            };

            return totalBytes
                .Bytes()
                .ToString(byteSizeFormatter);
        }

        /// <summary>
        /// Gets the byte size as pretty formatted text like '1.933.212.103 bytes'.
        /// </summary>
        /// <param name="directoryInfo">The directory information.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="searchOption">The search option.</param>
        public static string GetPrettyByteSize(
            this DirectoryInfo directoryInfo,
            string searchPattern = "*.*",
            SearchOption searchOption = SearchOption.AllDirectories)
        {
            if (directoryInfo is null)
            {
                throw new ArgumentNullException(nameof(directoryInfo));
            }

            var totalBytes = directoryInfo
                .GetByteSize(searchPattern, searchOption);

            var byteSizeFormatter = new ByteSizeFormatter
            {
                SuffixFormat = ByteSizeSuffixType.Full,
                MinUnit = ByteSizeUnitType.Byte,
                MaxUnit = ByteSizeUnitType.Byte,
            };

            return totalBytes
                .Bytes()
                .ToString(byteSizeFormatter);
        }
    }
}