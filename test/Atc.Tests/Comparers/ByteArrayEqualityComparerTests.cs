namespace Atc.Tests.Comparers;

public class ByteArrayEqualityComparerTests
{
    [Theory]
    [InlineData(true, new byte[] { 1, 10, 100 }, new byte[] { 1, 10, 100 })]
    [InlineData(false, new byte[] { 2, 10, 100 }, new byte[] { 1, 10, 100 })]
    [InlineData(false, new byte[] { 1, 10, 100 }, new byte[] { 2, 10, 100 })]
    [InlineData(false, new byte[] { 1, 10, 100 }, new byte[] { 1, 10, 100, 101 })]
    public void ComparerEquals(bool expected, byte[] a, byte[] b)
        => Assert.Equal(expected, new ByteArrayEqualityComparer().Equals(a, b));

    [Theory]
    [InlineData(192166, new byte[] { 1, 10, 100 })]
    [InlineData(192455, new byte[] { 2, 10, 100 })]
    public void ComparerGetHashCode(int expected, byte[] value)
        => Assert.Equal(expected, new ByteArrayEqualityComparer().GetHashCode(value));
}