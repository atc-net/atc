using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class NotFoundResultAssertions : ErrorContentResultAssertions<NotFoundResultAssertions>
    {
        public NotFoundResultAssertions(ContentResult subject) : base(subject) { }

        protected override string Identifier => "not found result";

        protected override AndWhichConstraint<NotFoundResultAssertions, ContentResult> CreateAndWhichConstraint()
            => new AndWhichConstraint<NotFoundResultAssertions, ContentResult>(this, Subject);
    }
}