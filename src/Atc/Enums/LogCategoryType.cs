// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Defines different categories of log messages for classification and filtering purposes.
/// </summary>
public enum LogCategoryType
{
    /// <summary>
    /// Critical issues that require immediate attention and may cause system failure.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeCritical", typeof(EnumResources))]
    Critical,

    /// <summary>
    /// Error conditions that prevent normal operation but don't cause system failure.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeError", typeof(EnumResources))]
    Error,

    /// <summary>
    /// Warning messages about potentially problematic situations.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeWarning", typeof(EnumResources))]
    Warning,

    /// <summary>
    /// Security-related events such as authentication or authorization issues.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeSecurity", typeof(EnumResources))]
    Security,

    /// <summary>
    /// Audit trail entries for compliance and tracking purposes.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeAudit", typeof(EnumResources))]
    Audit,

    /// <summary>
    /// Service-level events and operations.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeService", typeof(EnumResources))]
    Service,

    /// <summary>
    /// User interface related events and interactions.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeUI", typeof(EnumResources))]
    UI,

    /// <summary>
    /// General informational messages about normal operations.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeInformation", typeof(EnumResources))]
    Information,

    /// <summary>
    /// Detailed debugging information for development purposes.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeDebug", typeof(EnumResources))]
    Debug,

    /// <summary>
    /// Very detailed diagnostic information for tracing execution flow.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeTrace", typeof(EnumResources))]
    Trace,
}