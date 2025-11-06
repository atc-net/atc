// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

/// <summary>
/// Base class for error result assertions that provides functionality for verifying error messages in <see cref="ContentResult"/> objects.
/// </summary>
/// <typeparam name="TAssertions">The type of the derived assertion class for fluent chaining.</typeparam>
public abstract class ErrorContentResultAssertions<TAssertions> : ContentResultAssertionsBase<TAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorContentResultAssertions{TAssertions}"/> class.
    /// </summary>
    /// <param name="subject">The <see cref="ContentResult"/> to assert against.</param>
    protected ErrorContentResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    /// <summary>
    /// Asserts that the error result contains the specified error message.
    /// The error message is extracted from either a <see cref="ProblemDetails"/> object's Detail property or a string content.
    /// </summary>
    /// <param name="expectedErrorMessage">The expected error message.</param>
    /// <param name="because">Optional explanation of why the assertion is needed.</param>
    /// <param name="becauseArgs">Optional formatting arguments for the <paramref name="because"/> parameter.</param>
    /// <returns>An <see cref="AndWhichConstraint{TAssertions, ContentResult}"/> for further assertions.</returns>
    public AndWhichConstraint<TAssertions, ContentResult> WithErrorMessage(string expectedErrorMessage, string because = "", params object[] becauseArgs)
    {
        var actualErrorMessage = string.Empty;

        if (TryContentValueAs<ProblemDetails>(out var pd))
        {
            actualErrorMessage = pd.Detail;
        }
        else if (TryContentValueAs<string>(out var details))
        {
            actualErrorMessage = details;
        }

        Execute.Assertion
            .ForCondition(actualErrorMessage is not null && actualErrorMessage.Equals(expectedErrorMessage, StringComparison.Ordinal))
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier($"error message of {Identifier}")
            .FailWith("Expected {context} to be {0}{reason}, but found {1}.", expectedErrorMessage, actualErrorMessage);

        return CreateAndWhichConstraint();
    }
}