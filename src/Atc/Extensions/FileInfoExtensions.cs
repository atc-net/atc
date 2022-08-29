// ReSharper disable CheckNamespace
namespace System.IO;

/// <summary>
/// Extension methods for the <see cref="FileInfo"/> class.
/// </summary>
[SuppressMessage("Major Code Smell", "S4457:Parameter validation in \"async\"/\"await\" methods should be wrapped", Justification = "OK.")]
public static class FileInfoExtensions
{
    /// <summary>Reads to byte array.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return a byte array from the file</returns>
    public static byte[] ReadToByteArray(
        this FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        return File.ReadAllBytes(fileInfo.FullName);
    }

    /// <summary>Reads to byte array.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Return a byte array from the file</returns>
    public static Task<byte[]> ReadToByteArrayAsync(
        this FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        return File.ReadAllBytesAsync(fileInfo.FullName, cancellationToken);
    }

    /// <summary>Reads to <see cref="MemoryStream"/>.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <returns>Return a <see cref="MemoryStream"/> from the file</returns>
    public static MemoryStream ReadToMemoryStream(
        this FileInfo fileInfo)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        var bytes = ReadToByteArray(fileInfo);
        var memoryStream = new MemoryStream(bytes);
        memoryStream.Position = 0;
        return memoryStream;
    }

    /// <summary>Reads to <see cref="MemoryStream"/>.</summary>
    /// <param name="fileInfo">The file information.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Return a <see cref="MemoryStream"/> from the file</returns>
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "OK.")]
    public static async Task<MemoryStream> ReadToMemoryStreamAsync(
        this FileInfo fileInfo,
        CancellationToken cancellationToken = default)
    {
        if (fileInfo is null)
        {
            throw new ArgumentNullException(nameof(fileInfo));
        }

        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        var bytes = await ReadToByteArrayAsync(fileInfo, cancellationToken).ConfigureAwait(false);
        var memoryStream = new MemoryStream(bytes);
        memoryStream.Position = 0;
        return memoryStream;
    }
}