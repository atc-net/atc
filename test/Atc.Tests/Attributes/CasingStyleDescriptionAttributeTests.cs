namespace Atc.Tests.Attributes;

public class CasingStyleDescriptionAttributeTests
{
    [Fact]
    public void Description_ShouldReturnExpected_WhenDefaultIsCamelCase()
    {
        var attribute = new CasingStyleDescriptionAttribute
        {
            Default = CasingStyle.CamelCase,
        };

        const string expected = "Valid values are: CamelCase (default), KebabCase, PascalCase, SnakeCase";
        Assert.Equal(expected, attribute.Description);
    }

    [Fact]
    public void Description_ShouldReturnExpected_WhenDefaultIsPascalCase()
    {
        var attribute = new CasingStyleDescriptionAttribute
        {
            Default = CasingStyle.PascalCase,
        };

        const string expected = "Valid values are: CamelCase, KebabCase, PascalCase (default), SnakeCase";
        Assert.Equal(expected, attribute.Description);
    }

    [Fact]
    public void Description_ShouldIncludePrefix_WhenPrefixIsSet()
    {
        var attribute = new CasingStyleDescriptionAttribute
        {
            Default = CasingStyle.SnakeCase,
            Prefix = "Allowed",
        };

        const string expected = "Allowed. Valid values are: CamelCase, KebabCase, PascalCase, SnakeCase (default)";
        Assert.Equal(expected, attribute.Description);
    }

    [Fact]
    public void Description_ShouldHandleEmptyPrefix_Correctly()
    {
        var attribute = new CasingStyleDescriptionAttribute
        {
            Default = CasingStyle.KebabCase,
            Prefix = string.Empty,
        };

        const string expected = "Valid values are: CamelCase, KebabCase (default), PascalCase, SnakeCase";
        Assert.Equal(expected, attribute.Description);
    }
}