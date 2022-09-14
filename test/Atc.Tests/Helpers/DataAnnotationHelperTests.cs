// ReSharper disable InvertIf
namespace Atc.Tests.Helpers;

public class DataAnnotationHelperTests
{
    [Theory]
    [InlineData(false, "", "", 0, true)]
    [InlineData(true, "John", "Doe", 42, true)]
    public void TryValidate(bool expected, string firstName, string lastName, int age, bool validateAllProperties)
    {
        // Arrange
        var person = new TestPerson
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidate(person, out var validationResults, validateAllProperties);

        // Assert
        Assert.Equal(expected, isValid);
        if (!expected)
        {
            Assert.Equal(2, validationResults.Count);
            Assert.Equal("The FirstName field is required.", validationResults[0].ErrorMessage);
            Assert.Equal("The field Age must be between 1 and 99.", validationResults[1].ErrorMessage);
        }
    }

    [Theory]
    [InlineData(false, "", "", 0, true)]
    [InlineData(true, "John", "Doe", 42, true)]
    public void TryValidateOutToString(bool expected, string firstName, string lastName, int age, bool validateAllProperties)
    {
        // Arrange
        var person = new TestPerson
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidateOutToString(person, out var validationMessage, validateAllProperties);

        // Assert
        Assert.Equal(expected, isValid);
        if (!expected)
        {
            Assert.Equal(
                $"The FirstName field is required.{Environment.NewLine}The field Age must be between 1 and 99.{Environment.NewLine}",
                validationMessage);
        }
    }

    [Theory]
    [InlineData(false, "", "", 0, true)]
    [InlineData(true, "John", "Doe", 42, true)]
    public void TryValidateOutToValidationException(bool expected, string firstName, string lastName, int age, bool validateAllProperties)
    {
        // Arrange
        var person = new TestPerson
        {
            FirstName = firstName,
            LastName = lastName,
            Age = age,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidateOutToValidationException(person, out var validationException, validateAllProperties);

        // Assert
        Assert.Equal(expected, isValid);
        if (!expected)
        {
            Assert.Equal(
                $"The FirstName field is required.{Environment.NewLine}The field Age must be between 1 and 99.{Environment.NewLine}",
                validationException.Message);
        }
    }
}