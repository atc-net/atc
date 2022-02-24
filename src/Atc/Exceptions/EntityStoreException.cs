// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an entity is not stored.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class EntityStoreException : Exception
{
    private const string ExceptionMessage = "Entity was not stored.";

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityStoreException"/> class.
    /// </summary>
    public EntityStoreException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityStoreException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public EntityStoreException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityStoreException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public EntityStoreException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected EntityStoreException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}