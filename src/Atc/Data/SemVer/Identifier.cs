namespace Atc.Data.SemVer;

internal sealed class Identifier
{
    public Identifier(string input)
    {
        Value = input;
        SetNumeric();
    }

    public bool IsNumeric { get; private set; }

    public int IntValue { get; private set; }

    public string Value { get; }

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