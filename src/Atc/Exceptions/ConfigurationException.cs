// ReSharper disable CheckNamespace
namespace System;

/// <summary>
/// The exception that is thrown when a configuration error occurs, such as missing or invalid configuration settings.
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class with a configuration section, key, and status.
    /// </summary>
    /// <param name="section">The configuration section name.</param>
    /// <param name="key">The configuration key name.</param>
    /// <param name="isMissing">A value indicating whether the configuration is missing (true) or invalid (false).</param>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
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