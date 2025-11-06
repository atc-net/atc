// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an argument is null or contains the default value for its type.
/// </summary>
/// <remarks>
/// This exception is useful when validating method parameters that should not be null or their type's default value
/// (e.g., 0 for int, Guid.Empty for Guid, etc.).
/// </remarks>
/// <seealso cref="ArgumentException" />
[Serializable]
public sealed class ArgumentNullOrDefaultException : ArgumentException
{
    private const string ExceptionMessage = "Value cannot be null or default.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class with a default error message.
    /// </summary>
    public ArgumentNullOrDefaultException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class with the name of the parameter that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the parameter that is null or has a default value.</param>
    public ArgumentNullOrDefaultException(
        string paramName)
        : base(ExceptionMessage, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class with a specified error message and the name of the parameter that caused the exception.
    /// </summary>
    /// <param name="paramName">The name of the parameter that is null or has a default value.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ArgumentNullOrDefaultException(
        string paramName,
        string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentNullOrDefaultException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    private ArgumentNullOrDefaultException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}