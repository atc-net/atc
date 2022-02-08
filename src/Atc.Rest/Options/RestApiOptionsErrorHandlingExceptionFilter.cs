namespace Atc.Rest.Options;

public class RestApiOptionsErrorHandlingExceptionFilter
{
    public bool Enable { get; set; } = true;

    public bool UseProblemDetailsAsResponseBody { get; set; } = true;

    public bool IncludeExceptionDetails { get; set; } = true;
}