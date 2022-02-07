namespace Atc.CodeDocumentation;

/// <summary>
/// XmlDocumentComment.
/// </summary>
public class XmlDocumentComment
{
    /// <summary>
    /// Gets or sets the type of the member.
    /// </summary>
    /// <value>
    /// The type of the member.
    /// </value>
    public MemberType MemberType { get; set; }

    /// <summary>
    /// Gets or sets the name of the class.
    /// </summary>
    /// <value>
    /// The name of the class.
    /// </value>
    public string? ClassName { get; set; }

    /// <summary>
    /// Gets or sets the name of the member.
    /// </summary>
    /// <value>
    /// The name of the member.
    /// </value>
    public string? MemberName { get; set; }

    /// <summary>
    /// Gets or sets the summary.
    /// </summary>
    /// <value>
    /// The summary.
    /// </value>
    public string? Summary { get; set; }

    /// <summary>
    /// Gets or sets the remarks.
    /// </summary>
    /// <value>
    /// The remarks.
    /// </value>
    public string? Remarks { get; set; }

    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    /// <value>
    /// The code.
    /// </value>
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the example.
    /// </summary>
    /// <value>
    /// The example.
    /// </value>
    public string? Example { get; set; }

    /// <summary>
    /// Gets or sets the parameters.
    /// </summary>
    /// <value>
    /// The parameters.
    /// </value>
    [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "OK.")]
    public Dictionary<string, string>? Parameters { get; set; }

    /// <summary>
    /// Gets or sets the returns.
    /// </summary>
    /// <value>
    /// The returns.
    /// </value>
    public string? Returns { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A string that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return this.MemberType + ":" + this.ClassName + "." + this.MemberName;
    }
}