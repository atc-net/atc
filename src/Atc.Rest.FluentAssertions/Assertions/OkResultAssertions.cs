// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Provides FluentAssertions-style assertions for <see cref="OkObjectResult"/> objects with HTTP status code 200 (OK).
/// </summary>
public class OkResultAssertions : ReferenceTypeAssertions<OkObjectResult, OkResultAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OkResultAssertions"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="OkObjectResult"/> to assert against.</param>
    public OkResultAssertions(OkObjectResult subject)
        : base(subject)
    {
    }

    /// <inheritdoc />
    protected override string Identifier => "OK result";

    /// <summary>
    /// Asserts that the OK result contains content of the specified type.
    /// </summary>
    /// <typeparam name="T">The expected type of the content.</typeparam>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AndWhichConstraint{ObjectAssertions, T}"/> for further assertions on the typed content.</returns>
    public AndWhichConstraint<ObjectAssertions, T> WithContentOfType<T>(
        string because = "",
        params object[] becauseArgs)
    {
        using (var scope = new AssertionScope($"content type of {Identifier}"))
        {
            return Subject.Value.Should().BeAssignableTo<T>(because, becauseArgs);
        }
    }

    /// <summary>
    /// Asserts that the OK result contains content equivalent to the specified expected content.
    /// </summary>
    /// <typeparam name="T">The type of the expected content.</typeparam>
    /// <param name="expectedContent">The expected content value to compare against.</param>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AndWhichConstraint{OkResultAssertions, OkObjectResult}"/> for further assertions.</returns>
    public AndWhichConstraint<OkResultAssertions, OkObjectResult> WithContent<T>(
        T expectedContent,
        string because = "",
        params object[] becauseArgs)
    {
        using (var scope = new AssertionScope($"content of {Identifier}"))
        {
            WithContentOfType<T>(because, becauseArgs)
                .And.BeAssignableTo<T>(because, becauseArgs)
                .And.BeEquivalentTo(expectedContent, because, becauseArgs);

            var error = scope
                .Discard()
                .FirstOrDefault();

            if (error is null)
            {
                return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, Subject);
            }

            var fixedErrorMessage = error
                .Replace("Subject.Value", $"content of {Identifier}", StringComparison.InvariantCulture)
                .Replace("Expected root", $"Expected content of {Identifier}", StringComparison.InvariantCulture);
            Execute.Assertion.FailWith(fixedErrorMessage);
        }

        return new AndWhichConstraint<OkResultAssertions, OkObjectResult>(this, Subject);
    }
}