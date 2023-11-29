namespace Atc.Tests.Serialization.JsonConverters;

public class JsonComplexDataTests
{
    [Fact]
    public void ToJson()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new JsonCultureInfoToNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonDirectoryInfoToFullNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonFileInfoToFullNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
        jsonSerializerOptions.Converters.Add(new JsonDateTimeOffsetMinToNullConverter());
        jsonSerializerOptions.Converters.Add(new JsonUriToAbsoluteUriConverter());
        jsonSerializerOptions.Converters.Add(new JsonVersionConverter());

        var data = new ComplexData
        {
            MyCulture = new CultureInfo("en-US"),
            MyDirectory = new DirectoryInfo(@"C:\Temp"),
            MyFile = new FileInfo(@"C:\Temp\test.txt"),
            MyTimeSpan = TimeSpan.MinValue,
            MyDateTimeOffset = new DateTimeOffset(2023, 11, 29, 20, 39, 22, 123, TimeSpan.Zero),
            MyUri = new Uri("http://dr.dk/"),
            MyVersion = new Version(1, 2, 3, 4),
        };

        var expected = "{\r\n" +
                       "  \"myCulture\": \"en-US\",\r\n" +
                       "  \"myDirectory\": \"C:\\\\Temp\",\r\n" +
                       "  \"myFile\": \"C:\\\\Temp\\\\test.txt\",\r\n" +
                       "  \"myTimeSpan\": \"-10675199.02:48:05.4775808\",\r\n" +
                       "  \"myDateTimeOffset\": \"2023-11-29T20:39:22.123+00:00\",\r\n" +
                       "  \"myUri\": \"http://dr.dk/\",\r\n" +
                       "  \"myVersion\": \"1.2.3.4\"\r\n" +
                       "}".EnsureEnvironmentNewLines();

        // Atc
        var actual = JsonSerializer.Serialize(data, jsonSerializerOptions);

        // Assert
        Assert.NotNull(actual);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void FromJson()
    {
        // Arrange
        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create();
        jsonSerializerOptions.Converters.Add(new JsonCultureInfoToNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonDirectoryInfoToFullNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonFileInfoToFullNameConverter());
        jsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
        jsonSerializerOptions.Converters.Add(new JsonDateTimeOffsetMinToNullConverter());
        jsonSerializerOptions.Converters.Add(new JsonUriToAbsoluteUriConverter());
        jsonSerializerOptions.Converters.Add(new JsonVersionConverter());

        const string data = "{\r\n" +
                                "  \"myCulture\": \"en-US\",\r\n" +
                                "  \"myDirectory\": \"C:\\\\Temp\",\r\n" +
                                "  \"myFile\": \"C:\\\\Temp\\\\test.txt\",\r\n" +
                                "  \"myTimeSpan\": \"-10675199.02:48:05.4775808\",\r\n" +
                                "  \"myDateTimeOffset\": \"2023-11-29T20:39:22.123+00:00\",\r\n" +
                                "  \"myUri\": \"http://dr.dk/\",\r\n" +
                                "  \"myVersion\": \"1.2.3.4\"\r\n" +
                                "}";

        var expected = new ComplexData
        {
            MyCulture = new CultureInfo("en-US"),
            MyDirectory = new DirectoryInfo(@"C:\Temp"),
            MyFile = new FileInfo(@"C:\Temp\test.txt"),
            MyTimeSpan = TimeSpan.MinValue,
            MyDateTimeOffset = new DateTimeOffset(2023, 11, 29, 20, 39, 22, 123, TimeSpan.Zero),
            MyUri = new Uri("http://dr.dk/"),
            MyVersion = new Version(1, 2, 3, 4),
        };

        // Atc
        var actual = JsonSerializer.Deserialize<ComplexData>(data, jsonSerializerOptions);

        // Assert
        Assert.NotNull(actual);
        if (OperatingSystem.IsWindows())
        {
            Assert.Equal(expected.ToString(), actual.ToString());
        }
    }
}