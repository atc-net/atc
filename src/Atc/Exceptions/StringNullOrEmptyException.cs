// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an value is null or empty.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class StringNullOrEmptyException : Exception
{
    private const string ExceptionMessage = "Value cannot be null or empty.";

    /// <summary>
    /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
    /// </summary>
    public StringNullOrEmptyException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public StringNullOrEmptyException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringNullOrEmptyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public StringNullOrEmptyException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected StringNullOrEmptyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}