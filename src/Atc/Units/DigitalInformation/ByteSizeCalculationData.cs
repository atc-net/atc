namespace Atc.Units.DigitalInformation;

/// <summary>
/// Provides calculation data for byte size conversions including binary multiples and prefix strings.
/// </summary>
internal static class ByteSizeCalculationData
{
    /// <summary>
    /// Binary multiples for byte size units (1, 1024, 1024^2, ..., 1024^6).
    /// </summary>
    /// <remarks>
    /// Indices correspond to: [0]=Byte, [1]=Kilobyte, [2]=Megabyte, [3]=Gigabyte, [4]=Terabyte, [5]=Petabyte, [6]=Exabyte.
    /// </remarks>
    internal static readonly long[] BinaryMultiples =
    {
        1L,
        1024L,
        1024L * 1024L,
        1024L * 1024L * 1024L,
        1024L * 1024L * 1024L * 1024L,
        1024L * 1024L * 1024L * 1024L * 1024L,
        1024L * 1024L * 1024L * 1024L * 1024L * 1024L,
    };

    /// <summary>
    /// Short prefix strings for byte size units (empty, "K", "M", "G", "T", "P", "E").
    /// </summary>
    internal static readonly string[] PrefixesShort =
    {
        string.Empty,
        "K",
        "M",
        "G",
        "T",
        "P",
        "E",
    };

    /// <summary>
    /// Full prefix strings for byte size units (empty, "Kilo", "Mega", "Giga", "Tera", "Peta", "Exa").
    /// </summary>
    internal static readonly string[] PrefixesFull =
    {
        string.Empty,
        "Kilo",
        "Mega",
        "Giga",
        "Tera",
        "Peta",
        "Exa",
    };
}