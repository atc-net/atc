// ReSharper disable StringLiteralTypo
#pragma warning disable xUnit1012
namespace Atc.Tests.Formatters;

public class StringCaseFormatterTests
{
    private readonly StringCaseFormatter formatter = StringCaseFormatter.Default;

    [Theory]
    [InlineData("test", "TesT", "L")]
    [InlineData("tesT", "TesT", "l")]
    [InlineData("TEST", "TesT", "U")]
    [InlineData("TesT", "TesT", "u")]
    [InlineData("test", "tESt", "L")]
    [InlineData("tESt", "tESt", "l")]
    [InlineData("TEST", "tESt", "U")]
    [InlineData("TESt", "tESt", "u")]
    [InlineData("test.", "TesT", "L.")]
    [InlineData("tesT.", "TesT", "l.")]
    [InlineData("TEST.", "TesT", "U.")]
    [InlineData("TesT.", "TesT", "u.")]
    [InlineData("test.", "tESt", "L.")]
    [InlineData("tESt.", "tESt", "l.")]
    [InlineData("TEST.", "tESt", "U.")]
    [InlineData("TESt.", "tESt", "u.")]
    [InlineData("test:", "TesT", "L:")]
    [InlineData("tesT:", "TesT", "l:")]
    [InlineData("TEST:", "TesT", "U:")]
    [InlineData("TesT:", "TesT", "u:")]
    [InlineData("test:", "tESt", "L:")]
    [InlineData("tESt:", "tESt", "l:")]
    [InlineData("TEST:", "tESt", "U:")]
    [InlineData("TESt:", "tESt", "u:")]
    public void FormatStringForDefault(
        string expected,
        string input,
        string formatSpecifier)
        => Assert.Equal(
            expected,
            string.Format(StringCaseFormatter.Default, $"{{0:{formatSpecifier}}}", input));

    [Theory]
    [InlineData("test", "test", "L")]
    [InlineData("test", "TEST", "L")]
    [InlineData("test", "test", "l")]
    [InlineData("tEST", "TEST", "l")]
    [InlineData("TEST", "test", "U")]
    [InlineData("TEST", "TEST", "U")]
    [InlineData("Test", "test", "u")]
    [InlineData("TEST", "TEST", "u")]
    [InlineData("test", "test", "x")]
    [InlineData("test", "test", "")]
    [InlineData("", null, "U")]
    [InlineData("john doe", "john doe", "L")]
    [InlineData("john doe", "john doe", "l")]
    [InlineData("JOHN DOE", "john doe", "U")]
    [InlineData("John doe", "john doe", "u")]
    [InlineData("john doe", "JOHN DOE", "L")]
    [InlineData("jOHN DOE", "JOHN DOE", "l")]
    [InlineData("JOHN DOE", "JOHN DOE", "U")]
    [InlineData("JOHN DOE", "JOHN DOE", "u")]
    [InlineData("John doe", "JOHN DOE", "Lu")]
    [InlineData("jOHN DOE", "JOHN DOE", "Ul")]
    [InlineData("John doe.", "john doe", "Lu.")]
    [InlineData("jOHN DOE.", "JOHN DOE", "Ul.")]
    [InlineData("John doe:", "john doe", "Lu:")]
    [InlineData("jOHN DOE:", "john doe", "Ul:")]
    public void FormatStringForOneParameter(
        string expected,
        string input,
        string formatSpecifier)
        => Assert.Equal(
            expected,
            string.Format(formatter, $"{{0:{formatSpecifier}}}", input));

    [Theory]
    [InlineData("hallo world", "Hallo", "World", "L", "L")]
    [InlineData("hallo world", "Hallo", "World", "L", "l")]
    [InlineData("hallo world", "Hallo", "World", "l", "l")]
    [InlineData("hallo world", "Hallo", "World", "l", "L")]
    [InlineData("hallo world", "HALLO", "WORLD", "L", "L")]
    [InlineData("hallo wORLD", "HALLO", "WORLD", "L", "l")]
    [InlineData("hALLO wORLD", "HALLO", "WORLD", "l", "l")]
    [InlineData("hALLO world", "HALLO", "WORLD", "l", "L")]
    [InlineData("hallo world", "hallo", "world", "L", "L")]
    [InlineData("hallo world", "hallo", "world", "L", "l")]
    [InlineData("hallo world", "hallo", "world", "l", "l")]
    [InlineData("hallo world", "hallo", "world", "l", "L")]
    [InlineData("HALLO WORLD", "Hallo", "World", "U", "U")]
    [InlineData("HALLO World", "Hallo", "World", "U", "u")]
    [InlineData("Hallo World", "Hallo", "World", "u", "u")]
    [InlineData("Hallo WORLD", "Hallo", "World", "u", "U")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "U", "U")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "U", "u")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "u", "u")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "u", "U")]
    [InlineData("HALLO WORLD", "hallo", "world", "U", "U")]
    [InlineData("HALLO World", "hallo", "world", "U", "u")]
    [InlineData("Hallo World", "hallo", "world", "u", "u")]
    [InlineData("Hallo WORLD", "hallo", "world", "u", "U")]
    public void FormatStringForTwoParameters(
        string expected,
        string input1,
        string input2,
        string formatSpecifier1,
        string formatSpecifier2)
        => Assert.Equal(
            expected,
            string.Format(formatter, $"{{0:{formatSpecifier1}}} {{1:{formatSpecifier2}}}", input1, input2));

    [Theory]
    [InlineData("hallo world", "Hallo", "World", "L", "L")]
    [InlineData("hallo world", "Hallo", "World", "L", "l")]
    [InlineData("hallo world", "Hallo", "World", "l", "l")]
    [InlineData("hallo world", "Hallo", "World", "l", "L")]
    [InlineData("hallo world", "HALLO", "WORLD", "L", "L")]
    [InlineData("hallo wORLD", "HALLO", "WORLD", "L", "l")]
    [InlineData("hALLO wORLD", "HALLO", "WORLD", "l", "l")]
    [InlineData("hALLO world", "HALLO", "WORLD", "l", "L")]
    [InlineData("hallo world", "hallo", "world", "L", "L")]
    [InlineData("hallo world", "hallo", "world", "L", "l")]
    [InlineData("hallo world", "hallo", "world", "l", "l")]
    [InlineData("hallo world", "hallo", "world", "l", "L")]
    [InlineData("HALLO WORLD", "Hallo", "World", "U", "U")]
    [InlineData("HALLO World", "Hallo", "World", "U", "u")]
    [InlineData("Hallo World", "Hallo", "World", "u", "u")]
    [InlineData("Hallo WORLD", "Hallo", "World", "u", "U")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "U", "U")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "U", "u")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "u", "u")]
    [InlineData("HALLO WORLD", "HALLO", "WORLD", "u", "U")]
    [InlineData("HALLO WORLD", "hallo", "world", "U", "U")]
    [InlineData("HALLO World", "hallo", "world", "U", "u")]
    [InlineData("Hallo World", "hallo", "world", "u", "u")]
    [InlineData("Hallo WORLD", "hallo", "world", "u", "U")]
    public void StaticFormatStringForTwoParameters(
        string expected,
        string input1,
        string input2,
        string formatSpecifier1,
        string formatSpecifier2)
        => Assert.Equal(
            expected,
            StringCaseFormatter.Format($"{{0:{formatSpecifier1}}} {{1:{formatSpecifier2}}}", input1, input2));

    [Fact]
    public void GetFormat_ReturnsThis_WhenTypeIsICustomFormatter()
    {
        // Arrange
        var sut = new StringCaseFormatter();

        // Act
        var actual = sut.GetFormat(typeof(ICustomFormatter));

        // Assert
        Assert.Same(sut, actual);
    }

    [Fact]
    public void GetFormat_ReturnsNull_WhenTypeIsNotICustomFormatter()
    {
        // Arrange
        var sut = new StringCaseFormatter();

        // Act
        var actual = sut.GetFormat(typeof(IFormatProvider));

        // Assert
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("TEST", "test", "U")]
    [InlineData("Test", "test", "u")]
    [InlineData("test", "TEST", "L")]
    [InlineData("tEST", "TEST", "l")]
    [InlineData("Test", "TEST", "Lu")]
    [InlineData("tEST", "test", "Ul")]
    [InlineData("TEST.", "test", "U.")]
    [InlineData("test:", "TEST", "L:")]
    [InlineData("", null, "U")]
    [InlineData("unchanged", "unchanged", "")]
    [InlineData("unchanged", "unchanged", null)]
    public void Format_DirectCall(
        string expected,
        string input,
        string formatSpecifier)
    {
        // Arrange
        var sut = new StringCaseFormatter();

        // Act
        var actual = sut.Format(formatSpecifier, input, null);

        // Assert
        Assert.Equal(expected, actual);
    }
}