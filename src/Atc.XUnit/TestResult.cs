namespace Atc.XUnit;

/// <summary>
/// TestResult.
/// </summary>
public class TestResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="text">The text.</param>
    public TestResult(string text)
    {
        this.IsError = false;
        this.IndentLevel = 0;
        this.Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    public TestResult(int indentLevel, string text)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        this.IsError = true;
        this.IndentLevel = indentLevel;
        this.Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="isError">if set to <c>true</c> [is error].</param>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    public TestResult(bool isError, int indentLevel, string text)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        this.IsError = isError;
        this.IndentLevel = indentLevel;
        this.Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    /// <param name="subLines">The sub lines.</param>
    public TestResult(int indentLevel, string text, List<string> subLines)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        this.IsError = true;
        this.IndentLevel = indentLevel;
        this.Text = text;
        this.SubLines = subLines;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is error.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
    /// </value>
    public bool IsError { get; }

    /// <summary>
    /// Gets the indent level.
    /// </summary>
    /// <value>
    /// The indent level.
    /// </value>
    public int IndentLevel { get; }

    /// <summary>
    /// Gets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    public string Text { get; }

    /// <summary>
    /// Gets the sub lines.
    /// </summary>
    /// <value>
    /// The sub lines.
    /// </value>
    public List<string>? SubLines { get; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A string that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"{nameof(this.IsError)}: {this.IsError}, {nameof(this.IndentLevel)}: {this.IndentLevel}, {nameof(this.Text)}: {this.Text}, {nameof(this.SubLines)}: {this.SubLines?.Count}";
    }
}