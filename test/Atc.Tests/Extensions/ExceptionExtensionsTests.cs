using System;
using Xunit;

// ReSharper disable LocalizableElement
// ReSharper disable NotResolvedInText
namespace Atc.Tests.Extensions
{
    public class ExceptionExtensionsTests
    {
        [Fact]
        public void GetMessage_ArgumentException()
        {
            const string defaultMessage = "Value does not fall within the expected range.";
            const string defaultMessageWithExceptionName = "Argument: Value does not fall within the expected range.";

            // 1 parameter
            Assert.Equal(
                defaultMessage,
                new ArgumentException().GetMessage());
            Assert.Equal(
                "Test",
                new ArgumentException("Test").GetMessage());
            Assert.Equal(
                defaultMessage,
                new ArgumentException().GetMessage(true));
            Assert.Equal(
                "Test",
                new ArgumentException("Test").GetMessage(true));
            Assert.Equal(
                defaultMessageWithExceptionName,
                new ArgumentException().GetMessage(true, true));
            Assert.Equal(
                "Argument: Test",
                new ArgumentException("Test").GetMessage(true, true));

            // 2 parameter
            Assert.Equal(
                "Test",
                new ArgumentException("Test", new ArgumentException()).GetMessage());
            Assert.Equal(
                "Test",
                new ArgumentException("Test", new ArgumentException("Test2")).GetMessage());
            Assert.Equal(
                "Test # " + defaultMessage,
                new ArgumentException("Test", new ArgumentException()).GetMessage(true));
            Assert.Equal(
                "Test # Test2",
                new ArgumentException("Test", new ArgumentException("Test2")).GetMessage(true));
            Assert.Equal(
                "Argument: Test # " + defaultMessageWithExceptionName,
                new ArgumentException("Test", new ArgumentException()).GetMessage(true, true));
            Assert.Equal(
                "Argument: Test # Argument: Test2",
                new ArgumentException("Test", new ArgumentException("Test2")).GetMessage(true, true));

            // 3 parameter
            Assert.Equal(
                "Test (Parameter 'paramName')",
                new ArgumentException("Test", "paramName", new ArgumentException()).GetMessage());
            Assert.Equal(
                "Test (Parameter 'paramName')",
                new ArgumentException("Test", "paramName", new ArgumentException("Test2")).GetMessage());
            Assert.Equal(
                "Test (Parameter 'paramName') # " + defaultMessage,
                new ArgumentException("Test", "paramName", new ArgumentException()).GetMessage(true));
            Assert.Equal(
                "Test (Parameter 'paramName') # Test2",
                new ArgumentException("Test", "paramName", new ArgumentException("Test2")).GetMessage(true));
            Assert.Equal(
                "Argument: Test (Parameter 'paramName') # " + defaultMessageWithExceptionName,
                new ArgumentException("Test", "paramName", new ArgumentException()).GetMessage(true, true));
            Assert.Equal(
                "Argument: Test (Parameter 'paramName') # Argument: Test2",
                new ArgumentException("Test", "paramName", new ArgumentException("Test2")).GetMessage(true, true));
        }

        [Theory]
        [InlineData("mySuper", "myArray", "myArg", "mySuper")]
        public void GetMessage(string expected, string message1, string message2, string message3)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.GetMessage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("mySuper", "myArray", "myArg", "mySuper", false)]
        [InlineData("mySuper # myArg # myArray", "myArray", "myArg", "mySuper", true)]
        public void GetMessage_IncludeInnerMessage(string expected, string message1, string message2, string message3, bool includeInnerMessage)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.GetMessage(includeInnerMessage);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("mySuper", "myArray", "myArg", "mySuper", false, false)]
        [InlineData("mySuper # myArg # myArray", "myArray", "myArg", "mySuper", true, false)]
        [InlineData("Exception: mySuper", "myArray", "myArg", "mySuper", false, true)]
        [InlineData("Exception: mySuper # Argument: myArg # ArrayTypeMismatch: myArray", "myArray", "myArg", "mySuper", true, true)]
        public void GetMessage_IncludeInnerMessage_IncludeExceptionName(string expected, string message1, string message2, string message3, bool includeInnerMessage, bool includeExceptionName)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.GetMessage(includeInnerMessage, includeExceptionName);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("myArray", "myArray", "myArg", "mySuper")]
        public void GetLastInnerMessage(string expected, string message1, string message2, string message3)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.GetLastInnerMessage();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("myArray", "myArray", "myArg", "mySuper", false)]
        [InlineData("ArrayTypeMismatch: myArray", "myArray", "myArg", "mySuper", true)]
        public void GetLastInnerMessage_IncludeExceptionName(string expected, string message1, string message2, string message3, bool includeExceptionName)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.GetLastInnerMessage(includeExceptionName);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("mySuper#myArg#myArray#", "myArray", "myArg", "mySuper")]
        public void Flatten(string expected, string message1, string message2, string message3)
        {
            // Arrange
            expected = expected.Replace("#", Environment.NewLine, StringComparison.Ordinal);
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.Flatten();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hallo#mySuper#myArg#myArray#", "Hallo", "myArray", "myArg", "mySuper")]
        public void Flatten_Message(string expected, string message0, string message1, string message2, string message3)
        {
            // Arrange
            expected = expected.Replace("#", Environment.NewLine, StringComparison.Ordinal);
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.Flatten(message0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hallo#mySuper#myArg#myArray#", "Hallo", "myArray", "myArg", "mySuper", false)]
        [InlineData("Hallo#mySuper#myArg#myArray#", "Hallo", "myArray", "myArg", "mySuper", true)]
        public void Flatten_Message_IncludeStackTrace(string expected, string message0, string message1, string message2, string message3, bool includeStackTrace)
        {
            // Arrange
            expected = expected.Replace("#", Environment.NewLine, StringComparison.Ordinal);
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.Flatten(message0, includeStackTrace);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(
@"<System.Exception>
  <Message>mySuper</Message>
  <System.ArgumentException>
    <Message>myArg</Message>
    <System.ArrayTypeMismatchException>
      <Message>myArray</Message>
    </System.ArrayTypeMismatchException>
  </System.ArgumentException>
</System.Exception>",
"myArray",
"myArg",
"mySuper")]
        public void ToXml(string expected, string message1, string message2, string message3)
        {
            // Arrange
            var exception1 = new ArrayTypeMismatchException(message1);
            var exception2 = new ArgumentException(message2, exception1);
            var input = new Exception(message3, exception2);

            // Act
            var actual = input.ToXml();

            // Assert
            Assert.Equal(expected.Replace(Environment.NewLine, string.Empty, StringComparison.Ordinal), actual.ToString().Replace(Environment.NewLine, string.Empty, StringComparison.Ordinal));
        }
    }
}