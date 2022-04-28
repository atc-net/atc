namespace Atc.Tests.XUnitTestTypes;

public class TestPersonForAttributeString
{
    public TestPersonForAttributeString()
    {
        FirstName = string.Empty;
        MiddleName = null;
        LastName = string.Empty;
    }

    [String(MinLength = 2, MaxLength = 10)]
    public string FirstName { get; set; }

    [String(Required = true)]
    public string? MiddleName { get; set; }

    [String]
    public string LastName { get; set; }

    [Range(1, 99)]
    public int Age { get; set; }

    public override string ToString()
        => $"{nameof(FirstName)}: {FirstName}, {nameof(MiddleName)}: {MiddleName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}";
}