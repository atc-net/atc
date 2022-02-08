namespace Atc.Tests.Units.DigitalInformation;

public class ByteSizeExtensionsTests
{
    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Decimal_Default(string expected, decimal size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Double_Default(string expected, double size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Float_Default(string expected, float size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    public void Int_Default(string expected, int size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    public void UInt_Default(string expected, uint size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Long_Default(string expected, long size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }

    [Theory]
    [InlineData("1 B", 1)]
    [InlineData("1 KB", 1024L)]
    [InlineData("2 KB", 2 * 1024L)]
    [InlineData("1 MB", 1024L * 1024L)]
    [InlineData("1 GB", 1024L * 1024L * 1024L)]
    [InlineData("1 TB", 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 PB", 1024L * 1024L * 1024L * 1024L * 1024L)]
    [InlineData("1 EB", 1024L * 1024L * 1024L * 1024L * 1024L * 1024L)]
    public void Ulong_Default(string expected, ulong size)
    {
        // Atc
        var actual = size.Bytes();

        // Assert
        Assert.Equal(expected, actual.ToString());
    }
}