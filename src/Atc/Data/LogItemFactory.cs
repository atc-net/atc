namespace Atc.Data;

/// <summary>
/// Factory for creating <see cref="LogItem"/> and <see cref="LogKeyValueItem"/> instances.
/// Provides convenient methods for creating log items with different severity levels.
/// </summary>
[SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "OK.")]
public static class LogItemFactory
{
    /// <summary>
    /// Creates a new <see cref="LogItem"/> with the specified log category and message.
    /// </summary>
    /// <param name="logCategoryType">The log category type.</param>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem Create(
        LogCategoryType logCategoryType,
        string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(logCategoryType, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with critical severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with critical severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateCritical(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Critical, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with error severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with error severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateError(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Error, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with warning severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with warning severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateWarning(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Warning, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with security severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with security severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateSecurity(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Security, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with audit severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with audit severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateAudit(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Audit, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with service severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with service severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateService(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Service, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with UI severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with UI severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateUi(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.UI, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with information severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with information severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateInformation(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Information, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with debug severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with debug severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateDebug(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Debug, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogItem"/> with trace severity.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <returns>A new <see cref="LogItem"/> instance with trace severity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="message"/> is null.</exception>
    public static LogItem CreateTrace(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Trace, message);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with the specified log category, key, and value.
    /// </summary>
    /// <param name="logCategoryType">The log category type.</param>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> or <paramref name="value"/> is null.</exception>
    public static LogKeyValueItem Create(
        LogCategoryType logCategoryType,
        string key,
        string value)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return new LogKeyValueItem(logCategoryType, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with the specified log category, key, value, and description.
    /// </summary>
    /// <param name="logCategoryType">The log category type.</param>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/>, <paramref name="value"/>, or <paramref name="description"/> is null.</exception>
    public static LogKeyValueItem Create(
        LogCategoryType logCategoryType,
        string key,
        string value,
        string description)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (description is null)
        {
            throw new ArgumentNullException(nameof(description));
        }

        return new LogKeyValueItem(logCategoryType, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with critical severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with critical severity.</returns>
    public static LogKeyValueItem CreateCritical(
        string key,
        string value)
    {
        return Create(LogCategoryType.Critical, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with critical severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with critical severity.</returns>
    public static LogKeyValueItem CreateCritical(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Critical, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with error severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with error severity.</returns>
    public static LogKeyValueItem CreateError(
        string key,
        string value)
    {
        return Create(LogCategoryType.Error, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with error severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with error severity.</returns>
    public static LogKeyValueItem CreateError(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Error, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with warning severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with warning severity.</returns>
    public static LogKeyValueItem CreateWarning(
        string key,
        string value)
    {
        return Create(LogCategoryType.Warning, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with warning severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with warning severity.</returns>
    public static LogKeyValueItem CreateWarning(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Warning, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with security severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with security severity.</returns>
    public static LogKeyValueItem CreateSecurity(
        string key,
        string value)
    {
        return Create(LogCategoryType.Security, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with security severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with security severity.</returns>
    public static LogKeyValueItem CreateSecurity(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Security, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with audit severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with audit severity.</returns>
    public static LogKeyValueItem CreateAudit(
        string key,
        string value)
    {
        return Create(LogCategoryType.Audit, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with audit severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with audit severity.</returns>
    public static LogKeyValueItem CreateAudit(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Audit, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with service severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with service severity.</returns>
    public static LogKeyValueItem CreateService(
        string key,
        string value)
    {
        return Create(LogCategoryType.Service, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with service severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with service severity.</returns>
    public static LogKeyValueItem CreateService(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Service, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with UI severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with UI severity.</returns>
    public static LogKeyValueItem CreateUi(
        string key,
        string value)
    {
        return Create(LogCategoryType.UI, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with UI severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with UI severity.</returns>
    public static LogKeyValueItem CreateUi(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.UI, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with information severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with information severity.</returns>
    public static LogKeyValueItem CreateInformation(
        string key,
        string value)
    {
        return Create(LogCategoryType.Information, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with information severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with information severity.</returns>
    public static LogKeyValueItem CreateInformation(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Information, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with debug severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with debug severity.</returns>
    public static LogKeyValueItem CreateDebug(
        string key,
        string value)
    {
        return Create(LogCategoryType.Debug, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with debug severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with debug severity.</returns>
    public static LogKeyValueItem CreateDebug(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Debug, key, value, description);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with trace severity.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with trace severity.</returns>
    public static LogKeyValueItem CreateTrace(
        string key,
        string value)
    {
        return Create(LogCategoryType.Trace, key, value);
    }

    /// <summary>
    /// Creates a new <see cref="LogKeyValueItem"/> with trace severity and a description.
    /// </summary>
    /// <param name="key">The log item key.</param>
    /// <param name="value">The log item value.</param>
    /// <param name="description">The log item description.</param>
    /// <returns>A new <see cref="LogKeyValueItem"/> instance with trace severity.</returns>
    public static LogKeyValueItem CreateTrace(
        string key,
        string value,
        string description)
    {
        return Create(LogCategoryType.Trace, key, value, description);
    }
}