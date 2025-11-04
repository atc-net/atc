namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxAttributeFactoryTests
{
    [Fact]
    public void Create_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.Create(null!));
    }

    [Fact]
    public void Create_Should_Create_Attribute_Without_Suffix()
    {
        // Arrange
        const string attributeName = "TestAttribute";

        // Act
        var result = SyntaxAttributeFactory.Create(attributeName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_String_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.CreateWithOneItemWithOneArgument(null!, "value"));
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_String_Should_Throw_When_ArgumentValue_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.CreateWithOneItemWithOneArgument("TestAttribute", null!));
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_String_Should_Create_Attribute_With_Argument()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        const string argumentValue = "TestValue";

        // Act
        var result = SyntaxAttributeFactory.CreateWithOneItemWithOneArgument(attributeName, argumentValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_Int_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.CreateWithOneItemWithOneArgument(null!, 42));
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_Int_Should_Create_Attribute_With_Argument()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        const int argumentValue = 42;

        // Act
        var result = SyntaxAttributeFactory.CreateWithOneItemWithOneArgument(attributeName, argumentValue);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateWithOneItemWithTwoArgument_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.CreateWithOneItemWithTwoArgument(null!, 1, 2));
    }

    [Fact]
    public void CreateWithOneItemWithTwoArgument_Should_Create_Attribute_With_Two_Arguments()
    {
        // Arrange
        const string attributeName = "RangeAttribute";
        object argumentValue1 = 1;
        object argumentValue2 = 100;

        // Act
        var result = SyntaxAttributeFactory.CreateWithOneItemWithTwoArgument(attributeName, argumentValue1, argumentValue2);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.ArgumentList);
        Assert.Equal(2, result.ArgumentList.Arguments.Count);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Throw_When_ValidationAttribute_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.CreateFromValidationAttribute(null!));
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_EmailAddressAttribute()
    {
        // Arrange
        var validationAttribute = new EmailAddressAttribute();

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("EmailAddress", result.Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_RequiredAttribute()
    {
        // Arrange
        var validationAttribute = new RequiredAttribute();

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Required", result.Name.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_MinLengthAttribute()
    {
        // Arrange
        var validationAttribute = new MinLengthAttribute(5);

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("MinLength", result.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_MaxLengthAttribute()
    {
        // Arrange
        var validationAttribute = new MaxLengthAttribute(100);

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("MaxLength", result.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_RangeAttribute()
    {
        // Arrange
        var validationAttribute = new RangeAttribute(1, 100);

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Range", result.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
        Assert.Equal(2, result.ArgumentList.Arguments.Count);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_RegularExpressionAttribute()
    {
        // Arrange
        var validationAttribute = new RegularExpressionAttribute(@"^\d+$");

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("RegularExpression", result.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void CreateFromValidationAttribute_Should_Create_Attribute_For_StringLengthAttribute()
    {
        // Arrange
        var validationAttribute = new StringLengthAttribute(50);

        // Act
        var result = SyntaxAttributeFactory.CreateFromValidationAttribute(validationAttribute);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("StringLength", result.Name.ToString(), StringComparer.Ordinal);
        Assert.NotNull(result.ArgumentList);
        Assert.Single(result.ArgumentList.Arguments);
    }

    [Fact]
    public void RemoveSuffix_Should_Throw_When_AttributeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxAttributeFactory.RemoveSuffix(null!));
    }

    [Fact]
    public void RemoveSuffix_Should_Remove_Attribute_Suffix()
    {
        // Arrange
        const string attributeName = "TestAttribute";

        // Act
        var result = SyntaxAttributeFactory.RemoveSuffix(attributeName);

        // Assert
        Assert.Equal("Test", result, StringComparer.Ordinal);
    }

    [Fact]
    public void RemoveSuffix_Should_Return_Same_Name_When_No_Suffix()
    {
        // Arrange
        const string attributeName = "Test";

        // Act
        var result = SyntaxAttributeFactory.RemoveSuffix(attributeName);

        // Assert
        Assert.Equal("Test", result, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithOneItemWithOneArgument_With_Int()
    {
        // Arrange
        const string attributeName = "TestAttribute";
        const int argumentValue = 42;

        // Act
        var result = SyntaxAttributeFactory.CreateWithOneItemWithOneArgument(attributeName, argumentValue);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.Name.ToString(), StringComparer.Ordinal);
    }
}