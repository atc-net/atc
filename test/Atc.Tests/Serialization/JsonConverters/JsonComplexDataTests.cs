namespace Atc.Tests.Serialization.JsonConverters;

public sealed class JsonComplexDataTests
{
    [Fact]
    public void ToJson()
    {
        // Arrange
        var jsonSerializerFactorySettings = new JsonSerializerFactorySettings
        {
            UseConverterEnumAsString = false,
        };

        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(jsonSerializerFactorySettings);
        jsonSerializerOptions.Converters.Add(new CultureInfoToNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new DirectoryInfoToFullNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new FileInfoToFullNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new TimeSpanJsonConverter());
        jsonSerializerOptions.Converters.Add(new DateTimeOffsetMinToNullJsonConverter());
        jsonSerializerOptions.Converters.Add(new UriToAbsoluteUriJsonConverter());
        jsonSerializerOptions.Converters.Add(new VersionJsonConverter());
        jsonSerializerOptions.Converters.Add(new StringEnumMemberJsonConverter<ChargePointState>());

        var data = new ComplexData
        {
            MyCulture = new CultureInfo("en-US"),
            MyDirectory = new DirectoryInfo(@"C:\Temp"),
            MyFile = new FileInfo(@"C:\Temp\test.txt"),
            MyTimeSpan = TimeSpan.MinValue,
            MyDateTimeOffset = new DateTimeOffset(2023, 11, 29, 20, 39, 22, 123, TimeSpan.Zero),
            MyUri = new Uri("http://dr.dk/"),
            MyVersion = new Version(1, 2, 3, 4),
            State = ChargePointState.BusyNonReleased,
        };

        var expected = "{\r\n" +
                       "  \"myCulture\": \"en-US\",\r\n" +
                       "  \"myDirectory\": \"C:\\\\Temp\",\r\n" +
                       "  \"myFile\": \"C:\\\\Temp\\\\test.txt\",\r\n" +
                       "  \"myTimeSpan\": \"-10675199.02:48:05.4775808\",\r\n" +
                       "  \"myDateTimeOffset\": \"2023-11-29T20:39:22.123+00:00\",\r\n" +
                       "  \"myUri\": \"http://dr.dk/\",\r\n" +
                       "  \"myVersion\": \"1.2.3.4\",\r\n" +
                       "  \"state\": \"busy-non-released\"\r\n" +
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
        var jsonSerializerFactorySettings = new JsonSerializerFactorySettings
        {
            UseConverterEnumAsString = false,
        };

        var jsonSerializerOptions = JsonSerializerOptionsFactory.Create(jsonSerializerFactorySettings);
        jsonSerializerOptions.Converters.Add(new CultureInfoToNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new DirectoryInfoToFullNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new FileInfoToFullNameJsonConverter());
        jsonSerializerOptions.Converters.Add(new TimeSpanJsonConverter());
        jsonSerializerOptions.Converters.Add(new DateTimeOffsetMinToNullJsonConverter());
        jsonSerializerOptions.Converters.Add(new UriToAbsoluteUriJsonConverter());
        jsonSerializerOptions.Converters.Add(new VersionJsonConverter());
        jsonSerializerOptions.Converters.Add(new StringEnumMemberJsonConverter<ChargePointState>());

        const string data = "{\r\n" +
                                "  \"myCulture\": \"en-US\",\r\n" +
                                "  \"myDirectory\": \"C:\\\\Temp\",\r\n" +
                                "  \"myFile\": \"C:\\\\Temp\\\\test.txt\",\r\n" +
                                "  \"myTimeSpan\": \"-10675199.02:48:05.4775808\",\r\n" +
                                "  \"myDateTimeOffset\": \"2023-11-29T20:39:22.123+00:00\",\r\n" +
                                "  \"myUri\": \"http://dr.dk/\",\r\n" +
                                "  \"myVersion\": \"1.2.3.4\",\r\n" +
                                "  \"state\": \"busy-non-released\"\r\n" +
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
            State = ChargePointState.BusyNonReleased,
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