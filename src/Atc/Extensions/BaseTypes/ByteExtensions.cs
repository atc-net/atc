// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the byte class.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    /// Extracts a subset of bytes from the byte array starting at the specified position.
    /// </summary>
    /// <param name="value">The source byte array.</param>
    /// <param name="startPosition">The zero-based starting position.</param>
    /// <param name="length">The number of bytes to extract.</param>
    /// <returns>A byte array containing the extracted bytes, or an empty array if the range is invalid.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public static byte[] TakeBytes(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < startPosition + length)
        {
            return Array.Empty<byte>();
        }

        return value
            .Skip(startPosition)
            .Take(length)
            .ToArray();
    }

    /// <summary>
    /// Extracts bytes from the array and converts them to a 32-bit integer.
    /// </summary>
    /// <param name="value">The source byte array.</param>
    /// <param name="startPosition">The zero-based starting position.</param>
    /// <param name="length">The number of bytes to extract (must not exceed 4 bytes).</param>
    /// <returns>The converted integer value, or -1 if the conversion fails or the length exceeds 4 bytes.</returns>
    public static int TakeBytesAndConvertToInt(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (length > sizeof(int))
        {
            return -1;
        }

        var bytes = TakeBytes(value, startPosition, length);
        if (bytes.Length == 0)
        {
            return -1;
        }

        if (length < sizeof(int))
        {
            bytes = bytes
                .Concat(ByteHelper.CreateZeroArray(length))
                .ToArray();
        }

        return BitConverter.ToInt32(bytes);
    }

    /// <summary>
    /// Extracts bytes from the array and converts them to a 64-bit integer.
    /// </summary>
    /// <param name="value">The source byte array.</param>
    /// <param name="startPosition">The zero-based starting position.</param>
    /// <param name="length">The number of bytes to extract (must not exceed 8 bytes).</param>
    /// <returns>The converted long value, or -1 if the conversion fails or the length exceeds 8 bytes.</returns>
    public static long TakeBytesAndConvertToLong(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (length > sizeof(long))
        {
            return -1;
        }

        var bytes = TakeBytes(value, startPosition, length);
        if (bytes.Length == 0)
        {
            return -1;
        }

        if (length < sizeof(long))
        {
            bytes = bytes
                .Concat(ByteHelper.CreateZeroArray(length))
                .ToArray();
        }

        return BitConverter.ToInt64(bytes);
    }

    /// <summary>
    /// Extracts all remaining bytes from the array starting at the specified position.
    /// </summary>
    /// <param name="value">The source byte array.</param>
    /// <param name="startPosition">The zero-based starting position.</param>
    /// <returns>A byte array containing all bytes from the start position to the end, or an empty array if the position is invalid.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
    public static byte[] TakeRemainingBytes(
        this byte[] value,
        int startPosition = 0)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < startPosition)
        {
            return Array.Empty<byte>();
        }

        return value
            .Skip(startPosition)
            .ToArray();
    }

    /// <summary>
    /// Splits a byte sequence by a specific byte delimiter into multiple byte arrays.
    /// </summary>
    /// <param name="source">The source byte sequence to split.</param>
    /// <param name="splitByte">The delimiter byte to split on.</param>
    /// <returns>An enumerable sequence of byte arrays, split at each occurrence of the delimiter byte.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static IEnumerable<byte[]> Split(
        this IEnumerable<byte> source,
        byte splitByte)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SplitSource();

        IEnumerable<byte[]> SplitSource()
        {
            var current = new List<byte>();

            foreach (var b in source)
            {
                if (b == splitByte)
                {
                    if (current.Count > 0)
                    {
                        yield return current.ToArray();
                    }

                    current.Clear();
                    continue;
                }

                current.Add(b);
            }

            if (current.Count > 0)
            {
                yield return current.ToArray();
            }
        }
    }

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation.
    /// Examples:
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex() // Gives: "1A2B3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex("-") // Gives: "1A-2B-3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex("-", true) // Gives: "0x1A-0x2B-0x3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex(", ", true) // Gives: "0x1A, 0x2B, 0x3C"</code>
    /// </summary>
    /// <param name="value">The byte array to be converted.</param>
    /// <param name="separator">An optional character used to separate the hexadecimal values. If not provided, there will be no separator between values.</param>
    /// <param name="showHexSign">A flag indicating whether to prepend each hexadecimal value with '0x'. Defaults to false.</param>
    /// <returns>
    /// A string representation of the byte array in hexadecimal format.
    /// </returns>
    /// <example>
    /// Here are several examples of using the ToHex method:
    /// <code>
    /// byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
    ///
    /// // Example without separator
    /// Console.WriteLine(exampleBytes.ToHex()); // Outputs: 1A2B3C
    ///
    /// // Example with separator
    /// Console.WriteLine(exampleBytes.ToHex("-")); // Outputs: 1A-2B-3C
    ///
    /// // Example with separator and hex sign
    /// Console.WriteLine(exampleBytes.ToHex("-", true)); // Outputs: 0x1A-0x2B-0x3C
    ///
    /// // Example with separator and hex sign - Note: Same as exampleBytes.ToHexWithPrefix()
    /// Console.WriteLine(exampleBytes.ToHex(", ", true)); // Outputs: 0x1A, 0x2B, 0x3C
    /// </code>
    /// </example>
    public static string ToHex(
        this byte[] value,
        string? separator = null,
        bool showHexSign = false)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var s = BitConverter.ToString(value);
        if (separator is null)
        {
            return s.Replace("-", string.Empty, StringComparison.Ordinal);
        }

        return showHexSign
            ? "0x" + s.Replace("-", $"{separator}0x", StringComparison.Ordinal)
            : s.Replace("-", separator, StringComparison.Ordinal);
    }

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation with a '0x' prefix for each byte
    /// and separated with ', '.
    /// Examples:
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHexWithPrefix() // Gives: "0x1A, 0x2B, 0x3C"</code>
    /// </summary>
    /// <param name="value">The byte array to be converted.</param>
    /// <returns>
    /// A string representation of the byte array in hexadecimal format, prefixed with '0x' for each byte
    /// and separated with ', '.
    /// </returns>
    /// <example>
    /// <code>
    /// byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
    /// string hex = ToHexWithPrefix(exampleBytes);
    /// Console.WriteLine(hex); // Outputs: 0x1A, 0x2B, 0x3C
    /// </code>
    /// </example>
    public static string ToHexWithPrefix(
        this byte[] value)
        => ToHex(value, separator: ", ", showHexSign: true);
}