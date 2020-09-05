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
                if (astNode.Parent == null)
                {
                    return astNode;
                }

                astNode = astNode.Parent;
            }
        }

        internal static bool IsType(this AstNode astNode, Type type)
        {
            if (astNode == null)
            {
                throw new ArgumentNullException(nameof(astNode));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return astNode.GetType() == type;
        }

        internal static AstNode? GetFirstOrDefaultByExpressionType(this AstNode astNode, Type expressionType)
        {
            if (astNode == null)
            {
                throw new ArgumentNullException(nameof(astNode));
            }

            if (expressionType == null)
            {
                throw new ArgumentNullException(nameof(expressionType));
            }

            if (expressionType.BaseType == null)
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