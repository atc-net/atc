namespace Atc.Data;

public static class LogItemFactory
{
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