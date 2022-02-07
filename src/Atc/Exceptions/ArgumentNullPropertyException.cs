// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// ArgumentNullPropertyException.
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public sealed class ArgumentNullPropertyException : ArgumentException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class.
    /// </summary>
    public ArgumentNullPropertyException()
        : base("Value cannot be null.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    public ArgumentNullPropertyException(string paramName)
        : base("Value cannot be null.", paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    /// <param name="message">The message.</param>
    public ArgumentNullPropertyException(string paramName, string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullPropertyException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentNullPropertyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private ArgumentNullPropertyException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base("Value cannot be null.")
    {
    }
}