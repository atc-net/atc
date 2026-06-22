namespace Atc.Tests.Extensions.BaseTypes;

public class CharExtensionsTests
{
    [Theory]
    [MemberData(nameof(TestMemberDataForExtensionsChar.IsAscii), MemberType = typeof(TestMemberDataForExtensionsChar))]
    public void IsAscii(
        bool expected,
        char input)
    {
        // Act
        var actual = input.IsAscii();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, 'A')]
    [InlineData(true, 'Z')]
    [InlineData(true, 'a')]
    [InlineData(true, 'z')]
    [InlineData(false, '0')]
    [InlineData(false, '@')]
    [InlineData(false, 'é')]
    public void IsAsciiLetter(
        bool expected,
        char input)
        => Assert.Equal(expected, input.IsAsciiLetter());

    [Theory]
    [InlineData(true, '0')]
    [InlineData(true, '9')]
    [InlineData(false, 'A')]
    [InlineData(false, '/')]
    [InlineData(false, ':')]
    public void IsAsciiDigit(
        bool expected,
        char input)
        => Assert.Equal(expected, input.IsAsciiDigit());

    [Theory]
    [InlineData(true, '0')]
    [InlineData(true, '9')]
    [InlineData(true, 'A')]
    [InlineData(true, 'F')]
    [InlineData(true, 'a')]
    [InlineData(true, 'f')]
    [InlineData(false, 'G')]
    [InlineData(false, 'g')]
    [InlineData(false, '@')]
    public void IsHexDigit(
        bool expected,
        char input)
        => Assert.Equal(expected, input.IsHexDigit());

    [Theory]
    [InlineData(true, 'A')]
    [InlineData(true, 'E')]
    [InlineData(true, 'I')]
    [InlineData(true, 'O')]
    [InlineData(true, 'U')]
    [InlineData(true, 'a')]
    [InlineData(true, 'e')]
    [InlineData(true, 'i')]
    [InlineData(true, 'o')]
    [InlineData(true, 'u')]
    [InlineData(false, 'B')]
    [InlineData(false, 'z')]
    [InlineData(false, '0')]
    public void IsVowel(
        bool expected,
        char input)
        => Assert.Equal(expected, input.IsVowel());
}