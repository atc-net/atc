namespace Atc.Tests.Extensions.BaseTypes;

public class CharExtensionsTests
{
    [Theory]
    [MemberData(
        nameof(TestMemberDataForExtensionsChar.IsAscii),
        MemberType = typeof(TestMemberDataForExtensionsChar))]
    public void IsAscii(bool expected, char input)
    {
        // Act
        var actual = input.IsAscii();

        // Assert
        Assert.Equal(expected, actual);
    }
}