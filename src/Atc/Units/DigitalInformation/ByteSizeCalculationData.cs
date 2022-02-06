namespace Atc.Units.DigitalInformation;

internal static class ByteSizeCalculationData
{
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