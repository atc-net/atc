namespace Atc.Data;

[SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "OK.")]
public static class LogItemFactory
{
    public static LogItem Create(LogCategoryType logCategoryType, string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(logCategoryType, message);
    }

    public static LogItem CreateCritical(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Critical, message);
    }

    public static LogItem CreateError(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Error, message);
    }

    public static LogItem CreateWarning(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Warning, message);
    }

    public static LogItem CreateSecurity(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Security, message);
    }

    public static LogItem CreateAudit(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Audit, message);
    }

    public static LogItem CreateService(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Service, message);
    }

    public static LogItem CreateUi(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.UI, message);
    }

    public static LogItem CreateInformation(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Information, message);
    }

    public static LogItem CreateDebug(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Debug, message);
    }

    public static LogItem CreateTrace(string message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return new LogItem(LogCategoryType.Trace, message);
    }

    public static LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value)
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

    public static LogKeyValueItem Create(LogCategoryType logCategoryType, string key, string value, string description)
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

    public static LogKeyValueItem CreateCritical(string key, string value)
    {
        return Create(LogCategoryType.Critical, key, value);
    }

    public static LogKeyValueItem CreateCritical(string key, string value, string description)
    {
        return Create(LogCategoryType.Critical, key, value, description);
    }

    public static LogKeyValueItem CreateError(string key, string value)
    {
        return Create(LogCategoryType.Error, key, value);
    }

    public static LogKeyValueItem CreateError(string key, string value, string description)
    {
        return Create(LogCategoryType.Error, key, value, description);
    }

    public static LogKeyValueItem CreateWarning(string key, string value)
    {
        return Create(LogCategoryType.Warning, key, value);
    }

    public static LogKeyValueItem CreateWarning(string key, string value, string description)
    {
        return Create(LogCategoryType.Warning, key, value, description);
    }

    public static LogKeyValueItem CreateSecurity(string key, string value)
    {
        return Create(LogCategoryType.Security, key, value);
    }

    public static LogKeyValueItem CreateSecurity(string key, string value, string description)
    {
        return Create(LogCategoryType.Security, key, value, description);
    }

    public static LogKeyValueItem CreateAudit(string key, string value)
    {
        return Create(LogCategoryType.Audit, key, value);
    }

    public static LogKeyValueItem CreateAudit(string key, string value, string description)
    {
        return Create(LogCategoryType.Audit, key, value, description);
    }

    public static LogKeyValueItem CreateService(string key, string value)
    {
        return Create(LogCategoryType.Service, key, value);
    }

    public static LogKeyValueItem CreateService(string key, string value, string description)
    {
        return Create(LogCategoryType.Service, key, value, description);
    }

    public static LogKeyValueItem CreateUi(string key, string value)
    {
        return Create(LogCategoryType.UI, key, value);
    }

    public static LogKeyValueItem CreateUi(string key, string value, string description)
    {
        return Create(LogCategoryType.UI, key, value, description);
    }

    public static LogKeyValueItem CreateInformation(string key, string value)
    {
        return Create(LogCategoryType.Information, key, value);
    }

    public static LogKeyValueItem CreateInformation(string key, string value, string description)
    {
        return Create(LogCategoryType.Information, key, value, description);
    }

    public static LogKeyValueItem CreateDebug(string key, string value)
    {
        return Create(LogCategoryType.Debug, key, value);
    }

    public static LogKeyValueItem CreateDebug(string key, string value, string description)
    {
        return Create(LogCategoryType.Debug, key, value, description);
    }

    public static LogKeyValueItem CreateTrace(string key, string value)
    {
        return Create(LogCategoryType.Trace, key, value);
    }

    public static LogKeyValueItem CreateTrace(string key, string value, string description)
    {
        return Create(LogCategoryType.Trace, key, value, description);
    }
}