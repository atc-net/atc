// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.AwesomeAssertions;

/// <summary>
/// Provides AwesomeAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 404 (Not Found).
/// </summary>
public class NotFoundResultAssertions : ErrorContentResultAssertions<NotFoundResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    /// <param name="assertionChain">The assertion chain used to track and report the assertion state.</param>
    public NotFoundResultAssertions(
        ContentResult subject,
        AssertionChain assertionChain)
        : base(subject, assertionChain)
    {
    }

    /// <inheritdoc />
    protected override string Identifier => "not found result";

    /// <inheritdoc />
    protected override AndWhichConstraint<NotFoundResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}