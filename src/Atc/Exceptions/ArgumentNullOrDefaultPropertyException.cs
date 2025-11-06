// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a property argument is null or contains the default value for its type.
/// </summary>
/// <remarks>
/// This exception is useful when validating property values that should not be null or their type's default value
/// (e.g., 0 for int, Guid.Empty for Guid, etc.).
/// </remarks>
/// <seealso cref="ArgumentException" />
[Serializable]
public sealed class ArgumentNullOrDefaultPropertyException : ArgumentException
{
    private const string ExceptionMessage = "Value cannot be null or default.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class with a default error message.
    /// </summary>
    public ArgumentNullOrDefaultPropertyException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class with the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null or has a default value.</param>
    public ArgumentNullOrDefaultPropertyException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class with a specified error message and the name of the property that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the property that is null or has a default value.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ArgumentNullOrDefaultPropertyException(
        string paramName,
        string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentNullOrDefaultPropertyException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultPropertyException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private ArgumentNullOrDefaultPropertyException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}