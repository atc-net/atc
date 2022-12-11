// ReSharper disable once CheckNamespace
namespace System.IO;

public static class DirectoryInfoExtensions
{
    /// <summary>
    /// Gets the files as GetFiles, but skip files and folders with unauthorized access.
    /// </summary>
    /// <param name="directoryInfo">The directory information.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <param name="searchOption">The search option.</param>
    public static FileInfo[] GetFilesEx(
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
    /// Get the file information.
    /// </summary>
    /// <param name="directoryInfo">The directory information.</param>
    /// <param name="file">The file.</param>
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

        if (!directoryInfo.Exists)
        {
            throw new IOException("Directory do not exist");
        }

        if (file.Contains('/', StringComparison.Ordinal) ||
            file.Contains('\\', StringComparison.Ordinal))
        {
            throw new ArgumentException("File should be a valid file - without full path", nameof(file));
        }

        return new FileInfo(Path.Combine(directoryInfo.FullName, file));
    }
}