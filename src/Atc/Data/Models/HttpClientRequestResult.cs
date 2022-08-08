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
        CommunicationSucceeded = true;
        StatusCode = statusCode;
    }

    public HttpClientRequestResult(
        TData data)
    {
        CommunicationSucceeded = true;
        StatusCode = HttpStatusCode.OK;
        Data = data;
    }

    public HttpClientRequestResult(
        HttpStatusCode? statusCode,
        TData data)
    {
        CommunicationSucceeded = true;
        StatusCode = statusCode;
        Data = data;
    }

    public HttpClientRequestResult(
        HttpStatusCode? statusCode,
        TData data,
        string message)
    {
        CommunicationSucceeded = true;
        StatusCode = statusCode;
        Data = data;
        Message = message;
    }

    public HttpClientRequestResult(
        Exception exception)
    {
        CommunicationSucceeded = false;
        Exception = exception;
    }

    public bool CommunicationSucceeded { get; set; }

    public HttpStatusCode? StatusCode { get; set; }

    public TData? Data { get; set; }

    public string? Message { get; set; }

    public Exception? Exception { get; set; }

    public bool HasData
        => Data is not null;

    public bool HasMessage
        => !string.IsNullOrEmpty(Message);

    public bool HasException
        => Exception is not null;

    [SuppressMessage("Design", "CA1024:Use properties where appropriate", Justification = "OK.")]
    public string GetErrorMessageOrMessage()
    {
        if (HasException)
        {
            return Exception!.Message;
        }

        return HasMessage
            ? Message!
            : string.Empty;
    }

    /// <inheritdoc />
    public override string ToString()
        => $"{nameof(CommunicationSucceeded)}: {CommunicationSucceeded}, {nameof(StatusCode)}: {StatusCode}, {nameof(Data)}: {Data}, {nameof(Message)}: {Message}, {nameof(Exception)}: {Exception}";
}