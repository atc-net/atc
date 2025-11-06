// ReSharper disable once CheckNamespace
namespace System.IO;

/// <summary>
/// Provides extension methods for the DirectoryInfo class.
/// </summary>
public static class DirectoryInfoExtensions
{
    /// <summary>
    /// Combines the directory path with additional sub-paths to create a FileInfo object.
    /// </summary>
    /// <param name="directoryInfo">The base directory information.</param>
    /// <param name="paths">An array of sub-paths to combine with the base directory.</param>
    /// <returns>A FileInfo object representing the combined path.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the directoryInfo parameter is null.</exception>
    public static FileInfo CombineFileInfo(
        this DirectoryInfo directoryInfo,
        params string[] paths)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        return new FileInfo(Path.Combine(new[] { directoryInfo.FullName }.Concat(paths).ToArray()));
    }

    /// <summary>
    /// Gets all files matching the search pattern while gracefully skipping files and folders with unauthorized access.
    /// </summary>
    /// <param name="directoryInfo">The directory to search in.</param>
    /// <param name="searchPattern">The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.</param>
    /// <param name="searchOption">Specifies whether to search only the current directory or all subdirectories. Defaults to <see cref="SearchOption.TopDirectoryOnly"/>.</param>
    /// <returns>An array of <see cref="FileInfo"/> objects representing the files found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="directoryInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="IOException">Thrown when the directory does not exist.</exception>
    public static FileInfo[] GetFilesForAuthorizedAccess(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
        }

        if (string.IsNullOrEmpty(searchPattern))
        {
            searchPattern = "*.*";
        }

        var files = new List<FileInfo>();
        var directories = new Queue<string>();
        directories.Enqueue(directoryInfo.FullName);
        while (directories.Count != 0)
        {
            var workOnDirectory = directories.Dequeue();

            try
            {
                files.AddRange(
                    Directory
                        .EnumerateFiles(workOnDirectory, searchPattern)
                        .Select(x => new FileInfo(x)));
            }
            catch (UnauthorizedAccessException)
            {
                // Skip
            }

            if (searchOption != SearchOption.AllDirectories)
            {
                continue;
            }

            try
            {
                var currentSubFolders = Directory.GetDirectories(workOnDirectory);
                foreach (var current in currentSubFolders)
                {
                    directories.Enqueue(current);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip
            }
        }

        return files.ToArray();
    }

    /// <summary>
    /// Counts the total number of files in the directory matching the search pattern.
    /// </summary>
    /// <param name="directoryInfo">The directory to search in.</param>
    /// <param name="searchPattern">The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.</param>
    /// <param name="searchOption">Specifies whether to search only the current directory or all subdirectories. Defaults to <see cref="SearchOption.AllDirectories"/>.</param>
    /// <returns>The total number of files found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="directoryInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="IOException">Thrown when the directory does not exist.</exception>
    public static long GetFilesCount(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
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
    /// Counts the total number of subdirectories in the directory matching the search pattern.
    /// </summary>
    /// <param name="directoryInfo">The directory to search in.</param>
    /// <param name="searchPattern">The search pattern to match directory names against (e.g., "temp*"). Defaults to "*" for all directories.</param>
    /// <param name="searchOption">Specifies whether to search only the current directory or all subdirectories. Defaults to <see cref="SearchOption.AllDirectories"/>.</param>
    /// <returns>The total number of subdirectories found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="directoryInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="IOException">Thrown when the directory does not exist.</exception>
    public static long GetFoldersCount(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*",
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
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
    /// Calculates the total size in bytes of all files in the directory matching the search pattern.
    /// </summary>
    /// <param name="directoryInfo">The directory to calculate size for.</param>
    /// <param name="searchPattern">The search pattern to match file names against (e.g., "*.txt"). Defaults to "*.*" for all files.</param>
    /// <param name="searchOption">Specifies whether to search only the current directory or all subdirectories. Defaults to <see cref="SearchOption.AllDirectories"/>.</param>
    /// <returns>The total size in bytes of all matching files.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="directoryInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="IOException">Thrown when the directory does not exist.</exception>
    public static long GetByteSize(
        this DirectoryInfo directoryInfo,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
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

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
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

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
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

    /// <summary>
    /// Creates a <see cref="FileInfo"/> object for a file within the directory.
    /// </summary>
    /// <param name="directoryInfo">The directory containing the file.</param>
    /// <param name="file">The file name (without path) to get information for.</param>
    /// <returns>A <see cref="FileInfo"/> object representing the combined directory and file name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="directoryInfo"/> or <paramref name="file"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="file"/> contains path separators (/ or \).</exception>
    public static FileInfo GetFileInfo(
        this DirectoryInfo directoryInfo,
        string file)
    {
        if (directoryInfo is null)
        {
            throw new ArgumentNullException(nameof(directoryInfo));
        }

        if (file is null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        if (file.Contains('/', StringComparison.Ordinal) ||
            file.Contains('\\', StringComparison.Ordinal))
        {
            throw new ArgumentException("File should be a valid file - without full path", nameof(file));
        }

        return new FileInfo(Path.Combine(directoryInfo.FullName, file));
    }
}