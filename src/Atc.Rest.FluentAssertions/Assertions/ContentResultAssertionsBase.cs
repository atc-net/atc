// ReSharper disable InvertIf
// ReSharper disable ConstantConditionalAccessQualifier
// ReSharper disable once CheckNamespace
// ReSharper disable StaticMemberInGenericType
namespace Atc.Rest.FluentAssertions;

public abstract class ContentResultAssertionsBase<TAssertions> : ReferenceTypeAssertions<ContentResult, ContentResultAssertionsBase<TAssertions>>
{
    [SuppressMessage("Major Code Smell", "S2743:Static fields should not be used in generic types", Justification = "This can safely be shared by all inherited types")]
    private static readonly JsonSerializerOptions JsonSerializerOptions = JsonSerializerOptionsFactory.Create();

    protected ContentResultAssertionsBase(ContentResult subject)
        : base(subject)
    {
    }

    public AndWhichConstraint<TAssertions, ContentResult> WithContent<T>(T expectedContent, string because = "", params object[] becauseArgs)
    {
        var ofType = WithContentOfType<T>(because, becauseArgs);

        using (var scope = new AssertionScope($"content of {Identifier}"))
        {
            ofType.And.BeEquivalentTo(expectedContent, because, becauseArgs);

            var error = scope.Discard().FirstOrDefault();
            if (error is not null)
            {
                var fixedErrorMessage = error.Replace("Expected root", $"Expected content of {Identifier}", StringComparison.InvariantCulture);
                Execute.Assertion.FailWith(fixedErrorMessage);
            }
        }

        return CreateAndWhichConstraint();
    }

    public AndWhichConstraint<ObjectAssertions, T> WithContentOfType<T>(string because = "", params object[] becauseArgs)
    {
        var expectedType = typeof(T);

        Execute.Assertion
            .ForCondition(Subject.Content is not null)
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier($"type of content in {Identifier}")
            .FailWith("Expected {context} to be {0}{reason}, but found <null>.", expectedType);

        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier($"content type of {Identifier}")
            .Given(() => Subject.ContentType)
            .ForCondition(contentType => contentType is not null && contentType.Equals(MediaTypeNames.Application.Json, StringComparison.Ordinal))
            .FailWith("Expected {context} to be {0}{reason}, but found {1}.", _ => MediaTypeNames.Application.Json, x => x);

        var parseSuccess = TryContentValueAs<T>(out var result);

        Execute.Assertion
            .ForCondition(parseSuccess)
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier($"type of content in {Identifier}")
            .FailWith("Expected {context} to be {0}{reason}, but found {1}.", expectedType, Subject.Content);

        // Its safe to ! BANG the result variable as the previous Execute.Assertion will throw if
        // result is null and the parsing failed.
        return new AndWhichConstraint<ObjectAssertions, T>(new ObjectAssertions(result), result!);
    }

    protected abstract AndWhichConstraint<TAssertions, ContentResult> CreateAndWhichConstraint();

    protected bool TryContentValueAs<T>([NotNullWhen(true)] out T content)
    {
        content = default!;

        if (TryContentValueAs(typeof(T), out var result) && result is T castResult)
        {
            content = castResult;
            return true;
        }

        return false;
    }

    private bool TryContentValueAs(Type type, out object content)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (Subject.Content is null)
        {
            content = default!;
            return false;
        }

        return type.IsPrimitive
            ? TryGetPrimitiveContent(type, out content)
            : TryGetObjectContent(type, out content);
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "On purpose")]
    private bool TryGetObjectContent(Type type, out object content)
    {
        content = default!;
        try
        {
            content = JsonSerializer.Deserialize(Subject.Content!, type, JsonSerializerOptions)!;
            return true;
        }
        catch
        {
            return false;
        }
    }

    [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "On purpose")]
    private bool TryGetPrimitiveContent(Type type, out object content)
    {
        content = default!;

        try
        {
            var contentAsString = JsonSerializer.Deserialize<string>(Subject.Content!, JsonSerializerOptions);
            content = Convert.ChangeType(contentAsString, type, CultureInfo.InvariantCulture)!;
            return true;
        }
        catch
        {
            return false;
        }
    }
}