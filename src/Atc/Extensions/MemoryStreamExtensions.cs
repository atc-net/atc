// ReSharper disable once CheckNamespace
namespace System.IO;

/// <summary>
/// Extensions for the <see cref="MemoryStream"/> class.
/// </summary>
public static class MemoryStreamExtensions
{
    /// <summary>
    /// Converts the memory stream content to a string using the specified encoding.
    /// </summary>
    /// <param name="stream">The memory stream to convert.</param>
    /// <param name="encoding">The encoding to use for the conversion. Defaults to <see cref="Encoding.UTF8"/> when <see langword="null"/>.</param>
    /// <returns>A string representation of the memory stream content.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stream"/> is <see langword="null"/>.</exception>
    public static string ToString(
        this MemoryStream stream,
        Encoding? encoding = null)
    {
        if (stream is null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        encoding ??= Encoding.UTF8;

        return encoding.GetString(stream.ToArray());
    }
}