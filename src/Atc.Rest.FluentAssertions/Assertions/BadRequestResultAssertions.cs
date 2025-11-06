// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 400 (Bad Request).
/// </summary>
public class BadRequestResultAssertions : ErrorContentResultAssertions<BadRequestResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    public BadRequestResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier { get; } = "bad request result";

    /// <inheritdoc />
    protected override AndWhichConstraint<BadRequestResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}