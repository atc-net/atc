namespace Atc.Tests.XUnitTestTypes;

internal sealed class TestPerson
{
    public TestPerson()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Range(1, 99)]
    public int Age { get; set; }

    public string? Email { get; set; }

    public override string ToString()
        => $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}, {nameof(Email)}: {Email}";
}