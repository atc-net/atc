namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAttributeArgumentFactoryTests
{
    [Fact]
    public void Create_With_String_Should_Create_Attribute_Argument()
    {
        // Arrange
        const string attributeValue = "TestValue";

        // Act
        var result = SyntaxAttributeArgumentFactory.Create(attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Expression);
    }

    [Fact]
    public void Create_With_Int_Should_Create_Attribute_Argument()
    {
        // Arrange
        const int attributeValue = 42;

        // Act
        var result = SyntaxAttributeArgumentFactory.Create(attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Expression);
    }

    [Fact]
    public void Create_With_Object_Should_Throw_When_Null()
    {
        // Arrange
        object attributeValue = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeArgumentFactory.Create(attributeValue));
    }

    [Fact]
    public void Create_With_Object_Should_Create_Attribute_Argument()
    {
        // Arrange
        object attributeValue = 123;

        // Act
        var result = SyntaxAttributeArgumentFactory.Create(attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Expression);
    }

    [Fact]
    public void CreateWithNameEquals_With_String_Should_Create_Attribute_Argument_With_Name()
    {
        // Arrange
        const string attributeName = "TestName";
        const string attributeValue = "TestValue";

        // Act
        var result = SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.NameEquals);
        Assert.Equal(attributeName, result.NameEquals.Name.Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithNameEquals_With_Int_Should_Create_Attribute_Argument_With_Name()
    {
        // Arrange
        const string attributeName = "TestName";
        const int attributeValue = 42;

        // Act
        var result = SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.NameEquals);
        Assert.Equal(attributeName, result.NameEquals.Name.Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithNameEquals_Direct()
    {
        // Arrange
        const string name = "PropName";
        const int value = 123;

        // Act
        var result = SyntaxAttributeArgumentFactory.CreateWithNameEquals(name, value);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.NameEquals);
        Assert.Equal(name, result.NameEquals.Name.Identifier.ValueText);
    }
}