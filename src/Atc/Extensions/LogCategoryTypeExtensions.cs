// ReSharper disable once CheckNamespace
namespace Atc;

[SuppressMessage(
    "Design",
    "CA1034:Nested types should not be visible",
    Justification = "False positive on C# 14 extension blocks; analyzer mistakes the extension parameter scope for a nested type.")]
public static class LogCategoryTypeExtensions
{
    extension(LogCategoryType logCategoryType)
    {
        /// <summary>
        /// Returns a 3-character abbreviation of the log category, padded so the
        /// width is constant (e.g. <c>UI</c> → <c>"UI "</c>) for visually aligned
        /// log output.
        /// </summary>
        public string ToShortName()
            => logCategoryType switch
            {
                LogCategoryType.Critical => "CRT",
                LogCategoryType.Error => "ERR",
                LogCategoryType.Warning => "WRN",
                LogCategoryType.Security => "SEC",
                LogCategoryType.Audit => "AUD",
                LogCategoryType.Service => "SVC",
                LogCategoryType.UI => "UI ",
                LogCategoryType.Information => "INF",
                LogCategoryType.Debug => "DBG",
                LogCategoryType.Trace => "TRC",
                _ => throw new SwitchCaseDefaultException(logCategoryType),
            };

        /// <summary>
        /// Returns the 3-character abbreviation wrapped in square brackets
        /// (e.g. <c>"[INF]"</c>), suitable as a log-line prefix.
        /// </summary>
        public string ToShortNameBracketed()
            => $"[{logCategoryType.ToShortName()}]";
    }
}