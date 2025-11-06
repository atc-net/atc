// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when permission is not fulfilled.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class PermissionException : Exception
{
    private const string ExceptionMessage = "Permission is not fulfilled.";

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionException"/> class.
    /// </summary>
    public PermissionException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PermissionException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public PermissionException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected PermissionException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}