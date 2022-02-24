// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when an certificate is not valid.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class CertificateValidationException : Exception
{
    private const string ExceptionMessage = "Certificate is not valid.";

    /// <summary>
    /// Initializes a new instance of the <see cref="CertificateValidationException"/> class.
    /// </summary>
    public CertificateValidationException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CertificateValidationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public CertificateValidationException(
        string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CertificateValidationException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public CertificateValidationException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected CertificateValidationException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }
}