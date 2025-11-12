// ReSharper disable CheckNamespace
namespace System.IO;

/// <summary>
/// Extension methods for the <see cref="FileInfo"/> class.
/// </summary>
[SuppressMessage("Major Code Smell", "S4457:Parameter validation in \"async\"/\"await\" methods should be wrapped", Justification = "OK.")]
public static class FileInfoExtensions
{
    /// <summary>
    /// Reads all bytes from the file into a byte array.
    /// </summary>
    /// <param name="fileInfo">The file information representing the file to read.</param>
    /// <returns>A byte array containing all data from the file.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
    public static byte[] ReadToByteArray(this FileInfo fileInfo)
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

    /// <summary>
    /// Asynchronously reads all bytes from the file into a byte array.
    /// </summary>
    /// <param name="fileInfo">The file information representing the file to read.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>A task that represents the asynchronous read operation. The task result contains a byte array with all data from the file.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
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

    /// <summary>
    /// Reads the file content into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileInfo">The file information representing the file to read.</param>
    /// <returns>A <see cref="MemoryStream"/> containing the file content with position set to 0.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
    public static MemoryStream ReadToMemoryStream(this FileInfo fileInfo)
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

    /// <summary>
    /// Asynchronously reads the file content into a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="fileInfo">The file information representing the file to read.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the asynchronous operation to complete.</param>
    /// <returns>A task that represents the asynchronous read operation. The task result contains a <see cref="MemoryStream"/> with the file content and position set to 0.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fileInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
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