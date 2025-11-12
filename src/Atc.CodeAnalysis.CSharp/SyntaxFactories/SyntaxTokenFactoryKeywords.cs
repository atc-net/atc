namespace Atc.CodeAnalysis.CSharp.SyntaxFactories;

/// <summary>
/// SyntaxTokenFactory - for keyword methods.
/// </summary>
[SuppressMessage("Design", "MA0048:File name must match type name", Justification = "OK. Partial class.")]
public static partial class SyntaxTokenFactory
{
    public static SyntaxToken AbstractKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.AbstractKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken PublicKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.PublicKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken PrivateKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.PrivateKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken PartialKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.PartialKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken OverrideKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.OverrideKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken InternalKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.InternalKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken ProtectedKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.ProtectedKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken StaticKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.StaticKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken AsyncKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.AsyncKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken ReadOnlyKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.ReadOnlyKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken NewKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.NewKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken DefaultKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.DefaultKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken ImplicitKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.ImplicitKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken OperatorKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.OperatorKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken StringKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.StringKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken IntKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.IntKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken DoubleKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.DoubleKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken VoidKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.VoidKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken ObjectKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.ObjectKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);

    public static SyntaxToken ByteKeyword(bool withTrailingSpace = true)
        => TokenWithTrailing(SyntaxKind.ByteKeyword, withTrailingSpace ? SyntaxFactory.Space : SyntaxFactory.ElasticMarker);
}