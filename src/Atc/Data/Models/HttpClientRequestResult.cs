namespace Atc.Data.Models;

/// <summary>
/// Represents the result of an HTTP client request, including status, data, and error information.
/// </summary>
/// <typeparam name="TData">The type of the expected data to retrieve.</typeparam>
[Serializable]
public sealed class HttpClientRequestResult<TData>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class.
    /// Default constructor for serialization purposes.
    /// </summary>
    public HttpClientRequestResult()
    {
        // Dummy for serialization
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class with a status code.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    public HttpClientRequestResult(
        HttpStatusCode? statusCode)
    {
        CommunicationSucceeded = true;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class with data.
    /// </summary>
    /// <param name="data">The response data.</param>
    public HttpClientRequestResult(
        TData data)
    {
        CommunicationSucceeded = true;
        StatusCode = HttpStatusCode.OK;
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class with a status code and data.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="data">The response data.</param>
    public HttpClientRequestResult(
        HttpStatusCode? statusCode,
        TData data)
    {
        CommunicationSucceeded = true;
        StatusCode = statusCode;
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class with a status code, data, and message.
    /// </summary>
    /// <param name="statusCode">The HTTP status code.</param>
    /// <param name="data">The response data.</param>
    /// <param name="message">The result message.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientRequestResult{TData}"/> class with an exception.
    /// </summary>
    /// <param name="exception">The exception that occurred during the request.</param>
    public HttpClientRequestResult(
        Exception exception)
    {
        CommunicationSucceeded = false;
        Exception = exception;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the communication succeeded.
    /// </summary>
    public bool CommunicationSucceeded { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code.
    /// </summary>
    public HttpStatusCode? StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the response data.
    /// </summary>
    public TData? Data { get; set; }

    /// <summary>
    /// Gets or sets the result message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the exception that occurred during the request.
    /// </summary>
    public Exception? Exception { get; set; }

    /// <summary>
    /// Gets a value indicating whether the result contains data.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Data))]
    public bool HasData
        => Data is not null;

    /// <summary>
    /// Gets a value indicating whether the result contains a message.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Message))]
    public bool HasMessage
        => !string.IsNullOrEmpty(Message);

    /// <summary>
    /// Gets a value indicating whether the result contains an exception.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Exception))]
    public bool HasException
        => Exception is not null;

    /// <summary>
    /// Gets the error message from the exception, or the result message if no exception exists.
    /// </summary>
    /// <returns>The error message or result message, or an empty string if neither exists.</returns>
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