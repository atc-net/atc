// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an item is not found.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class ItemNotFoundException : Exception
{
    private const string ExceptionMessage = "Item not found.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemNotFoundException"/> class.
    /// </summary>
    public ItemNotFoundException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ItemNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ItemNotFoundException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemNotFoundException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected ItemNotFoundException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}