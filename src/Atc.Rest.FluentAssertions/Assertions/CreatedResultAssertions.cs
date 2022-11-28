// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
namespace Atc.Rest.FluentAssertions;

public class CreatedResultAssertions : ContentResultAssertionsBase<CreatedResultAssertions>
{
    public CreatedResultAssertions(ContentResult subject)
        : base(subject)
    {
    }

    protected override string Identifier { get; } = "created result";

    protected override AndWhichConstraint<CreatedResultAssertions, ContentResult> CreateAndWhichConstraint()
        => new(this, Subject);
}