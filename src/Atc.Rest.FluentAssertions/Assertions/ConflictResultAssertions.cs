// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 409 (Conflict).
/// </summary>
public class ConflictResultAssertions : ErrorContentResultAssertions<ConflictResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    public ConflictResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier => "conflict result";

    /// <inheritdoc />
    protected override AndWhichConstraint<ConflictResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}