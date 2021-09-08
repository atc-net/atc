using System;
using System.Collections.Generic;
using Atc.Data.Models;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace Atc.Console.Spectre
{
    public static class LoggerExtensions
    {
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
}