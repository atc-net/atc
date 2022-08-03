// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the byte class.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    /// Take some bytes from a given start position and for the given length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
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
    /// Take some bytes from a given start position and for the given length and convert to Int.
    /// and convert to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
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
    /// Take some bytes from a given start position and for the given length and convert to Long.
    /// and convert to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
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
    /// Take the remaining bytes from a given start position.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
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
}