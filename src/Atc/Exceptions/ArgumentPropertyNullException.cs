// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a property argument is null.
/// </summary>
/// <remarks>
/// This exception is similar to <see cref="ArgumentNullException"/>, but is specifically designed for validating property values
/// rather than method parameters. It inherits from <see cref="ArgumentException"/> to maintain consistency with standard .NET exception hierarchy.
/// </remarks>
/// <seealso cref="ArgumentException" />
[Serializable]
public sealed class ArgumentPropertyNullException : ArgumentException
{
    private const string ExceptionMessage = "Value cannot be null.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class with a default error message.
    /// </summary>
    public ArgumentPropertyNullException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class with the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null.</param>
    public ArgumentPropertyNullException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class with a specified error message and the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyNullException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private ArgumentPropertyNullException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}