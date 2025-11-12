// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="EnumDeclarationSyntax"/>.
/// </summary>
public static class EnumDeclarationSyntaxExtensions
{
    /// <summary>
    /// Adds a <see cref="SuppressMessageAttribute"/> to the enum declaration.
    /// </summary>
    /// <param name="enumDeclaration">The enum declaration to modify.</param>
    /// <param name="suppressMessage">The suppress message attribute to add.</param>
    /// <returns>A new <see cref="EnumDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumDeclaration"/> or <paramref name="suppressMessage"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the justification in <paramref name="suppressMessage"/> is invalid.</exception>
    public static EnumDeclarationSyntax AddSuppressMessageAttribute(
        this EnumDeclarationSyntax enumDeclaration,
        SuppressMessageAttribute suppressMessage)
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
            throw new ArgumentException("Justification is invalid.", nameof(suppressMessage));
        }

        var attributeArgumentList = SyntaxFactory.AttributeArgumentList(
            SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                SyntaxFactory.NodeOrTokenList(
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Category)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory.AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.CheckId)),
                    SyntaxTokenFactory.Comma(),
                    SyntaxFactory
                        .AttributeArgument(SyntaxLiteralExpressionFactory.Create(suppressMessage.Justification!))
                        .WithNameEquals(
                            SyntaxNameEqualsFactory
                                .Create(nameof(SuppressMessageAttribute.Justification))
                                .WithEqualsToken(SyntaxTokenFactory.Equals())))));

        return enumDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(SuppressMessageAttribute), attributeArgumentList));
    }

    /// <summary>
    /// Adds a <see cref="FlagsAttribute"/> to the enum declaration.
    /// </summary>
    /// <param name="enumDeclaration">The enum declaration to modify.</param>
    /// <returns>A new <see cref="EnumDeclarationSyntax"/> with the attribute added.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumDeclaration"/> is null.</exception>
    public static EnumDeclarationSyntax AddFlagAttribute(
        this EnumDeclarationSyntax enumDeclaration)
    {
        if (enumDeclaration is null)
        {
            throw new ArgumentNullException(nameof(enumDeclaration));
        }

        return enumDeclaration
            .AddAttributeLists(SyntaxAttributeListFactory.Create(nameof(FlagsAttribute)));
    }

    /// <summary>
    /// Determines whether the enum declaration has an attribute of the specified type.
    /// </summary>
    /// <param name="enumDeclaration">The enum declaration to check.</param>
    /// <param name="attributeType">The type of attribute to search for.</param>
    /// <returns><c>true</c> if the enum has an attribute of the specified type; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="attributeType"/> is null.</exception>
    public static bool HasAttributeOfAttributeType(
        this EnumDeclarationSyntax enumDeclaration,
        Type attributeType)
    {
        if (attributeType is null)
        {
            throw new ArgumentNullException(nameof(attributeType));
        }

        var attributeName = attributeType.Name.Replace("Attribute", string.Empty, StringComparison.Ordinal);
        return enumDeclaration
            .Select<AttributeSyntax>()
            .Any(x => attributeName.Equals(x.Name.ToString(), StringComparison.Ordinal));
    }
}