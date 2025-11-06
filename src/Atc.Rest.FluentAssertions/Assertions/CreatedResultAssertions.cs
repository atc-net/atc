// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="ContentResult"/> objects with HTTP status code 201 (Created).
/// </summary>
public class CreatedResultAssertions : ContentResultAssertionsBase<CreatedResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreatedResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    public CreatedResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier { get; } = "created result";

    /// <inheritdoc />
    protected override AndWhichConstraint<CreatedResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}