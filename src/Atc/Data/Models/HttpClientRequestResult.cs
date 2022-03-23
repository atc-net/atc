namespace Atc.Data.Models;

/// <summary>
/// HttpClientRequestResult.
/// </summary>
/// <typeparam name="TData">The type of the expected data to retrieve.</typeparam>
[Serializable]
public sealed class HttpClientRequestResult<TData>
{
    public HttpClientRequestResult()
    {
        // Dummy for serialization
    }

    public HttpClientRequestResult(
        HttpStatusCode? statusCode)
    {
        HasCommunicationSucceeded = true;
        StatusCode = statusCode;
    }

    public HttpClientRequestResult(
        TData data)
    {
        HasCommunicationSucceeded = true;
        StatusCode = HttpStatusCode.OK;
        Data = data;
    }

    public HttpClientRequestResult(
        HttpStatusCode? statusCode,
        TData data)
    {
        HasCommunicationSucceeded = true;
        StatusCode = statusCode;
        Data = data;
    }

    public HttpClientRequestResult(
        HttpStatusCode? statusCode,
        TData data,
        string message)
    {
        HasCommunicationSucceeded = true;
        StatusCode = statusCode;
        Data = data;
        Message = message;
    }

    public HttpClientRequestResult(
        Exception exception)
    {
        HasCommunicationSucceeded = false;
        Exception = exception;
    }

    public bool HasCommunicationSucceeded { get; set; }

    public HttpStatusCode? StatusCode { get; set; }

    public TData? Data { get; set; }

    public string? Message { get; set; }

    public Exception? Exception { get; set; }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(HasCommunicationSucceeded)}: {HasCommunicationSucceeded}, {nameof(StatusCode)}: {StatusCode}, {nameof(Data)}: {Data}, {nameof(Message)}: {Message}, {nameof(Exception)}: {Exception}";
}