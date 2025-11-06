// ReSharper disable once CheckNamespace
namespace System.IO;

/// <summary>
/// Extensions for the <see cref="Stream"/> class.
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Copies the contents of the stream to a new <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="stream">The source stream to copy from. The stream position will be reset to 0 before copying.</param>
    /// <param name="bufferSize">The size of the buffer used for copying. Defaults to 4096 bytes.</param>
    /// <returns>A new <see cref="MemoryStream"/> containing the copied data with position set to 0.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static Stream CopyToStream(
        this Stream stream,
        int bufferSize = 4096)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        stream.Position = 0;
        var buffer = new byte[bufferSize];
        int nRead;
        var destination = new MemoryStream();
        while ((nRead = stream.Read(buffer, 0, bufferSize)) > 0)
        {
            destination.Write(buffer, 0, nRead);
        }

        destination.Position = 0;
        return destination;
    }

    /// <summary>
    /// Reads all bytes from the stream and returns them as a byte array.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream position will be reset to 0 before reading.</param>
    /// <returns>A byte array containing all data from the stream.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static byte[] ToBytes(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        stream.Position = 0;
        var buffer = new byte[32768];
        using var ms = new MemoryStream();
        while (true)
        {
            var read = stream.Read(buffer, 0, buffer.Length);
            if (read <= 0)
            {
                return ms.ToArray();
            }

            ms.Write(buffer, 0, read);
        }
    }

    /// <summary>
    /// Reads all content from the stream and converts it to a string using the default encoding.
    /// </summary>
    /// <param name="stream">The stream to read from. The stream position will be reset to 0 before reading.</param>
    /// <returns>A string containing all text content from the stream.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static string ToStringData(this Stream stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        stream.Position = 0;
        using var reader = new StreamReader(stream);
        var val = reader.ReadToEnd();
        return val;
    }
}