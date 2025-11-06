// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a property argument value does not fall within the expected range.
/// </summary>
/// <remarks>
/// This exception is similar to <see cref="ArgumentException"/>, but is specifically designed for validating property values
/// rather than method parameters.
/// </remarks>
/// <seealso cref="ArgumentException" />
[Serializable]
public sealed class ArgumentPropertyException : ArgumentException
{
    private const string ExceptionMessage = "Value does not fall within the expected range.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class with a default error message.
    /// </summary>
    public ArgumentPropertyException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class with the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that caused the exception.</param>
    public ArgumentPropertyException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class with a specified error message and the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that caused the exception.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ArgumentPropertyException(
        string paramName,
        string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentPropertyException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentPropertyException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private ArgumentPropertyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}