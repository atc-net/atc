namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="ClassDeclarationSyntax"/> nodes.
/// </summary>
public static class SyntaxClassDeclarationFactory
{
    /// <summary>
    /// Creates a public class declaration.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with public modifier.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax Create(string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword());
    }

    /// <summary>
    /// Creates a public class declaration that inherits from a base class.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="inheritClassTypeName">The name of the base class to inherit from.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with inheritance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> or <paramref name="inheritClassTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateWithInheritClassType(
        string classTypeName,
        string inheritClassTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (inheritClassTypeName is null)
        {
            throw new ArgumentNullException(nameof(inheritClassTypeName));
        }

        return SyntaxFactory
            .ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .AddBaseListTypes(SyntaxSimpleBaseTypeFactory.Create(inheritClassTypeName));
    }

    /// <summary>
    /// Creates a public class declaration that implements an interface.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="interfaceTypeName">The name of the interface to implement.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with interface implementation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ClassDeclarationSyntax CreateWithInterface(
        string classTypeName,
        string interfaceTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (interfaceTypeName is null)
        {
            throw new ArgumentNullException(nameof(interfaceTypeName));
        }

        return SyntaxFactory
            .ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .WithBaseList(SyntaxBaseListFactory.CreateOneSimpleBaseType(interfaceTypeName));
    }

    /// <summary>
    /// Creates a public class declaration that inherits from a base class and implements an interface.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="inheritClassTypeName">The name of the base class to inherit from.</param>
    /// <param name="interfaceTypeName">The name of the interface to implement.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with inheritance and interface implementation.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ClassDeclarationSyntax CreateWithInheritClassAndInterface(
        string classTypeName,
        string inheritClassTypeName,
        string interfaceTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (inheritClassTypeName is null)
        {
            throw new ArgumentNullException(nameof(inheritClassTypeName));
        }

        if (interfaceTypeName is null)
        {
            throw new ArgumentNullException(nameof(interfaceTypeName));
        }

        return SyntaxFactory
            .ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .WithBaseList(SyntaxBaseListFactory.CreateTwoSimpleBaseTypes(inheritClassTypeName, interfaceTypeName));
    }

    /// <summary>
    /// Creates a public partial class declaration.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with public and partial modifiers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateAsPublicPartial(
        string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword(), SyntaxTokenFactory.PartialKeyword());
    }

    /// <summary>
    /// Creates a public static class declaration.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with public and static modifiers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateAsPublicStatic(
        string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword(), SyntaxTokenFactory.StaticKeyword());
    }

    /// <summary>
    /// Creates an internal static class declaration.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with internal and static modifiers.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateAsInternalStatic(
        string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.InternalKeyword(), SyntaxTokenFactory.StaticKeyword());
    }

    /// <summary>
    /// Creates a public class declaration with a suppress message attribute.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="suppressMessage">The suppress message attribute to add.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with the suppress message attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ClassDeclarationSyntax CreateWithSuppressMessageAttribute(
        string classTypeName,
        SuppressMessageAttribute suppressMessage)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (suppressMessage is null)
        {
            throw new ArgumentNullException(nameof(suppressMessage));
        }

        return Create(classTypeName)
            .AddSuppressMessageAttribute(suppressMessage);
    }

    /// <summary>
    /// Creates a public class declaration with a Code Analysis suppress message attribute.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="checkId">The Code Analysis check ID to suppress.</param>
    /// <param name="justification">The justification for suppressing the check.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with the suppress message attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateWithSuppressMessageAttributeByCodeAnalysisCheckId(
        string classTypeName,
        int checkId,
        string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return Create(classTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, justification));
    }

    /// <summary>
    /// Creates a public class declaration with inheritance and a Code Analysis suppress message attribute.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="inheritClassTypeName">The name of the base class to inherit from.</param>
    /// <param name="checkId">The Code Analysis check ID to suppress.</param>
    /// <param name="justification">The justification for suppressing the check.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with inheritance and the suppress message attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId(
        string classTypeName,
        string inheritClassTypeName,
        int checkId,
        string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (inheritClassTypeName is null)
        {
            throw new ArgumentNullException(nameof(inheritClassTypeName));
        }

        return CreateWithInheritClassType(classTypeName, inheritClassTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, justification));
    }

    /// <summary>
    /// Creates a public class declaration with a StyleCop suppress message attribute.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="checkId">The StyleCop check ID to suppress.</param>
    /// <param name="justification">The justification for suppressing the check.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with the suppress message attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="classTypeName"/> is null.</exception>
    public static ClassDeclarationSyntax CreateWithSuppressMessageAttributeByStyleCopCheckId(
        string classTypeName,
        int checkId,
        string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return Create(classTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, justification));
    }

    /// <summary>
    /// Creates a public class declaration with inheritance and a StyleCop suppress message attribute.
    /// </summary>
    /// <param name="classTypeName">The name of the class.</param>
    /// <param name="inheritClassTypeName">The name of the base class to inherit from.</param>
    /// <param name="checkId">The StyleCop check ID to suppress.</param>
    /// <param name="justification">The justification for suppressing the check.</param>
    /// <returns>A <see cref="ClassDeclarationSyntax"/> with inheritance and the suppress message attribute.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId(
        string classTypeName,
        string inheritClassTypeName,
        int checkId,
        string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (inheritClassTypeName is null)
        {
            throw new ArgumentNullException(nameof(inheritClassTypeName));
        }

        return CreateWithInheritClassType(classTypeName, inheritClassTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, justification));
    }
}