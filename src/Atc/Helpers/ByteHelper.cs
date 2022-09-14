namespace Atc.Helpers;

/// <summary>
/// ByteHelper.
/// </summary>
public static class ByteHelper
{
    /// <summary>
    /// Convert the <see cref="int"/> value to two bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    public static byte[] ConvertToTwoBytes(
        int value)
    {
        var src = BitConverter.GetBytes(value);
        var dest = new byte[2];
        Buffer.BlockCopy(src, 0, dest, 0, 2);
        return dest;
    }

    /// <summary>
    /// Convert the <see cref="int"/> value to four bytes.
    /// </summary>
    /// <param name="value">The value.</param>
    public static byte[] ConvertToFourBytes(
        int value)
    {
        return BitConverter.GetBytes(value);
    }

    /// <summary>
    /// Create a array with the given size that only contains zeros.
    /// </summary>
    /// <param name="size">The size.</param>
    public static byte[] CreateZeroArray(
        int size)
        => new byte[size];

    /// <summary>
    /// Determines whether the specified value has the bit set
    /// compared with the check-value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="checkValue">The check value.</param>
    public static bool HasBit(
        byte value,
        byte checkValue)
        => (value & checkValue) > 0;

    /// <summary>
    /// Determines whether the specified value has the bit set
    /// compared with the check-value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="checkValue">The check value.</param>
    public static bool HasBit(
        byte value,
        int checkValue)
        => (value & checkValue) > 0;
}