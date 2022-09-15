namespace Atc.Tests.Attributes.DataAnnotations.ValidationAttributes;

public static class StringAttributeTests
{
    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(true, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(true, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(true, "_Hallo")]
    [InlineData(true, "Hal lo")]
    [InlineData(true, "Hal.lo")]
    [InlineData(true, "Hal@lo")]
    [InlineData(true, "Hal\'lo")]
    public static void IsValid(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new StringAttribute();

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, "", null)]
    [InlineData(false, "The value must be between 1 and 256.", "")]
    [InlineData(true, "", "H")]
    [InlineData(true, "", "Hallo")]
    [InlineData(true, "", "HalloHalloHallo")]
    [InlineData(false, "The value must be between 1 and 256.", "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(true, "", "_Hallo")]
    [InlineData(true, "", "Hal lo")]
    [InlineData(true, "", "Hal.lo")]
    [InlineData(true, "", "Hal@lo")]
    [InlineData(true, "", "Hal\'lo")]
    public static void TryIsValid(
        bool expected,
        string expectedMessage,
        string input)
    {
        // Act
        var actual = StringAttribute.TryIsValid(input, out var errorMessage);

        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedMessage, errorMessage);
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(true, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(true, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "_Hallo")]
    [InlineData(false, "Hal lo")]
    [InlineData(false, "Hal.lo")]
    [InlineData(false, "Hal@lo")]
    [InlineData(false, "Hal\'lo")]
    public static void IsValid_WithInvalidFilters(
        bool expected,
        string input)
    {
        // Arrange
        var sut = new StringAttribute
        {
            InvalidCharacters = new[] { ' ', '.', '@', '\'' },
            InvalidPrefixStrings = new[] { "_" },
        };

        // Act
        var actual = sut.IsValid(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(false, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "_Hallo")]
    [InlineData(false, "Hal lo")]
    [InlineData(false, "Hal.lo")]
    [InlineData(false, "Hal@lo")]
    [InlineData(false, "Hal\'lo")]
    public static void StringAttribute_FirstName(
        bool expected,
        string? value)
    {
        // Arrange
        var stringAttribute = new StringAttribute();
        var model = new TestPersonForAttributeString
        {
            FirstName = value!,
            MiddleName = "XXX",
            LastName = "YYY",
            Age = 20,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidate(model, out var validationResults);

        // Assert
        Assert.Equal(expected, isValid);
        if (expected)
        {
            return;
        }

        if (value is null)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The MiddleName field is required.", StringComparer.Ordinal));
        }
        else if (value.Length > 256)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field FirstName must be between 2 and 10.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidCharacters
                 .Any(x => value.Contains(x.ToString(), StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field FirstName cannot contain: {string.Join(", ", stringAttribute.InvalidCharacters)}.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidPrefixStrings
                 .Any(x => value.Contains(x, StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field FirstName cannot start with: {string.Join(", ", stringAttribute.InvalidPrefixStrings)}.", StringComparer.Ordinal));
        }
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "")]
    [InlineData(true, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(true, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "_Hallo")]
    [InlineData(false, "Hal lo")]
    [InlineData(false, "Hal.lo")]
    [InlineData(false, "Hal@lo")]
    [InlineData(false, "Hal\'lo")]
    public static void StringAttribute_MiddleName(
        bool expected,
        string? value)
    {
        // Arrange
        var stringAttribute = new StringAttribute();
        var model = new TestPersonForAttributeString
        {
            FirstName = "XXX",
            MiddleName = value,
            LastName = "YYY",
            Age = 20,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidate(model, out var validationResults);

        // Assert
        Assert.Equal(expected, isValid);
        if (expected)
        {
            return;
        }

        if (value is null)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The MiddleName field is required.", StringComparer.Ordinal));
        }
        else if (value.Length > 256)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field MiddleName must be between 1 and 256.", StringComparer.Ordinal));

            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field MiddleName must be between 1 and 256.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidCharacters
                 .Any(x => value.Contains(x.ToString(), StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field MiddleName cannot contain: {string.Join(", ", stringAttribute.InvalidCharacters)}.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidPrefixStrings
                 .Any(x => value.Contains(x, StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field MiddleName cannot start with: {string.Join(", ", stringAttribute.InvalidPrefixStrings)}.", StringComparer.Ordinal));
        }
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(true, "H")]
    [InlineData(true, "Hallo")]
    [InlineData(true, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(true, "_Hallo")]
    [InlineData(true, "Hal lo")]
    [InlineData(true, "Hal.lo")]
    [InlineData(true, "Hal@lo")]
    [InlineData(true, "Hal\'lo")]
    public static void StringAttribute_LastName(
        bool expected,
        string? value)
    {
        // Arrange
        var stringAttribute = new StringAttribute();
        var model = new TestPersonForAttributeString
        {
            FirstName = "XXX",
            MiddleName = "YYY",
            LastName = value!,
            Age = 20,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidate(model, out var validationResults);

        // Assert
        Assert.Equal(expected, isValid);
        if (expected)
        {
            return;
        }

        if (value is null)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The MiddleName field is required.", StringComparer.Ordinal));
        }
        else if (value.Length > 256)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field LastName must be between 1 and 256.", StringComparer.Ordinal));

            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field LastName must be between 1 and 256.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidCharacters
                 .Any(x => value.Contains(x.ToString(), StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field LastName cannot contain: {string.Join(", ", stringAttribute.InvalidCharacters)}.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidPrefixStrings
                 .Any(x => value.Contains(x, StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field LastName cannot start with: {string.Join(", ", stringAttribute.InvalidPrefixStrings)}.", StringComparer.Ordinal));
        }
    }

    [Theory]
    [InlineData(true, null)]
    [InlineData(false, "")]
    [InlineData(false, "H")]
    [InlineData(false, "Hallo")]
    [InlineData(false, "HalloHalloHallo")]
    [InlineData(false, "HalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloHalloXX")]
    [InlineData(false, "_Hallo")]
    [InlineData(false, "Hal lo")]
    [InlineData(false, "Hal.lo")]
    [InlineData(false, "Hal@lo")]
    [InlineData(false, "Hal\'lo")]
    [InlineData(false, "Mr Hallo")]
    [InlineData(false, "mr. Hallo")]
    [InlineData(true, "Mr. Hallo")]
    public static void StringAttribute_Title(
        bool expected,
        string? value)
    {
        // Arrange
        var stringAttribute = new StringAttribute();
        var model = new TestPersonForAttributeString
        {
            FirstName = "XXX",
            MiddleName = "YYY",
            LastName = "ZZZ",
            Age = 20,
            Title = value!,
        };

        // Act
        var isValid = DataAnnotationHelper.TryValidate(model, out var validationResults);

        // Assert
        Assert.Equal(expected, isValid);
        if (expected)
        {
            return;
        }

        if (value is null)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The Title field is required.", StringComparer.Ordinal));
        }
        else if (value.Length > 256)
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field Title must be between 1 and 256.", StringComparer.Ordinal));

            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains("The field Title must be between 1 and 256.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidCharacters
                 .Any(x => value.Contains(x.ToString(), StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field Title cannot contain: {string.Join(", ", stringAttribute.InvalidCharacters)}.", StringComparer.Ordinal));
        }
        else if (stringAttribute.InvalidPrefixStrings
                 .Any(x => value.Contains(x, StringComparison.Ordinal)))
        {
            Assert.True(validationResults
                .Select(x => x.ErrorMessage)
                .Contains($"The field Title cannot start with: {string.Join(", ", stringAttribute.InvalidPrefixStrings)}.", StringComparer.Ordinal));
        }
    }
}