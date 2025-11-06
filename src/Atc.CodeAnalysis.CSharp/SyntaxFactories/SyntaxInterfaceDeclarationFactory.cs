namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// Factory for creating <see cref="InterfaceDeclarationSyntax"/> nodes.
/// </summary>
public static class SyntaxInterfaceDeclarationFactory
{
    /// <summary>
    /// Creates a public interface declaration.
    /// </summary>
    /// <param name="interfaceTypeName">The name of the interface.</param>
    /// <returns>An <see cref="InterfaceDeclarationSyntax"/> with public modifier.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="interfaceTypeName"/> is null.</exception>
    public static InterfaceDeclarationSyntax Create(string interfaceTypeName)
    {
        if (interfaceTypeName is null)
        {
            throw new ArgumentNullException(nameof(interfaceTypeName));
        }

        return SyntaxFactory.InterfaceDeclaration(interfaceTypeName)
            .AddModifiers(SyntaxTokenFactory.PublicKeyword());
    }
}