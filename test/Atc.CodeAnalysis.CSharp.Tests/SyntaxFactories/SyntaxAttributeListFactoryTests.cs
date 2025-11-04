namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAttributeListFactoryTests
{
    [Fact]
    public void Create_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeListFactory.Create(null!));
    }

    [Fact]
    public void Create_Should_Create_Attribute_List_With_Attribute()
    {
        // Arrange
        const string attributeName = "TestAttribute";

        // Act
        var result = SyntaxAttributeListFactory.Create(attributeName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Attributes);
        Assert.Equal("Test", result.Attributes[0].Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void Create_With_ArgumentList_Should_Throw_When_AttributeName_Is_Null()
    {
        // Arrange
        var argumentList = SyntaxFactory.AttributeArgumentList();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeListFactory.Create(null!, argumentList));
    }

    [Fact]
    public void Create_With_ArgumentList_Should_Create_Attribute_List_With_Arguments()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        var argumentList = SyntaxAttributeArgumentListFactory.CreateWithOneItemWithNameEquals("TestName", "TestValue");

        // Act
        var result = SyntaxAttributeListFactory.Create(attributeName, argumentList);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Attributes);
        Assert.NotNull(result.Attributes[0].ArgumentList);
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(null!, "value"));
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_Should_Create_Attribute_List_With_One_Argument()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        const string argumentValue = "TestValue";

        // Act
        var result = SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(attributeName, argumentValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Attributes);
        var attribute = result.Attributes[0];
        Assert.NotNull(attribute.ArgumentList);
        Assert.Single(attribute.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateWithOneItemWithOneArgumentWithNameEquals_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeListFactory.CreateWithOneItemWithOneArgumentWithNameEquals(null!, "name", "value"));
    }

    [Fact]
    public void CreateWithOneItemWithOneArgumentWithNameEquals_Should_Create_Attribute_List_With_Named_Argument()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        const string argumentName = "TestName";
        const string argumentValue = "TestValue";

        // Act
        var result = SyntaxAttributeListFactory.CreateWithOneItemWithOneArgumentWithNameEquals(attributeName, argumentName, argumentValue);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Attributes);
        var attribute = result.Attributes[0];
        Assert.NotNull(attribute.ArgumentList);
        Assert.Single(attribute.ArgumentList.Arguments);
        var argument = attribute.ArgumentList.Arguments[0];
        Assert.NotNull(argument.NameEquals);
        Assert.Equal(argumentName, argument.NameEquals.Name.Identifier.Text, StringComparer.Ordinal);
    }
}