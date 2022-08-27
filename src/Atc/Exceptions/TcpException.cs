// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a TCP error occurred.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class TcpException : Exception
{
    private const string ExceptionMessage = "TCP error.";

    /// <summary>
    /// Initializes a new instance of the <see cref="TcpException"/> class.
    /// </summary>
    public TcpException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TcpException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public TcpException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TcpException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public TcpException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected TcpException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}