namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxParameterListFactoryTests
{
    [Fact]
    public void CreateWithOneItem_Should_Throw_When_ParameterTypeName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithOneItem(null!, "param"));
    }

    [Fact]
    public void CreateWithOneItem_Should_Throw_When_ParameterName_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithOneItem("string", null!));
    }

    [Fact]
    public void CreateWithOneItem_Should_Create_Parameter_List_With_One_Parameter()
    {
        // Arrange
        const string parameterTypeName = "string";
        const string parameterName = "testParam";

        // Act
        var result = SyntaxParameterListFactory.CreateWithOneItem(parameterTypeName, parameterName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Parameters);
        Assert.Equal(parameterName, result.Parameters[0].Identifier.Text, StringComparer.Ordinal);
    }

    [Fact]
    public void CreateWithOneParameterItem_Should_Throw_When_Parameter_Is_Null()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithOneParameterItem(null!));
    }

    [Fact]
    public void CreateWithOneParameterItem_Should_Create_Parameter_List()
    {
        // Arrange
        var parameter = SyntaxParameterFactory.Create("string", "testParam");

        // Act
        var result = SyntaxParameterListFactory.CreateWithOneParameterItem(parameter);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Parameters);
    }

    [Fact]
    public void CreateWithTwoParameterItems_Should_Throw_When_Parameter1_Is_Null()
    {
        // Arrange
        var parameter2 = SyntaxParameterFactory.Create("int", "param2");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithTwoParameterItems(null!, parameter2));
    }

    [Fact]
    public void CreateWithTwoParameterItems_Should_Throw_When_Parameter2_Is_Null()
    {
        // Arrange
        var parameter1 = SyntaxParameterFactory.Create("string", "param1");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithTwoParameterItems(parameter1, null!));
    }

    [Fact]
    public void CreateWithTwoParameterItems_Should_Create_Parameter_List_With_Two_Parameters()
    {
        // Arrange
        var parameter1 = SyntaxParameterFactory.Create("string", "param1");
        var parameter2 = SyntaxParameterFactory.Create("int", "param2");

        // Act
        var result = SyntaxParameterListFactory.CreateWithTwoParameterItems(parameter1, parameter2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Parameters.Count);
    }

    [Fact]
    public void CreateWithThreeParameterItems_Should_Throw_When_Parameter1_Is_Null()
    {
        // Arrange
        var parameter2 = SyntaxParameterFactory.Create("int", "param2");
        var parameter3 = SyntaxParameterFactory.Create("bool", "param3");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithThreeParameterItems(null!, parameter2, parameter3));
    }

    [Fact]
    public void CreateWithThreeParameterItems_Should_Throw_When_Parameter2_Is_Null()
    {
        // Arrange
        var parameter1 = SyntaxParameterFactory.Create("string", "param1");
        var parameter3 = SyntaxParameterFactory.Create("bool", "param3");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithThreeParameterItems(parameter1, null!, parameter3));
    }

    [Fact]
    public void CreateWithThreeParameterItems_Should_Throw_When_Parameter3_Is_Null()
    {
        // Arrange
        var parameter1 = SyntaxParameterFactory.Create("string", "param1");
        var parameter2 = SyntaxParameterFactory.Create("int", "param2");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            SyntaxParameterListFactory.CreateWithThreeParameterItems(parameter1, parameter2, null!));
    }

    [Fact]
    public void CreateWithThreeParameterItems_Should_Create_Parameter_List_With_Three_Parameters()
    {
        // Arrange
        var parameter1 = SyntaxParameterFactory.Create("string", "param1");
        var parameter2 = SyntaxParameterFactory.Create("int", "param2");
        var parameter3 = SyntaxParameterFactory.Create("bool", "param3");

        // Act
        var result = SyntaxParameterListFactory.CreateWithThreeParameterItems(parameter1, parameter2, parameter3);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Parameters.Count);
    }

    [Fact]
    public void CreateWithOneItem_Direct()
    {
        // Arrange
        const string parameterTypeName = "string";
        const string parameterName = "testParam";
        const string? genericListTypeName = null;

        // Act
        var result = SyntaxParameterListFactory.CreateWithOneItem(parameterTypeName, parameterName, genericListTypeName);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result.Parameters);
    }
}