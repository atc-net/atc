// ReSharper disable LocalizableElement
// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// ArgumentNullOrDefaultException.
/// </summary>
/// <seealso cref="System.Exception" />
[Serializable]
public sealed class ArgumentNullOrDefaultException : ArgumentException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class.
    /// </summary>
    public ArgumentNullOrDefaultException()
        : base("Value cannot be null or default.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "OK.")]
    public ArgumentNullOrDefaultException(string paramName)
        : base("Value cannot be null or default.", paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class.
    /// </summary>
    /// <param name="paramName">Name of the parameter.</param>
    /// <param name="message">The message.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "param", Justification = "OK.")]
    public ArgumentNullOrDefaultException(string paramName, string message)
        : base(message, paramName)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArgumentNullOrDefaultException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ArgumentNullOrDefaultException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private ArgumentNullOrDefaultException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        : base("Value cannot be null or default.")
    {
    }
}