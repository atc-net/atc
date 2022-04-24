namespace Atc.Tests.XUnitTestTypes;

public class TestPerson
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

    public override string ToString()
        => $"{nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Age)}: {Age}";
}