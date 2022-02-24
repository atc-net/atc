// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an value is null.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class NullException : Exception
{
    private const string ExceptionMessage = "Value cannot be null.";

    /// <summary>
    /// Initializes a new instance of the <see cref="NullException"/> class.
    /// </summary>
    public NullException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NullException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public NullException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NullException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public NullException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected NullException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}