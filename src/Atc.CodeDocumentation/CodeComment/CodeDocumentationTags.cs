namespace Atc.CodeDocumentation.CodeComment;

/// <summary>
/// Represents the structured documentation data for code members, including summary, parameters, remarks, and examples.
/// </summary>
public class CodeDocumentationTags
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CodeDocumentationTags"/> class with only a summary.
    /// </summary>
    /// <param name="summary">The summary description of the code member.</param>
    public CodeDocumentationTags(
        string summary)
    {
        Summary = summary;
        Parameters = null;
        Remark = null;
        Code = null;
        Example = null;
        Exceptions = null;
        Return = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CodeDocumentationTags"/> class with all documentation elements.
    /// </summary>
    /// <param name="summary">The summary description of the code member.</param>
    /// <param name="parameters">A dictionary mapping parameter names to their descriptions.</param>
    /// <param name="remark">Additional remarks about the code member.</param>
    /// <param name="code">Code usage examples.</param>
    /// <param name="example">Code examples demonstrating usage.</param>
    /// <param name="exceptions">A dictionary mapping exception types to their descriptions.</param>
    /// <param name="return">The description of the return value.</param>
    public CodeDocumentationTags(
        string summary,
        IReadOnlyDictionary<string, string>? parameters,
        string? remark,
        string? code,
        string? example,
        IReadOnlyDictionary<string, string>? exceptions,
        string? @return)
    {
        Summary = summary;
        Parameters = parameters;
        Remark = remark;
        Code = code;
        Example = example;
        Exceptions = exceptions;
        Return = @return;
    }

    /// <summary>
    /// Gets or sets the summary description of the code member.
    /// </summary>
    public string Summary { get; set; }

    /// <summary>
    /// Gets or sets the parameter descriptions, mapped by parameter name.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Parameters { get; set; }

    /// <summary>
    /// Gets or sets additional remarks about the code member.
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// Gets or sets code usage examples.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets code examples demonstrating usage.
    /// </summary>
    public string? Example { get; set; }

    /// <summary>
    /// Gets or sets the exception descriptions, mapped by exception type.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Exceptions { get; set; }

    /// <summary>
    /// Gets or sets the description of the return value.
    /// </summary>
    public string? Return { get; set; }

    /// <inheritdoc/>
    public override string ToString()
        => $"{nameof(Summary)}: {Summary}, {nameof(Parameters)}: {Parameters}, {nameof(Remark)}: {Remark}, {nameof(Code)}: {Code}, {nameof(Example)}: {Example}, {nameof(Exceptions)}: {Exceptions}, {nameof(Return)}: {Return}";
}