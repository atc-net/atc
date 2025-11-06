// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a null argument is passed to a property.
/// </summary>
/// <remarks>
/// This exception is specifically designed for validating property setter arguments
/// rather than method parameters.
/// </remarks>
/// <seealso cref="ArgumentException" />
[Serializable]
public sealed class ArgumentNullPropertyException : ArgumentException
{
    private const string ExceptionMessage = "Value cannot be null.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class with a default error message.
    /// </summary>
    public ArgumentNullPropertyException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class with the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null.</param>
    public ArgumentNullPropertyException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class with a specified error message and the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ArgumentNullPropertyException(
        string paramName,
        string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentNullPropertyException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private ArgumentNullPropertyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}