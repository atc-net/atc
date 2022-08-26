// ReSharper disable CheckNamespace
namespace System.IO;

[SuppressMessage("Major Code Smell", "S4457:Parameter validation in \"async\"/\"await\" methods should be wrapped", Justification = "OK.")]
public static class FileInfoExtensions
{
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