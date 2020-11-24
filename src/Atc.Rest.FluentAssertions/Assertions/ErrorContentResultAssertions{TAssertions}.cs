using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{

    public abstract class ErrorContentResultAssertions<TAssertions> : ContentResultAssertions<TAssertions>
    {
        protected ErrorContentResultAssertions(ContentResult subject) : base(subject) { }

        public AndWhichConstraint<TAssertions, ContentResult> WithErrorMessage(string expectedErrorMessage, string because = "", params object[] becauseArgs)
        {
            using (new AssertionScope($"error message of \"{Identifier}\""))
            {
                var problemDetail = GetContentValueAs<ProblemDetails>()?.Detail ?? GetContentValueAs<string>();
                problemDetail.Should().Be(expectedErrorMessage, because, becauseArgs);
            }

            return CreateAndWhichConstraint();
        }
    }
}