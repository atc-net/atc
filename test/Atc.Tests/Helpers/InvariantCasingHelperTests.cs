namespace Atc.Tests.Helpers;

/// <summary>
/// Case mapping follows the platform's Unicode data (ICU on Linux), which can be newer than the runtime's: a letter can
/// map to one the runtime does not know as a letter yet. U+0378 is unassigned, so no runtime knows it as a letter - it
/// stands in for such a newer letter here, on any platform.
/// </summary>
public class InvariantCasingHelperTests
{
    private const char Unassigned = '͸';

    [Fact]
    public void Keep_ALetterCasedToNoLetterHere_KeepsTheLetter()
        => Assert.Equal('a', InvariantCasingHelper.Keep('a', Unassigned));

    [Theory]
    [InlineData('a', 'A', 'A')]
    [InlineData('Ä', 'ä', 'ä')]
    [InlineData('1', '1', '1')]
    [InlineData('_', '_', '_')]
    public void Keep_ACasedLetterOrANonLetter_TakesTheCasedOne(
        char original,
        char cased,
        char expected)
        => Assert.Equal(expected, InvariantCasingHelper.Keep(original, cased));

    [Fact]
    public void Keep_AStringWithALetterCasedToNoLetterHere_KeepsThatLetterOnly()
        => Assert.Equal("Ab_C", InvariantCasingHelper.Keep("ab_c", "A" + Unassigned + "_C"));

    // Deseret: a letter outside the Basic Multilingual Plane is two code units, cased together
    [Fact]
    public void Keep_AStringWithASurrogatePair_CasesThePairAsOneLetter()
        => Assert.Equal("\U00010428x", InvariantCasingHelper.Keep("\U00010400X", "\U00010428x"));

    [Fact]
    public void Keep_StringsOfDifferentLength_TakesTheCasedOne()
        => Assert.Equal("ABC", InvariantCasingHelper.Keep("ab", "ABC"));

    [Fact]
    public void Keep_NullString_Throws()
        => Assert.Throws<ArgumentNullException>(() => InvariantCasingHelper.Keep(null!, "a"));

    [Theory]
    [InlineData("pet", "Pet", "pet")]
    [InlineData("Pet", "Pet", "pet")]
    [InlineData("ä", "Ä", "ä")]
    [InlineData("", "", "")]
    [InlineData("1st", "1st", "1st")]
    public void ToUpperFirst_And_ToLowerFirst_CaseTheFirstCharacterOnly(
        string value,
        string upperFirst,
        string lowerFirst)
    {
        Assert.Equal(upperFirst, InvariantCasingHelper.ToUpperFirst(value));
        Assert.Equal(lowerFirst, InvariantCasingHelper.ToLowerFirst(value));
    }

    [Theory]
    [InlineData("PetStore", "PETSTORE", "petstore")]
    [InlineData("\U00010400", "\U00010400", "\U00010428")]
    [InlineData("", "", "")]
    public void ToUpper_And_ToLower_CaseTheWholeText(
        string value,
        string upper,
        string lower)
    {
        Assert.Equal(upper, InvariantCasingHelper.ToUpper(value));
        Assert.Equal(lower, InvariantCasingHelper.ToLower(value));
    }

    [Fact]
    public void ToUpper_And_ToLower_OfAChar_CaseIt()
    {
        Assert.Equal('P', InvariantCasingHelper.ToUpper('p'));
        Assert.Equal('p', InvariantCasingHelper.ToLower('P'));
    }
}