namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories;

public class SyntaxClassDeclarationFactoryTests
{
    [Fact]
    public void Create_Should_Create_Public_Class()
    {
        // Arrange
        const string className = "TestClass";

        // Act
        var result = SyntaxClassDeclarationFactory.Create(className);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.Single(result.Modifiers);
        Assert.Contains("public", result.Modifiers.Select(m => m.ValueText));
    }

    [Fact]
    public void CreateWithInheritClassType_Should_Create_Class_With_Base_Class()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassType(className, baseClassName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotNull(result.BaseList);
        Assert.Contains(baseClassName, result.BaseList.Types.Select(t => t.Type.ToString()));
    }

    [Fact]
    public void CreateWithInterface_Should_Create_Class_With_Interface()
    {
        // Arrange
        const string className = "TestClass";
        const string interfaceName = "ITestInterface";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInterface(className, interfaceName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotNull(result.BaseList);
        Assert.Single(result.BaseList.Types);
        Assert.Contains(interfaceName, result.BaseList.Types.Select(t => t.Type.ToString()));
    }

    [Fact]
    public void CreateWithInheritClassAndInterface_Should_Create_Class_With_Base_And_Interface()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";
        const string interfaceName = "ITestInterface";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassAndInterface(className, baseClassName, interfaceName);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotNull(result.BaseList);
        Assert.Equal(2, result.BaseList.Types.Count);
        Assert.Contains(baseClassName, result.BaseList.Types.Select(t => t.Type.ToString()));
        Assert.Contains(interfaceName, result.BaseList.Types.Select(t => t.Type.ToString()));
    }

    [Fact]
    public void Should_Generate_Partial_Class_Definition()
    {
        // Act
        var result = SyntaxClassDeclarationFactory.CreateAsPublicPartial("TestClass");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Modifiers.Count);
        Assert.Contains("partial", result.Modifiers.Select(item => item.ValueText));
        Assert.Contains("public", result.Modifiers.Select(item => item.ValueText));
    }

    [Fact]
    public void CreateAsPublicStatic_Should_Create_Public_Static_Class()
    {
        // Arrange
        const string className = "StaticClass";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateAsPublicStatic(className);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.Equal(2, result.Modifiers.Count);
        Assert.Contains("public", result.Modifiers.Select(m => m.ValueText));
        Assert.Contains("static", result.Modifiers.Select(m => m.ValueText));
    }

    [Fact]
    public void CreateAsInternalStatic_Should_Create_Internal_Static_Class()
    {
        // Arrange
        const string className = "InternalStaticClass";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateAsInternalStatic(className);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.Equal(2, result.Modifiers.Count);
        Assert.Contains("internal", result.Modifiers.Select(m => m.ValueText));
        Assert.Contains("static", result.Modifiers.Select(m => m.ValueText));
    }

    [Fact]
    public void CreateWithSuppressMessageAttribute_Should_Add_Suppress_Message()
    {
        // Arrange
        const string className = "TestClass";
        var suppressMessage = new SuppressMessageAttribute("Design", "CA1000")
        {
            Justification = "Test justification",
        };

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithSuppressMessageAttribute(className, suppressMessage);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotEmpty(result.AttributeLists);
        Assert.Contains(
            result.AttributeLists.SelectMany(al => al.Attributes),
            attr => attr.Name
                .ToString()
                .Contains("SuppressMessage", StringComparison.Ordinal));
    }

    [Fact]
    public void CreateWithSuppressMessageAttributeByCodeAnalysisCheckId_Should_Add_Code_Analysis_Suppression()
    {
        // Arrange
        const string className = "TestClass";
        const int checkId = 1062;
        const string justification = "Test reason";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithSuppressMessageAttributeByCodeAnalysisCheckId(
            className, checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotEmpty(result.AttributeLists);
    }

    [Fact]
    public void CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId_Should_Add_Base_And_Suppression()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";
        const int checkId = 1062;
        const string justification = "Test reason";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId(
            className, baseClassName, checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotNull(result.BaseList);
        Assert.Contains(baseClassName, result.BaseList.Types.Select(t => t.Type.ToString()));
        Assert.NotEmpty(result.AttributeLists);
    }

    [Fact]
    public void CreateWithSuppressMessageAttributeByStyleCopCheckId_Should_Add_StyleCop_Suppression()
    {
        // Arrange
        const string className = "TestClass";
        const int checkId = 1413;
        const string justification = "Test reason";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithSuppressMessageAttributeByStyleCopCheckId(
            className, checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotEmpty(result.AttributeLists);
    }

    [Fact]
    public void CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId_Should_Add_Base_And_StyleCop_Suppression()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";
        const int checkId = 1413;
        const string justification = "Test reason";

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId(
            className, baseClassName, checkId, justification);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
        Assert.NotNull(result.BaseList);
        Assert.Contains(baseClassName, result.BaseList.Types.Select(t => t.Type.ToString()));
        Assert.NotEmpty(result.AttributeLists);
    }

    [Fact]
    public void CreateWithSuppressMessageAttributeByCodeAnalysisCheckId_Direct()
    {
        // Arrange
        const string className = "TestClass";
        const int checkId = 1062;

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithSuppressMessageAttributeByCodeAnalysisCheckId(className, checkId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
    }

    [Fact]
    public void CreateWithSuppressMessageAttributeByStyleCopCheckId_Direct()
    {
        // Arrange
        const string className = "TestClass";
        const int checkId = 1413;

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithSuppressMessageAttributeByStyleCopCheckId(className, checkId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
    }

    [Fact]
    public void CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId_Direct()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";
        const int checkId = 1062;

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId(
            className, baseClassName, checkId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
    }

    [Fact]
    public void CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId_Direct()
    {
        // Arrange
        const string className = "DerivedClass";
        const string baseClassName = "BaseClass";
        const int checkId = 1413;

        // Act
        var result = SyntaxClassDeclarationFactory.CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId(
            className, baseClassName, checkId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(className, result.Identifier.ValueText);
    }
}