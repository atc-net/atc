namespace Atc.CodeDocumentation.CodeComment;

public class CodeDocumentationTags
{
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

    public string Summary { get; set; }

    public IReadOnlyDictionary<string, string>? Parameters { get; set; }

    public string? Remark { get; set; }

    public string? Code { get; set; }

    public string? Example { get; set; }

    public IReadOnlyDictionary<string, string>? Exceptions { get; set; }

    public string? Return { get; set; }

    public override string ToString()
        => $"{nameof(Summary)}: {Summary}, {nameof(Parameters)}: {Parameters}, {nameof(Remark)}: {Remark}, {nameof(Code)}: {Code}, {nameof(Example)}: {Example}, {nameof(Exceptions)}: {Exceptions}, {nameof(Return)}: {Return}";
}