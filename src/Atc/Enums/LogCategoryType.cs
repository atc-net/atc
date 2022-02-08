// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Atc;

/// <summary>
/// Enumeration: LogCategoryType categories available for logging.
/// </summary>
public enum LogCategoryType
{
    /// <summary>
    /// Critical.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeCritical", typeof(EnumResources))]
    Critical,

    /// <summary>
    /// Error.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeError", typeof(EnumResources))]
    Error,

    /// <summary>
    /// Warning.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeWarning", typeof(EnumResources))]
    Warning,

    /// <summary>
    /// Security.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeSecurity", typeof(EnumResources))]
    Security,

    /// <summary>
    /// Audit.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeAudit", typeof(EnumResources))]
    Audit,

    /// <summary>
    /// Service.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeService", typeof(EnumResources))]
    Service,

    /// <summary>
    /// UI.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeUI", typeof(EnumResources))]
    UI,

    /// <summary>
    /// Information.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeInformation", typeof(EnumResources))]
    Information,

    /// <summary>
    /// Debug.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeDebug", typeof(EnumResources))]
    Debug,

    /// <summary>
    /// Trace.
    /// </summary>
    [LocalizedDescription("LogCategoryTypeTrace", typeof(EnumResources))]
    Trace,
}