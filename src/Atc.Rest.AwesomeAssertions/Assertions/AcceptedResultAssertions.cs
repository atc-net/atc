// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.AwesomeAssertions;

/// <summary>
/// Provides AwesomeAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 202 (Accepted).
/// </summary>
public class AcceptedResultAssertions : ContentResultAssertionsBase<AcceptedResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcceptedResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    /// <param name="assertionChain">The assertion chain used to track and report the assertion state.</param>
    public AcceptedResultAssertions(
        ContentResult subject,
        AssertionChain assertionChain)
        : base(subject, assertionChain)
    {
    }

    /// <inheritdoc />
    protected override string Identifier { get; } = "accepted result";

    /// <inheritdoc />
    protected override AndWhichConstraint<AcceptedResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}