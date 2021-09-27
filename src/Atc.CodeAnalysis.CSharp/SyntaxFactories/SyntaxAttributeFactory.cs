using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    /// <summary>
    /// Syntax Attribute Factory.
    /// </summary>
    /// <remarks>
    /// List of ValidationAttribute's:
    /// https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/ValidationAttribute.cs.
    /// </remarks>
    public static class SyntaxAttributeFactory
    {
        public static AttributeSyntax Create(string attributeName)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)));
        }

        public static AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, string argumentValue)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            if (argumentValue is null)
            {
                throw new ArgumentNullException(nameof(argumentValue));
            }

            return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
                .WithArgumentList(
                    SyntaxFactory.AttributeArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxAttributeArgumentFactory.Create(argumentValue))));
        }

        public static AttributeSyntax CreateWithOneItemWithOneArgument(string attributeName, int argumentValue)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
                .WithArgumentList(
                    SyntaxFactory.AttributeArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxAttributeArgumentFactory.Create(argumentValue))));
        }

        public static AttributeSyntax CreateWithOneItemWithTwoArgument(string attributeName, object argumentValue1, object argumentValue2)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return SyntaxFactory.Attribute(SyntaxFactory.IdentifierName(RemoveSuffix(attributeName)))
                .WithArgumentList(
                    SyntaxFactory.AttributeArgumentList(
                        SyntaxFactory.SeparatedList<AttributeArgumentSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                SyntaxAttributeArgumentFactory.Create(argumentValue1),
                                SyntaxTokenFactory.Comma(),
                                SyntaxAttributeArgumentFactory.Create(argumentValue2),
                            })));
        }

        public static AttributeSyntax CreateFromValidationAttribute(ValidationAttribute validationAttribute)
        {
            if (validationAttribute is null)
            {
                throw new ArgumentNullException(nameof(validationAttribute));
            }

            var attributeSyntax = validationAttribute switch
            {
                EmailAddressAttribute _ => Create(nameof(EmailAddressAttribute)),
                MinLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(MinLengthAttribute), attribute.Length),
                MaxLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(MaxLengthAttribute), attribute.Length),
                RangeAttribute attribute => CreateWithOneItemWithTwoArgument(nameof(RangeAttribute), attribute.Minimum, attribute.Maximum),
                RegularExpressionAttribute attribute => CreateWithOneItemWithOneArgument(nameof(RegularExpressionAttribute), attribute.Pattern),
                RequiredAttribute _ => Create(nameof(RequiredAttribute)),
                StringLengthAttribute attribute => CreateWithOneItemWithOneArgument(nameof(StringLengthAttribute), attribute.MaximumLength),
                UriAttribute _ => Create(nameof(UriAttribute)),
                UrlAttribute _ => Create(nameof(UrlAttribute)),
                _ => throw new NotImplementedException($"{nameof(ValidationAttribute)} {validationAttribute.GetType()} must be implemented.")
            };

            return attributeSyntax;
        }

        public static string RemoveSuffix(string attributeName)
        {
            if (attributeName is null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return attributeName.Replace("Attribute", string.Empty, StringComparison.Ordinal);
        }
    }
}