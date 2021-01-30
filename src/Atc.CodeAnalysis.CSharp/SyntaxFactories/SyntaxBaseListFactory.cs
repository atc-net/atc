using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Atc.CodeAnalysis.CSharp.SyntaxFactories
{
    public static class SyntaxBaseListFactory
    {
        public static BaseListSyntax CreateOneSimpleBaseType(string typeName)
        {
            return SyntaxFactory.BaseList(
                SyntaxFactory.SingletonSeparatedList<BaseTypeSyntax>(
                    SyntaxSimpleBaseTypeFactory.Create(typeName)));
        }

        public static BaseListSyntax CreateTwoSimpleBaseTypes(string typeName1, string typeName2)
        {
            return SyntaxFactory.BaseList(
                SyntaxFactory.SeparatedList<BaseTypeSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxSimpleBaseTypeFactory.Create(typeName1),
                        SyntaxTokenFactory.Comma(),
                        SyntaxSimpleBaseTypeFactory.Create(typeName2),
                    }));
        }
    }
}