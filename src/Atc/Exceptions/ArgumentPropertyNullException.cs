// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// ArgumentPropertyNullException.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public sealed class ArgumentPropertyNullException : ArgumentException
{
    private const string ExceptionMessage = "Value cannot be null.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class.
    /// </summary>
    public ArgumentPropertyNullException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    public ArgumentPropertyNullException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    /// <param name="message">The message.</param>
    public ArgumentPropertyNullException(
        string paramName,
        string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentPropertyNullException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    private ArgumentPropertyNullException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}