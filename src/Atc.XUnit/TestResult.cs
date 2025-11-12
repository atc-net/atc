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
        IsError = false;
        IndentLevel = 0;
        Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    public TestResult(
        int indentLevel,
        string text)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        IsError = true;
        IndentLevel = indentLevel;
        Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="isError">if set to <see langword="true" /> [is error].</param>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    public TestResult(
        bool isError,
        int indentLevel,
        string text)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        IsError = isError;
        IndentLevel = indentLevel;
        Text = text;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestResult"/> class.
    /// </summary>
    /// <param name="indentLevel">The indent level.</param>
    /// <param name="text">The text.</param>
    /// <param name="subLines">The sub lines.</param>
    public TestResult(
        int indentLevel,
        string text,
        List<string> subLines)
    {
        if (indentLevel < 0)
        {
            indentLevel = 1;
        }

        IsError = true;
        IndentLevel = indentLevel;
        Text = text;
        SubLines = subLines;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is error.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is error; otherwise, <see langword="false" />.
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
        => $"{nameof(IsError)}: {IsError}, {nameof(IndentLevel)}: {IndentLevel}, {nameof(Text)}: {Text}, {nameof(SubLines)}: {SubLines?.Count}";
}