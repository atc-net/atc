using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions
{
    public class AcceptedResultAssertions : ContentResultAssertions<AcceptedResultAssertions>
    {
        public AcceptedResultAssertions(ContentResult subject) : base(subject) { }

        protected override string Identifier { get; } = "accepted result";

        protected override AndWhichConstraint<AcceptedResultAssertions, ContentResult> CreateAndWhichConstraint()
            => new AndWhichConstraint<AcceptedResultAssertions, ContentResult>(this, Subject);
    }
}