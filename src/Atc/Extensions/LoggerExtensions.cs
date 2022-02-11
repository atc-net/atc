// ReSharper disable once CheckNamespace
namespace Atc;

public static class LoggerExtensions
{
    /// <summary>Logs the key value item.</summary>
    /// <param name="logger">The logger.</param>
    /// <param name="logKeyValueItem">The log key value item.</param>
    /// <param name="includeKey">if set to <c>true</c> [include key].</param>
    /// <param name="includeDescription">if set to <c>true</c> [include description].</param>
    public static void LogKeyValueItem(
        this ILogger logger,
        LogKeyValueItem logKeyValueItem,
        bool includeKey = true,
        bool includeDescription = true)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (logKeyValueItem is null)
        {
            throw new ArgumentNullException(nameof(logKeyValueItem));
        }

        var message = logKeyValueItem.GetLogMessage(includeKey, includeDescription);

        switch (logKeyValueItem.LogCategory)
        {
            case LogCategoryType.Critical:
                logger.LogCritical(message);
                break;
            case LogCategoryType.Error:
                logger.LogError(message);
                break;
            case LogCategoryType.Warning:
                logger.LogWarning(message);
                break;
            case LogCategoryType.Security:
            case LogCategoryType.Audit:
            case LogCategoryType.Service:
            case LogCategoryType.UI:
            case LogCategoryType.Information:
                logger.LogInformation(message);
                break;
            case LogCategoryType.Debug:
                logger.LogDebug(message);
                break;
            case LogCategoryType.Trace:
                logger.LogTrace(message);
                break;
            default:
                throw new SwitchCaseDefaultException(logKeyValueItem.LogCategory);
        }
    }

    /// <summary>Logs the key value items.</summary>
    /// <param name="logger">The logger.</param>
    /// <param name="logKeyValueItems">The log key value items.</param>
    /// <param name="includeKey">if set to <c>true</c> [include key].</param>
    /// <param name="includeDescription">if set to <c>true</c> [include description].</param>
    public static void LogKeyValueItems(
        this ILogger logger,
        List<LogKeyValueItem> logKeyValueItems,
        bool includeKey = true,
        bool includeDescription = true)
    {
        if (logger is null)
        {
            throw new ArgumentNullException(nameof(logger));
        }

        if (logKeyValueItems is null)
        {
            throw new ArgumentNullException(nameof(logKeyValueItems));
        }

        foreach (var item in logKeyValueItems)
        {
            logger.LogKeyValueItem(item, includeKey, includeDescription);
        }
    }
}