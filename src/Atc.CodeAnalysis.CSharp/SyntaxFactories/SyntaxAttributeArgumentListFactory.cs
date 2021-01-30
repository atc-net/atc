using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxAttributeArgumentListFactory
    {
        public static AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, string attributeValue)
        {
            return SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue)));
        }

        public static AttributeArgumentListSyntax CreateWithOneItemWithNameEquals(string attributeName, int attributeValue)
        {
            return SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxAttributeArgumentFactory.CreateWithNameEquals(attributeName, attributeValue)));
        }
    }
}