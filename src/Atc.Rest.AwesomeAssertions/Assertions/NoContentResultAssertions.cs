// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.AwesomeAssertions;

/// <summary>
/// Provides AwesomeAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 204 (No Content).
/// </summary>
public class NoContentResultAssertions : ContentResultAssertionsBase<NoContentResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoContentResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    /// <param name="assertionChain">The assertion chain used to track and report the assertion state.</param>
    public NoContentResultAssertions(
        ContentResult subject,
        AssertionChain assertionChain)
        : base(subject, assertionChain)
    {
    }

    /// <inheritdoc />
    protected override string Identifier { get; } = "no content result";

    /// <inheritdoc />
    protected override AndWhichConstraint<NoContentResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}