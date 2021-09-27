using Atc.Data;
using Xunit;

namespace Atc.Tests.Data
{
    public class LogItemFactoryTests
    {
        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Critical, Description: ", LogCategoryType.Critical, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Error, Description: ", LogCategoryType.Error, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Warning, Description: ", LogCategoryType.Warning, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Security, Description: ", LogCategoryType.Security, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Audit, Description: ", LogCategoryType.Audit, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Service, Description: ", LogCategoryType.Service, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: UI, Description: ", LogCategoryType.UI, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Information, Description: ", LogCategoryType.Information, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Debug, Description: ", LogCategoryType.Debug, "MyKey", "MyValue")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Trace, Description: ", LogCategoryType.Trace, "MyKey", "MyValue")]
        public void Create(string expected, LogCategoryType logCategoryType, string key, string value)
        {
            // Act
            var actual = LogItemFactory.Create(logCategoryType, key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Critical, Description: MyDescription", LogCategoryType.Critical, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Error, Description: MyDescription", LogCategoryType.Error, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Warning, Description: MyDescription", LogCategoryType.Warning, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Security, Description: MyDescription", LogCategoryType.Security, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Audit, Description: MyDescription", LogCategoryType.Audit, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Service, Description: MyDescription", LogCategoryType.Service, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: UI, Description: MyDescription", LogCategoryType.UI, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Information, Description: MyDescription", LogCategoryType.Information, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Debug, Description: MyDescription", LogCategoryType.Debug, "MyKey", "MyValue", "MyDescription")]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Trace, Description: MyDescription", LogCategoryType.Trace, "MyKey", "MyValue", "MyDescription")]
        public void Create_Description(string expected, LogCategoryType logCategoryType, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.Create(logCategoryType, key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Critical, Description: ", "MyKey", "MyValue")]
        public void CreateCritical(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateCritical(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Critical, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateCritical_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateCritical(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Error, Description: ", "MyKey", "MyValue")]
        public void CreateError(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateError(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Error, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateError_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateError(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Warning, Description: ", "MyKey", "MyValue")]
        public void CreateWarning(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateWarning(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Warning, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateWarning_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateWarning(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Security, Description: ", "MyKey", "MyValue")]
        public void CreateSecurity(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateSecurity(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Security, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateSecurity_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateSecurity(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Audit, Description: ", "MyKey", "MyValue")]
        public void CreateAudit(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateAudit(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Audit, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateAudit_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateAudit(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Service, Description: ", "MyKey", "MyValue")]
        public void CreateService(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateService(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Service, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateService_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateService(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: UI, Description: ", "MyKey", "MyValue")]
        public void CreateUi(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateUi(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: UI, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateUi_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateUi(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Information, Description: ", "MyKey", "MyValue")]
        public void CreateInformation(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateInformation(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Information, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateInformation_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateInformation(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Debug, Description: ", "MyKey", "MyValue")]
        public void CreateDebug(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateDebug(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Debug, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateDebug_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateDebug(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Trace, Description: ", "MyKey", "MyValue")]
        public void CreateTrace(string expected, string key, string value)
        {
            // Act
            var actual = LogItemFactory.CreateTrace(key, value);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }

        [Theory]
        [InlineData("Key: MyKey, Value: MyValue, LogCategory: Trace, Description: MyDescription", "MyKey", "MyValue", "MyDescription")]
        public void CreateTrace_Description(string expected, string key, string value, string description)
        {
            // Act
            var actual = LogItemFactory.CreateTrace(key, value, description);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.ToString());
        }
    }
}