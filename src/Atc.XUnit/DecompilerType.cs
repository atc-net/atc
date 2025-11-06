namespace Atc.XUnit;

/// <summary>
/// Specifies the decompiler strategy to use for analyzing test method bodies.
/// </summary>
public enum DecompilerType
{
    /// <summary>
    /// Uses ICSharpCode.Decompiler to build an Abstract Syntax Tree (AST) for analyzing method calls.
    /// Provides more detailed analysis but may be slower.
    /// </summary>
    AbstractSyntaxTree,

    /// <summary>
    /// Uses Mono.Reflection to analyze IL instructions directly.
    /// Faster but provides less detailed analysis than AST-based approach.
    /// </summary>
    MonoReflection,
}