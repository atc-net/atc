namespace Atc.Helpers;

/// <summary>
/// FileHelper.
/// </summary>
public static class FileHelper
{
    /// <summary>The line breaks.</summary>
    public static readonly string[] LineBreaks = { "\r\n", "\r", "\n" };

    /// <summary>
    /// Gets the files as GetFiles, but skip files and folders with unauthorized access.
    /// </summary>
    /// <param name="path">The directory.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <param name="searchOption">The search option.</param>
    public static FileInfo[] GetFiles(
        string path,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
        => new DirectoryInfo(path).GetFilesEx(searchPattern, searchOption);

    /// <summary>
    /// Gets the files as GetFiles, but skip files and folders with unauthorized access.
    /// </summary>
    /// <param name="path">The directory information.</param>
    /// <param name="searchPattern">The search pattern.</param>
    /// <param name="searchOption">The search option.</param>
    public static FileInfo[] GetFiles(
        DirectoryInfo path,
        string searchPattern = "*.*",
        SearchOption searchOption = SearchOption.AllDirectories)
        => path.GetFilesEx(searchPattern, searchOption);

    /// <summary>Reads all text in the file with UTF8 encoding.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return the content from the file, if the file don't exist a empty string will be returned.</returns>
    public static string ReadAllText(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return fileInfo.Exists
            ? File.ReadAllText(fileInfo.FullName, Encoding.UTF8)
            : string.Empty;
    }

    /// <summary>Reads all text in the file with UTF8 encoding.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return the content from the file, if the file don't exist a empty string will be returned.</returns>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static Task<string> ReadAllTextAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return fileInfo.Exists
            ? File.ReadAllTextAsync(fileInfo.FullName, Encoding.UTF8, cancellationToken)
            : Task.FromResult(string.Empty);
    }

    /// <summary>Reads all text in the file with UTF8 encoding and split it to lines.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return the content as lines from the file, if the file don't exist a empty string array will be returned.</returns>
    public static string[] ReadAllTextToLines(
        FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            return Array.Empty<string>();
        }

        var content = File.ReadAllText(fileInfo.FullName, Encoding.UTF8);
        return content.Split(LineBreaks, StringSplitOptions.None);
    }

    /// <summary>Reads all text in the file with UTF8 encoding and split it to lines.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return the content as lines from the file, if the file don't exist a empty string array will be returned.</returns>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static Task<string[]> ReadAllTextToLinesAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return InvokeReadAllTextToLinesAsync(fileInfo, cancellationToken);
    }

    /// <summary>Reads to byte array.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return a byte array from the file</returns>
    public static byte[] ReadToByteArray(
        FileInfo fileInfo)
        => fileInfo.ReadToByteArray();

    /// <summary>Reads to byte array.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Return a byte array from the file</returns>
    public static Task<byte[]> ReadToByteArrayAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
        => fileInfo.ReadToByteArrayAsync(cancellationToken);

    /// <summary>Reads to <see cref="MemoryStream"/>.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return a <see cref="MemoryStream"/> from the file</returns>
    public static MemoryStream ReadToMemoryStream(
        FileInfo fileInfo)
        => fileInfo.ReadToMemoryStream();

    /// <summary>Reads to <see cref="MemoryStream"/>.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Return a <see cref="MemoryStream"/> from the file</returns>
    public static Task<MemoryStream> ReadToMemoryStreamAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
        => fileInfo.ReadToMemoryStreamAsync(cancellationToken);

    /// <summary>Writes all text to the file with UTF8 encoding.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="content">The content.</param>
    public static void WriteAllText(
        FileInfo fileInfo,
        string content)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        File.WriteAllText(fileInfo.FullName, content, Encoding.UTF8);
    }

    /// <summary>Writes all text to the file with UTF8 encoding.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="content">The content.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    public static Task WriteAllTextAsync(
        FileInfo fileInfo,
        string content,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        return File.WriteAllTextAsync(fileInfo.FullName, content, Encoding.UTF8, cancellationToken);
    }

    private static async Task<string[]> InvokeReadAllTextToLinesAsync(
        FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (!fileInfo.Exists)
        {
            return Array.Empty<string>();
        }

        var content = await File.ReadAllTextAsync(fileInfo.FullName, Encoding.UTF8, cancellationToken);
        return content.Split(LineBreaks, StringSplitOptions.None);
    }
}