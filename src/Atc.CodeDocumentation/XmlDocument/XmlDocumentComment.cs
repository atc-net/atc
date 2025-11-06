namespace Atc.CodeDocumentation.XmlDocument;

/// <summary>
/// Represents a parsed XML documentation comment from an assembly's XML documentation file.
/// </summary>
public class XmlDocumentComment
{
    /// <summary>
    /// Gets or sets the type of the member (Field, Property, Type, Event, or Method).
    /// </summary>
    public MemberType MemberType { get; set; }

    /// <summary>
    /// Gets or sets the fully qualified name of the class containing this member.
    /// </summary>
    public string? ClassName { get; set; }

    /// <summary>
    /// Gets or sets the name of the documented member.
    /// </summary>
    public string? MemberName { get; set; }

    /// <summary>
    /// Gets or sets the summary documentation text.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Gets or sets the remarks documentation text.
    /// </summary>
    public string? Remarks { get; set; }

    /// <summary>
    /// Gets or sets the code usage documentation text.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the example documentation text.
    /// </summary>
    public string? Example { get; set; }

    /// <summary>
    /// Gets or sets the parameter documentation, mapped by parameter name.
    /// </summary>
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "OK.")]
    public Dictionary<string, string>? Parameters { get; set; }

    /// <summary>
    /// Gets or sets the return value documentation text.
    /// </summary>
    public string? Returns { get; set; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return MemberType + ":" + ClassName + "." + MemberName;
    }
}