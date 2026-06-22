namespace Atc.Tests.Exceptions;

[SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "OK.")]
[SuppressMessage("Usage", "MA0015:Specify the parameter name in ArgumentException", Justification = "OK.")]
public class ExceptionsTests
{
    [Theory]
    [InlineData(null, "Value cannot be null or default.", null, null)]
    [InlineData("MyParam", "Value cannot be null or default. (Parameter 'MyParam')", "MyParam", null)]
    [InlineData("MyParam", "MyMessage (Parameter 'MyParam')", "MyParam", "MyMessage")]
    public void ArgumentNullOrDefaultException(
        string? expectedParam,
        string? expectedMessage,
        string? inputParam,
        string? inputMessage)
    {
        // Arrange & Act
        ArgumentNullOrDefaultException sut;
        if (inputParam != null && inputMessage != null)
        {
            sut = new ArgumentNullOrDefaultException(inputParam, inputMessage);
        }
        else if (inputParam is not null)
        {
            sut = new ArgumentNullOrDefaultException(inputParam);
        }
        else
        {
            sut = new ArgumentNullOrDefaultException();
        }

        // Assert
        if (expectedParam is null)
        {
            Assert.Null(sut.ParamName);
        }
        else
        {
            Assert.Equal(expectedParam, sut.ParamName);
        }

        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData(null, "Value cannot be null or default.", null, null)]
    [InlineData("MyParam", "Value cannot be null or default. (Parameter 'MyParam')", "MyParam", null)]
    [InlineData("MyParam", "MyMessage (Parameter 'MyParam')", "MyParam", "MyMessage")]
    public void ArgumentNullOrDefaultPropertyException(
        string? expectedParam,
        string? expectedMessage,
        string? inputParam,
        string? inputMessage)
    {
        // Arrange & Act
        ArgumentNullOrDefaultPropertyException sut;
        if (inputParam != null && inputMessage != null)
        {
            sut = new ArgumentNullOrDefaultPropertyException(inputParam, inputMessage);
        }
        else if (inputParam is not null)
        {
            sut = new ArgumentNullOrDefaultPropertyException(inputParam);
        }
        else
        {
            sut = new ArgumentNullOrDefaultPropertyException();
        }

        // Assert
        if (expectedParam is null)
        {
            Assert.Null(sut.ParamName);
        }
        else
        {
            Assert.Equal(expectedParam, sut.ParamName);
        }

        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData(null, "Value cannot be null.", null, null)]
    [InlineData("MyParam", "Value cannot be null. (Parameter 'MyParam')", "MyParam", null)]
    [InlineData("MyParam", "MyMessage (Parameter 'MyParam')", "MyParam", "MyMessage")]
    public void ArgumentNullPropertyException(
        string? expectedParam,
        string? expectedMessage,
        string? inputParam,
        string? inputMessage)
    {
        // Arrange & Act
        ArgumentNullPropertyException sut;
        if (inputParam != null && inputMessage != null)
        {
            sut = new ArgumentNullPropertyException(inputParam, inputMessage);
        }
        else if (inputParam is not null)
        {
            sut = new ArgumentNullPropertyException(inputParam);
        }
        else
        {
            sut = new ArgumentNullPropertyException();
        }

        // Assert
        if (expectedParam is null)
        {
            Assert.Null(sut.ParamName);
        }
        else
        {
            Assert.Equal(expectedParam, sut.ParamName);
        }

        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData(null, "Value does not fall within the expected range.", null, null)]
    [InlineData("MyParam", "Value does not fall within the expected range. (Parameter 'MyParam')", "MyParam", null)]
    [InlineData("MyParam", "MyMessage (Parameter 'MyParam')", "MyParam", "MyMessage")]
    public void ArgumentPropertyException(
        string? expectedParam,
        string? expectedMessage,
        string? inputParam,
        string? inputMessage)
    {
        // Arrange & Act
        ArgumentPropertyException sut;
        if (inputParam != null && inputMessage != null)
        {
            sut = new ArgumentPropertyException(inputParam, inputMessage);
        }
        else if (inputParam is not null)
        {
            sut = new ArgumentPropertyException(inputParam);
        }
        else
        {
            sut = new ArgumentPropertyException();
        }

        // Assert
        if (expectedParam is null)
        {
            Assert.Null(sut.ParamName);
        }
        else
        {
            Assert.Equal(expectedParam, sut.ParamName);
        }

        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData(null, "Value cannot be null.", null, null)]
    [InlineData("MyParam", "Value cannot be null. (Parameter 'MyParam')", "MyParam", null)]
    [InlineData("MyParam", "MyMessage (Parameter 'MyParam')", "MyParam", "MyMessage")]
    public void ArgumentPropertyNullException(
        string? expectedParam,
        string? expectedMessage,
        string? inputParam,
        string? inputMessage)
    {
        // Arrange & Act
        ArgumentPropertyNullException sut;
        if (inputParam != null && inputMessage != null)
        {
            sut = new ArgumentPropertyNullException(inputParam, inputMessage);
        }
        else if (inputParam is not null)
        {
            sut = new ArgumentPropertyNullException(inputParam);
        }
        else
        {
            sut = new ArgumentPropertyNullException();
        }

        // Assert
        if (expectedParam is null)
        {
            Assert.Null(sut.ParamName);
        }
        else
        {
            Assert.Equal(expectedParam, sut.ParamName);
        }

        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Certificate is not valid.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void CertificateValidationException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new CertificateValidationException(inputMessage)
            : new CertificateValidationException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("This exception is raised if a method which is only meant to be used at design time is invoked at run-time. The reason can for example be if a constructor has been provided for a ViewModel and it only should be used for design time.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void DesignTimeUseOnlyException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new DesignTimeUseOnlyException(inputMessage)
            : new DesignTimeUseOnlyException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Entity was not stored.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void EntityStoreException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new EntityStoreException(inputMessage)
            : new EntityStoreException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Item not found.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void ItemNotFoundException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new ItemNotFoundException(inputMessage)
            : new ItemNotFoundException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Value cannot be null.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void NullException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new System.NullException(inputMessage)
            : new System.NullException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Permission is not fulfilled.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void PermissionException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new PermissionException(inputMessage)
            : new PermissionException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("Value cannot be null or empty.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void StringNullOrEmptyException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new StringNullOrEmptyException(inputMessage)
            : new StringNullOrEmptyException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Theory]
    [InlineData("No user found.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void UserNotFoundException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new UserNotFoundException(inputMessage)
            : new UserNotFoundException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }

    [Fact]
    public void SwitchCaseDefaultException_EnumValue_ContainsEnumNameAndValue()
    {
        var sut = new SwitchCaseDefaultException(DayOfWeek.Monday);
        Assert.Contains("DayOfWeek", sut.Message, StringComparison.Ordinal);
        Assert.Contains("Monday", sut.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void SwitchCaseDefaultException_EnumValueAndMessage_ContainsAllParts()
    {
        var sut = new SwitchCaseDefaultException(DayOfWeek.Friday, "Custom message");
        Assert.Contains("Custom message", sut.Message, StringComparison.Ordinal);
        Assert.Contains("DayOfWeek", sut.Message, StringComparison.Ordinal);
        Assert.Contains("Friday", sut.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void SwitchCaseDefaultException_ObjectValue_ContainsTypeAndValue()
    {
        var sut = new SwitchCaseDefaultException((object?)"unexpected");
        Assert.Contains("String", sut.Message, StringComparison.Ordinal);
        Assert.Contains("unexpected", sut.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void SwitchCaseDefaultException_NullObjectValue_ContainsNullIndicator()
    {
        var sut = new SwitchCaseDefaultException((object?)null);
        Assert.Contains("<null>", sut.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void SwitchCaseDefaultException_ThrowEnum_ThrowsWithEnumDetails()
    {
        var ex = Assert.Throws<SwitchCaseDefaultException>(
            () => SwitchCaseDefaultException.Throw(DayOfWeek.Wednesday));
        Assert.Contains("Wednesday", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void SwitchCaseDefaultException_ThrowObject_ThrowsWithDetails()
    {
        var ex = Assert.Throws<SwitchCaseDefaultException>(
            () => SwitchCaseDefaultException.Throw((object)"bad"));
        Assert.Contains("bad", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void ConfigurationException_StructuredCtorWithInner_CarriesInnerException()
    {
        var inner = new InvalidOperationException("root cause");
        var sut = new ConfigurationException("MySection", "MyKey", isMissing: true, inner);
        Assert.Contains("MySection", sut.Message, StringComparison.Ordinal);
        Assert.Contains("MyKey", sut.Message, StringComparison.Ordinal);
        Assert.Same(inner, sut.InnerException);
    }

    [Fact]
    public void ConfigurationException_ThrowIfMissing_ThrowsWhenNullOrEmpty()
    {
        Assert.Throws<ConfigurationException>(
            () => ConfigurationException.ThrowIfMissing(null, "Sec", "Key"));
        Assert.Throws<ConfigurationException>(
            () => ConfigurationException.ThrowIfMissing(string.Empty, "Sec", "Key"));
    }

    [Fact]
    public void ConfigurationException_ThrowIfMissing_DoesNotThrowWhenValuePresent()
    {
        var exception = Record.Exception(
            () => ConfigurationException.ThrowIfMissing("value", "Sec", "Key"));
        Assert.Null(exception);
    }

    [Fact]
    public void ConfigurationException_ThrowIfInvalid_ThrowsWhenConditionTrue()
    {
        Assert.Throws<ConfigurationException>(
            () => ConfigurationException.ThrowIfInvalid(condition: true, "Sec", "Key"));
    }

    [Fact]
    public void ConfigurationException_ThrowIfInvalid_DoesNotThrowWhenConditionFalse()
    {
        var exception = Record.Exception(
            () => ConfigurationException.ThrowIfInvalid(condition: false, "Sec", "Key"));
        Assert.Null(exception);
    }

    [Fact]
    public void UnexpectedTypeException_Types_ContainsTypeNames()
    {
        var sut = new UnexpectedTypeException(typeof(string), typeof(int));
        Assert.Contains("string", sut.Message, StringComparison.Ordinal);
        Assert.Contains("int", sut.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void UnexpectedTypeException_TypesAndMessage_ContainsAllParts()
    {
        var sut = new UnexpectedTypeException(typeof(string), typeof(int), "Custom message");
        Assert.Contains("Custom message", sut.Message, StringComparison.Ordinal);
        Assert.Contains("string", sut.Message, StringComparison.Ordinal);
        Assert.Contains("int", sut.Message, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("Unexpected ViewModel.", null)]
    [InlineData("MyMessage", "MyMessage")]
    public void ViewModelException(
        string? expectedMessage,
        string? inputMessage)
    {
        // Arrange & Act
        var sut = inputMessage is not null
            ? new ViewModelException(inputMessage)
            : new ViewModelException();

        // Assert
        if (expectedMessage is null)
        {
            Assert.Null(sut.Message);
        }
        else
        {
            Assert.Equal(expectedMessage, sut.Message);
        }
    }
}