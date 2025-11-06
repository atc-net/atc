namespace Atc.Data.SemVer;

/// <summary>
/// Represents an identifier component of a semantic version (pre-release or build metadata).
/// </summary>
internal sealed class Identifier
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Identifier"/> class.
    /// </summary>
    /// <param name="input">The identifier string value.</param>
    public Identifier(string input)
    {
        Value = input;
        SetNumeric();
    }

    /// <summary>
    /// Gets a value indicating whether the identifier is numeric.
    /// </summary>
    public bool IsNumeric { get; private set; }

    /// <summary>
    /// Gets the integer value of the identifier if it is numeric.
    /// </summary>
    public int IntValue { get; private set; }

    /// <summary>
    /// Gets the string value of the identifier.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Returns a clean version of the identifier value.
    /// </summary>
    /// <returns>The cleaned identifier value as a string.</returns>
    public string Clean()
        => IsNumeric
            ? IntValue.ToString(GlobalizationConstants.EnglishCultureInfo)
            : Value;

    private void SetNumeric()
    {
        if (!int.TryParse(
                Value,
                NumberStyles.Any,
                GlobalizationConstants.EnglishCultureInfo,
                out var x))
        {
            return;
        }

        IsNumeric = x >= 0;
        IntValue = x;
    }
}