namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxParameterFactoryTests
{
    [Fact]
    public void Create_Should_Throw_When_ParameterTypeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterFactory.Create(null!, "paramName"));
    }

    [Fact]
    public void Create_Should_Throw_When_ParameterName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterFactory.Create("string", null!));
    }

    [Fact]
    public void Create_Should_Create_Parameter_Without_Generic()
    {
        // Arrange
        const string parameterTypeName = "string";
        const string parameterName = "testParam";

        // Act
        var result = SyntaxParameterFactory.Create(parameterTypeName, parameterName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(parameterName, result.Identifier.Text, StringComparer.Ordinal);
        Assert.NotNull(result.Type);
        Assert.Equal(parameterTypeName, result.Type.ToString(), StringComparer.Ordinal);
    }

    [Fact]
    public void Create_Should_Create_Parameter_With_Generic()
    {
        // Arrange
        const string parameterTypeName = "string";
        const string parameterName = "testParam";
        const string genericListTypeName = "List";

        // Act
        var result = SyntaxParameterFactory.Create(parameterTypeName, parameterName, genericListTypeName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(parameterName, result.Identifier.Text, StringComparer.Ordinal);
        Assert.NotNull(result.Type);
        var typeText = result.Type.ToString();
        Assert.Contains(genericListTypeName, typeText, StringComparison.Ordinal);
        Assert.Contains(parameterTypeName, typeText, StringComparison.Ordinal);
    }

    [Fact]
    public void CreateWithAttribute_Should_Throw_When_AttributeTypeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterFactory.CreateWithAttribute(null!, "string", "param"));
    }

    [Fact]
    public void CreateWithAttribute_Should_Throw_When_ParameterTypeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterFactory.CreateWithAttribute("Required", null!, "param"));
    }

    [Fact]
    public void CreateWithAttribute_Should_Throw_When_ParameterName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterFactory.CreateWithAttribute("Required", "string", null!));
    }

    [Fact]
    public void CreateWithAttribute_Should_Create_Parameter_With_Attribute()
    {
        // Arrange
        const string attributeTypeName = "Required";
        const string parameterTypeName = "string";
        const string parameterName = "testParam";

        // Act
        var result = SyntaxParameterFactory.CreateWithAttribute(attributeTypeName, parameterTypeName, parameterName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(parameterName, result.Identifier.Text, StringComparer.Ordinal);
        Assert.NotEmpty(result.AttributeLists);
    }
}