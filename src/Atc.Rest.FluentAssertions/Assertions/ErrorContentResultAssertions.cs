using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public abstract class ErrorContentResultAssertions<TAssertions> : ContentResultAssertionsBase<TAssertions>
    {
        protected ErrorContentResultAssertions(ContentResult subject)
            : base(subject)
        {
        }

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
                .ForCondition(actualErrorMessage.Equals(expectedErrorMessage, StringComparison.Ordinal))
                .BecauseOf(because, becauseArgs)
                .WithDefaultIdentifier($"error message of {Identifier}")
                .FailWith("Expected {context} to be {0}{reason}, but found {1}.", expectedErrorMessage, actualErrorMessage);

            return CreateAndWhichConstraint();
        }
    }
}