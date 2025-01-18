namespace Atc.Tests.XUnitTestTypes;

internal sealed class TestPersonForAttributeString
{
    public TestPersonForAttributeString()
    {
        FirstName = string.Empty;
        MiddleName = null;
        LastName = string.Empty;
        Title = null;
    }

    [String(
        MinLength = 2,
        MaxLength = 10,
        InvalidCharacters = new[] { ' ', '.', '@', '\'' },
        InvalidPrefixStrings = new[] { "_" })]
    public string FirstName { get; set; }

    [String(
        Required = true,
        InvalidCharacters = new[] { ' ', '.', '@', '\'' },
        InvalidPrefixStrings = new[] { "_" })]
    public string? MiddleName { get; set; }

    [String]
    public string LastName { get; set; }

    [Range(1, 99)]
    public int Age { get; set; }

    [String(RegularExpression = @"^(Master|Mr|Miss|Mrs|Ms|Mx)\.")]
    public string? Title { get; set; }

    public override string ToString()
        => $"{nameof(FirstName)}: {FirstName}, {nameof(MiddleName)}: {MiddleName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}, {nameof(Title)}: {Title}";
}