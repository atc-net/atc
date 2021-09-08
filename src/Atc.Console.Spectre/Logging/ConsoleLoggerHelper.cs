using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Atc.Data.Models;
using Microsoft.Extensions.Logging;

namespace Atc.Console.Spectre.Logging
{
    public static class ConsoleLoggerHelper
    {
        public static void Output(
            ILogger logger,
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

            var message = GetMessage(logKeyValueItem, includeKey, includeDescription);

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

        public static void Output(
            ILogger logger,
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
                Output(logger, item, includeKey, includeDescription);
            }
        }

        [SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "OK.")]
        private static string GetMessage(LogKeyValueItem logKeyValueItem, bool includeKey, bool includeDescription)
            => includeKey switch
            {
                true when includeDescription => string.IsNullOrEmpty(logKeyValueItem.Description)
                    ? $"{logKeyValueItem.Key}: {logKeyValueItem.Value}"
                    : $"{logKeyValueItem.Key}: {logKeyValueItem.Value} - {logKeyValueItem.Description}",
                true => $"{logKeyValueItem.Key}: {logKeyValueItem.Value}",
                _ => includeDescription
                    ? string.IsNullOrEmpty(logKeyValueItem.Description)
                        ? $"{logKeyValueItem.Value}"
                        : $"{logKeyValueItem.Value} - {logKeyValueItem.Description}"
                    : $"{logKeyValueItem.Value}"
            };
    }
}