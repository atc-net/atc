namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxClassDeclarationFactory
{
    public static ClassDeclarationSyntax Create(string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword());
    }

    public static ClassDeclarationSyntax CreateWithInheritClassType(string classTypeName, string inheritClassTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (inheritClassTypeName is null)
        {
            throw new ArgumentNullException(nameof(inheritClassTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .AddBaseListTypes(SyntaxSimpleBaseTypeFactory.Create(inheritClassTypeName));
    }

    public static ClassDeclarationSyntax CreateWithInterface(string classTypeName, string interfaceTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        if (interfaceTypeName is null)
        {
            throw new ArgumentNullException(nameof(interfaceTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .WithBaseList(SyntaxBaseListFactory.CreateOneSimpleBaseType(interfaceTypeName));
    }

    public static ClassDeclarationSyntax CreateWithInheritClassAndInterface(string classTypeName, string inheritClassTypeName, string interfaceTypeName)
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

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword())
            .WithBaseList(SyntaxBaseListFactory.CreateTwoSimpleBaseTypes(inheritClassTypeName, interfaceTypeName));
    }

    public static ClassDeclarationSyntax CreateAsPublicPartial(string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword(), SyntaxTokenFactory.PartialKeyword());
    }

    public static ClassDeclarationSyntax CreateAsPublicStatic(string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword(), SyntaxTokenFactory.StaticKeyword());
    }

    public static ClassDeclarationSyntax CreateAsInternalStatic(string classTypeName)
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return SyntaxFactory.ClassDeclaration(classTypeName)
            .AddModifiers(SyntaxTokenFactory.InternalKeyword(), SyntaxTokenFactory.StaticKeyword());
    }

    public static ClassDeclarationSyntax CreateWithSuppressMessageAttribute(string classTypeName, SuppressMessageAttribute suppressMessage)
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

    public static ClassDeclarationSyntax CreateWithSuppressMessageAttributeByCodeAnalysisCheckId(string classTypeName, int checkId, string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return Create(classTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateCodeAnalysisSuppression(checkId, justification));
    }

    public static ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByCodeAnalysisCheckId(string classTypeName, string inheritClassTypeName, int checkId, string justification = "")
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

    public static ClassDeclarationSyntax CreateWithSuppressMessageAttributeByStyleCopCheckId(string classTypeName, int checkId, string justification = "")
    {
        if (classTypeName is null)
        {
            throw new ArgumentNullException(nameof(classTypeName));
        }

        return Create(classTypeName)
            .AddSuppressMessageAttribute(SuppressMessageAttributeFactory.CreateStyleCopSuppression(checkId, justification));
    }

    public static ClassDeclarationSyntax CreateWithInheritClassTypeAndSuppressMessageAttributeByStyleCopCheckId(string classTypeName, string inheritClassTypeName, int checkId, string justification = "")
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