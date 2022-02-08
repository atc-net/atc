// ReSharper disable once CheckNamespace
namespace System.IO;

/// <summary>
/// Extensions for the <see cref="Stream"/> class.
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Copy to stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bufferSize">Size of the buffer.</param>
    public static Stream CopyToStream(this Stream stream, int bufferSize = 4096)
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
    /// Converts to bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
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
    /// Converts to string.
    /// </summary>
    /// <param name="stream">The stream.</param>
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