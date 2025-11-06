// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="ContentResult"/> objects.
/// </summary>
public class ContentResultAssertions : ContentResultAssertionsBase<ContentResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContentResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    public ContentResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier { get; } = "content result";

    /// <summary>
    /// Asserts that the content result has the specified HTTP status code.
    /// </summary>
    /// <param name="expectedStatusCode">The expected HTTP status code.</param>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AndConstraint{ContentResultAssertions}"/> for further assertions.</returns>
    public AndConstraint<ContentResultAssertions> WithStatusCode(
        HttpStatusCode expectedStatusCode,
        string because = "",
        params object[] becauseArgs)
        => WithStatusCode((int)expectedStatusCode, because, becauseArgs);

    /// <summary>
    /// Asserts that the content result has the specified HTTP status code.
    /// </summary>
    /// <param name="expectedStatusCode">The expected HTTP status code as an integer.</param>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AndConstraint{ContentResultAssertions}"/> for further assertions.</returns>
    public AndConstraint<ContentResultAssertions> WithStatusCode(
        int expectedStatusCode,
        string because = "",
        params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .Given(() => Subject.StatusCode)
            .ForCondition(x => x == expectedStatusCode)
            .FailWith("Expected status code to be {0}{reason}, but found {1}.", expectedStatusCode, Subject.StatusCode);

        return new AndConstraint<ContentResultAssertions>(this);
    }

    /// <inheritdoc />
    protected override AndWhichConstraint<ContentResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}