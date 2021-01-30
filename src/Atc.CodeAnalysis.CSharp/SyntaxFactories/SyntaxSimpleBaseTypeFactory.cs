using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxSimpleBaseTypeFactory
    {
        public static SimpleBaseTypeSyntax Create(string typeName)
        {
            return SyntaxFactory.SimpleBaseType(
                SyntaxFactory.ParseTypeName(typeName));
        }
    }
}