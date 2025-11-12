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
    public static byte[] ConvertToTwoBytes(int value)
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
    public static byte[] ConvertToFourBytes(int value)
        => BitConverter.GetBytes(value);

    /// <summary>
    /// Create a array with the given size that only contains zeros.
    /// </summary>
    /// <param name="size">The size.</param>
    public static byte[] CreateZeroArray(int size)
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

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation with a '0x' prefix for each byte
    /// and separated with ', '.
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToStringWithPrefix() // Gives: "0x1A, 0x2B, 0x3C"</code>
    /// </summary>
    /// <param name="bytes">The byte array to be converted.</param>
    /// <returns>
    /// A string representation of the byte array in hexadecimal format, prefixed with '0x' for each byte
    /// and separated with ', '.
    /// </returns>
    /// <example>
    /// <code>
    /// byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
    /// string hex = ByteHelper.ToStringWithPrefix(exampleBytes);
    /// Console.WriteLine(hex); // Outputs: 0x1A, 0x2B, 0x3C
    /// </code>
    /// </example>
    public static string ToStringWithPrefix(byte[] bytes)
        => bytes.ToHexWithPrefix();
}