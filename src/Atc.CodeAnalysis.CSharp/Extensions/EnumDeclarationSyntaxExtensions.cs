// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

public static class EnumDeclarationSyntaxExtensions
{
    public static EnumDeclarationSyntax AddSuppressMessageAttribute(this EnumDeclarationSyntax enumDeclaration, SuppressMessageAttribute suppressMessage)
    {
        if (enumDeclaration is null)
        {
            throw new ArgumentNullException(nameof(enumDeclaration));
        }

        if (suppressMessage is null)
        {
            throw new ArgumentNullException(nameof(suppressMessage));
        }

        if (string.IsNullOrEmpty(suppressMessage.Justification))
        {
            throw new ArgumentPropertyNullException(nameof(suppressMessage), "Justification is invalid.");
        }

        var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(SyntaxFactory.NodeOrTokenList(
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Category)),
                SyntaxTokenFactory.Comma(),
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.CheckId)),
                SyntaxTokenFactory.Comma(),
                SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Justification!))
                    .WithNameEquals(
                        SyntaxNameEqualsFactory.Create(nameof(SuppressMessageAttribute.Justification))
                            .WithEqualsToken(SyntaxTokenFactory.Equals())))));

        return enumDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
    }

    public static EnumDeclarationSyntax AddFlagAttribute(this EnumDeclarationSyntax enumDeclaration)
    {
        if (enumDeclaration is null)
        {
            throw new ArgumentNullException(nameof(enumDeclaration));
        }

        return enumDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(FlagsAttribute)));
    }

    public static bool HasAttributeOfAttributeType(this EnumDeclarationSyntax enumDeclaration, Type attributeType)
    {
        if (attributeType is null)
        {
            throw new ArgumentNullException(nameof(attributeType));
        }

        var attributeName = attributeType.Name.Replace("Attribute", string.Empty, StringComparison.Ordinal);
        return enumDeclaration.Select<AttributeSyntax>().Any(x => attributeName.Equals(x.Name.ToString(), StringComparison.Ordinal));
    }
}