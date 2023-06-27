namespace Atc.Tests.Helpers;

public class DropDownFirstItemTypeHelperTests
{
    [Theory]
    [InlineData("48D811F1-B118-4D3E-A1ED-8B2D0D40FB50", DropDownFirstItemType.None)]
    [InlineData("2E296A8E-DE37-4DE6-ACE6-02C63E0251B8", DropDownFirstItemType.Blank)]
    [InlineData("B70DA7F5-600A-46B5-8FAC-4883E550C7EB", DropDownFirstItemType.PleaseSelect)]
    [InlineData("1FAFFE9E-4C72-44A3-A234-B71DCBE8BAF0", DropDownFirstItemType.IncludeAll)]
    public void GetEnumGuid(string expected, DropDownFirstItemType input)
    {
        // Act
        var actual = DropDownFirstItemTypeHelper.GetEnumGuid(input);

        // Assert
        Assert.Equal(expected, actual.ToString().ToUpperInvariant());
    }

    [Theory]
    [InlineData(DropDownFirstItemType.None, "48D811F1-B118-4D3E-A1ED-8B2D0D40FB50")]
    [InlineData(DropDownFirstItemType.Blank, "2E296A8E-DE37-4DE6-ACE6-02C63E0251B8")]
    [InlineData(DropDownFirstItemType.PleaseSelect, "B70DA7F5-600A-46B5-8FAC-4883E550C7EB")]
    [InlineData(DropDownFirstItemType.IncludeAll, "1FAFFE9E-4C72-44A3-A234-B71DCBE8BAF0")]
    public void GetItemFromEnumGuid(DropDownFirstItemType expected, string input)
    {
        // Arrange
        var guid = Guid.Parse(input);

        // Act
        var actual = DropDownFirstItemTypeHelper.GetItemFromEnumGuid(guid);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2, "John", DropDownFirstItemType.None)]
    [InlineData(3, "", DropDownFirstItemType.Blank)]
    [InlineData(3, "-- Select --", DropDownFirstItemType.PleaseSelect)]
    [InlineData(3, "-- All --", DropDownFirstItemType.IncludeAll)]
    public void EnsureFirstItemType(int expectedCount, string expectedFirstItem, DropDownFirstItemType input)
    {
        // Arrange
        var list = new List<string>
        {
            "John",
            "Bob",
        };

        // Act
        var actual = DropDownFirstItemTypeHelper.EnsureFirstItemType(list, input);

        // Assert
        actual.Should().HaveCount(expectedCount);
        Assert.Equal(expectedFirstItem, actual[0]);
    }
}