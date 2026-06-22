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
    public ConfigurationException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class with a configuration section, key, and status.
    /// </summary>
    /// <param name="section">The configuration section name.</param>
    /// <param name="key">The configuration key name.</param>
    /// <param name="isMissing">A value indicating whether the configuration is missing (<see langword="true"/>) or invalid (<see langword="false"/>).</param>
    public ConfigurationException(
        string section,
        string key,
        bool isMissing)
        : base($"Configuration with section '{section}' and key '{key}' is {GetTermForIsMissing(isMissing)}.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class with a configuration section, key, status, and inner exception.
    /// </summary>
    /// <param name="section">The configuration section name.</param>
    /// <param name="key">The configuration key name.</param>
    /// <param name="isMissing">A value indicating whether the configuration is missing (<see langword="true"/>) or invalid (<see langword="false"/>).</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public ConfigurationException(
        string section,
        string key,
        bool isMissing,
        Exception innerException)
        : base(
            $"Configuration with section '{section}' and key '{key}' is {GetTermForIsMissing(isMissing)}.",
            innerException)
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
    /// Throws a <see cref="ConfigurationException"/> if <paramref name="value"/> is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="value">The configuration value to validate.</param>
    /// <param name="section">The configuration section name.</param>
    /// <param name="key">The configuration key name.</param>
    public static void ThrowIfMissing(
        [NotNull] string? value,
        string section,
        string key)
    {
        if (value is null || value.Length == 0)
        {
            throw new ConfigurationException(section, key, isMissing: true);
        }
    }

    /// <summary>
    /// Throws a <see cref="ConfigurationException"/> if <paramref name="condition"/> is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">The condition that indicates the configuration value is invalid.</param>
    /// <param name="section">The configuration section name.</param>
    /// <param name="key">The configuration key name.</param>
    public static void ThrowIfInvalid(
        bool condition,
        string section,
        string key)
    {
        if (condition)
        {
            throw new ConfigurationException(section, key, isMissing: false);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationException"/> class with serialized data.
    /// </summary>
    /// <param name="serializationInfo">The serialization information.</param>
    /// <param name="streamingContext">The streaming context.</param>
    protected ConfigurationException(
        SerializationInfo serializationInfo,
        StreamingContext streamingContext)
#if NETSTANDARD2_0
        : base(serializationInfo, streamingContext)
#else
        : base(ExceptionMessage)
#endif
    {
    }

    private static string GetTermForIsMissing(bool isMissing)
        => isMissing
            ? "missing"
            : "invalid";
}