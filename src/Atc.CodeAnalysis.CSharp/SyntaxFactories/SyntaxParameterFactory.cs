namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

public static class SyntaxParameterFactory
{
    public static ParameterSyntax Create(string parameterTypeName, string parameterName, string? genericListTypeName = null)
    {
        if (parameterTypeName is null)
        {
            throw new ArgumentNullException(nameof(parameterTypeName));
        }

        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        if (genericListTypeName is not null)
        {
            return SyntaxFactory
                .Parameter(SyntaxFactory.Identifier(parameterName))
                .WithType(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(genericListTypeName))
                        .WithTypeArgumentList(
                            SyntaxFactory.TypeArgumentList(
                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                    SyntaxFactory.IdentifierName(parameterTypeName)))));
        }

        return SyntaxFactory
            .Parameter(SyntaxFactory.Identifier(parameterName))
            .WithType(SyntaxFactory.IdentifierName(parameterTypeName));
    }

    public static ParameterSyntax CreateWithAttribute(string attributeTypeName, string parameterTypeName, string parameterName)
    {
        if (attributeTypeName is null)
        {
            throw new ArgumentNullException(nameof(attributeTypeName));
        }

        if (parameterTypeName is null)
        {
            throw new ArgumentNullException(nameof(parameterTypeName));
        }

        if (parameterName is null)
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        return SyntaxFactory
            .Parameter(SyntaxFactory.Identifier(parameterName))
            .WithAttributeLists(
                SyntaxFactory.SingletonList(
                    SyntaxFactory.AttributeList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxAttributeFactory.Create(attributeTypeName)))))
            .WithType(SyntaxFactory.IdentifierName(parameterTypeName));
    }
}