// ReSharper disable ReturnTypeCanBeEnumerable.Global
// ReSharper disable once CheckNamespace
namespace Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Extension methods for <see cref="SyntaxNode"/>.
/// </summary>
public static class SyntaxNodeExtensions
{
    /// <summary>
    /// Selects all descendant nodes of type <typeparamref name="T"/> from the syntax node.
    /// </summary>
    /// <typeparam name="T">The type of syntax nodes to select.</typeparam>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An enumerable collection of syntax nodes of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static IEnumerable<T> Select<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .DescendantNodes()
            .OfType<T>();
    }

    /// <summary>
    /// Selects all descendant nodes of type <typeparamref name="T"/> from the syntax node and returns them as an array.
    /// </summary>
    /// <typeparam name="T">The type of syntax nodes to select.</typeparam>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of syntax nodes of type <typeparamref name="T"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static T[] SelectToArray<T>(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<T>()
            .ToArray();
    }

    /// <summary>
    /// Gets all using directive statements from the syntax node.
    /// </summary>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of using directive strings.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static string[] GetUsedUsingStatements(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<UsingDirectiveSyntax>()
            .Where(x => x.Name is not null)
            .Select(x => x.Name!.ToString())
            .ToArray();
    }

    /// <summary>
    /// Gets all using directive statements from the syntax node, excluding those with aliases.
    /// </summary>
    /// <param name="syntaxNode">The syntax node to search.</param>
    /// <returns>An array of using directive strings without aliases.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static string[] GetUsedUsingStatementsWithoutAlias(
        this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode
            .Select<UsingDirectiveSyntax>()
            .Where(x => x.Alias is null && x.Name is not null)
            .Select(x => x.Name!.ToString())
            .ToArray();
    }

    /// <summary>
    /// Determines whether the node is a <see langword="partial"/> class declaration with at least one attribute.
    /// This is a fast, syntax-only check meant for the <c>predicate</c> of
    /// <see cref="SyntaxValueProvider.CreateSyntaxProvider{T}"/> in an incremental source generator.
    /// </summary>
    /// <param name="syntaxNode">The syntax node to check.</param>
    /// <returns><see langword="true"/> when the node is a partial class with attributes; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> is null.</exception>
    public static bool IsPartialClassWithAttribute(this SyntaxNode syntaxNode)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        return syntaxNode is ClassDeclarationSyntax classDeclaration &&
               classDeclaration.Modifiers.Any(SyntaxKind.PartialKeyword) &&
               classDeclaration.AttributeLists.Count > 0;
    }

    /// <summary>
    /// Determines whether the node is a <see langword="partial"/> class declaration with a given attribute.
    /// This is a fast, syntax-only check meant for the <c>predicate</c> of
    /// <see cref="SyntaxValueProvider.CreateSyntaxProvider{T}"/> in an incremental source generator.
    /// </summary>
    /// <remarks>
    /// The attribute is matched by name as written in the source, case-sensitively: <c>Foo</c>, <c>FooAttribute</c>,
    /// a qualified name such as <c>My.Namespace.Foo</c>, and <c>global::</c> aliases all match <c>Foo</c>.
    /// Because the check does not use the semantic model, an attribute with the same name from another namespace
    /// also matches; confirm the attribute type in the transform step.
    /// </remarks>
    /// <param name="syntaxNode">The syntax node to check.</param>
    /// <param name="attributeName">The attribute name, with or without the <c>Attribute</c> suffix, for example <c>Generate</c> or <c>GenerateAttribute</c>.</param>
    /// <returns><see langword="true"/> when the node is a partial class with the attribute; otherwise <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="syntaxNode"/> or <paramref name="attributeName"/> is null.</exception>
    public static bool IsPartialClassWithAttribute(
        this SyntaxNode syntaxNode,
        string attributeName)
    {
        if (syntaxNode is null)
        {
            throw new ArgumentNullException(nameof(syntaxNode));
        }

        if (attributeName is null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        if (!syntaxNode.IsPartialClassWithAttribute())
        {
            return false;
        }

        var shortName = TrimAttributeSuffix(attributeName);
        return ((ClassDeclarationSyntax)syntaxNode).AttributeLists
            .SelectMany(x => x.Attributes)
            .Any(x => string.Equals(TrimAttributeSuffix(GetRightmostName(x.Name)), shortName, StringComparison.Ordinal));
    }

    private static string GetRightmostName(NameSyntax name)
        => name switch
        {
            QualifiedNameSyntax qualifiedName => qualifiedName.Right.Identifier.ValueText,
            AliasQualifiedNameSyntax aliasQualifiedName => aliasQualifiedName.Name.Identifier.ValueText,
            SimpleNameSyntax simpleName => simpleName.Identifier.ValueText,
            _ => name.ToString(),
        };

    private static string TrimAttributeSuffix(string name)
    {
        const string suffix = "Attribute";
        return name.Length > suffix.Length && name.EndsWith(suffix, StringComparison.Ordinal)
            ? name.Substring(0, name.Length - suffix.Length)
            : name;
    }
}