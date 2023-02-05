// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a TCP error occurred.
/// </summary>
/// <seealso cref="Exception" />
[Serializable]
public class ConfigurationException : Exception
{
    private const string ExceptionMessage = "Configuration error.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
    /// </summary>
    public ConfigurationException()
        : base(ExceptionMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ConfigurationException(
        string message)
        : base(message)
    {
    }

    public ConfigurationException(
        string section,
        string key,
        bool isMissing)
        : base($"Configuration with section '{section}' and key '{key}' is {GetTermForIsMissing(isMissing)}.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public ConfigurationException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }

    protected ConfigurationException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
        : base(ExceptionMessage)
    {
    }

    private static string GetTermForIsMissing(
        bool isMissing)
        => isMissing
            ? "missing"
            : "invalid";
}