// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.AwesomeAssertions;

/// <summary>
/// Provides AwesomeAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 403 (Forbidden).
/// </summary>
public class ForbiddenResultAssertions : ErrorContentResultAssertions<ForbiddenResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    /// <param name="assertionChain">The assertion chain used to track and report the assertion state.</param>
    public ForbiddenResultAssertions(
        ContentResult subject,
        AssertionChain assertionChain)
        : base(subject, assertionChain)
    {
    }

    /// <inheritdoc />
    protected override string Identifier => "forbidden result";

    /// <inheritdoc />
    protected override AndWhichConstraint<ForbiddenResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}