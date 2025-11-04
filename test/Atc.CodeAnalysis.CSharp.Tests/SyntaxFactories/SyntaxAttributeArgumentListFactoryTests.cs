namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAttributeArgumentListFactoryTests
{
    [Fact]
    public void CreateWithOneItemWithNameEquals_With_String_Should_Create_Argument_List()
    {
        // Arrange
        const string attributeName = "TestName";
        const string attributeValue = "TestValue";

        // Act
        var result = SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals(attributeName, attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
        var argument = result.Arguments[0];
        Assert.NotNull(argument.NameEquals);
        Assert.Equal(attributeName, argument.NameEquals.Name.Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithOneItemWithNameEquals_With_Int_Should_Create_Argument_List()
    {
        // Arrange
        const string attributeName = "TestName";
        const int attributeValue = 42;

        // Act
        var result = SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals(attributeName, attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
        var argument = result.Arguments[0];
        Assert.NotNull(argument.NameEquals);
        Assert.Equal(attributeName, argument.NameEquals.Name.Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithOneItemWithNameEquals_Direct()
    {
        // Arrange
        const string name = "AttrName";
        const int value = 999;

        // Act
        var result = SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals(name, value);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Arguments);
    }
}