using System;
using System.Linq;
using ICSharpCode.Decompiler.CSharp.Syntax;

namespace Atc.XUnit.Internal.AbstractSyntaxTree
{
    internal static class AstNodeExtensions
    {
        internal static AstNode GetRoot(this AstNode astNode)
        {
            while (true)
            {
                if (astNode.Parent is null)
                {
                    return astNode;
                }

                astNode = astNode.Parent;
            }
        }

        internal static bool IsType(this AstNode astNode, Type type)
        {
            if (astNode is null)
            {
                throw new ArgumentNullException(nameof(astNode));
            }

            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return astNode.GetType() == type;
        }

        internal static AstNode? GetFirstOrDefaultByExpressionType(this AstNode astNode, Type expressionType)
        {
            if (astNode is null)
            {
                throw new ArgumentNullException(nameof(astNode));
            }

            if (expressionType is null)
            {
                throw new ArgumentNullException(nameof(expressionType));
            }

            if (expressionType.BaseType is null)
            {
                throw new UnexpectedTypeException(typeof(Nullable), typeof(Expression));
            }

            if (expressionType.BaseType != typeof(Expression))
            {
                throw new UnexpectedTypeException(expressionType.BaseType, typeof(Expression));
            }

            return astNode.HasChildren
                ? astNode.Children.FirstOrDefault(x => x.GetType() == expressionType)
                : null;
        }
    }
}