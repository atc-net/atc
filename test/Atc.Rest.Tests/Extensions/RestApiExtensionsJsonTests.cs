namespace Atc.Rest.Tests.Extensions;

public sealed class RestApiExtensionsJsonTests
{
    [Fact]
    public void AddRestApi_ConfigureJsonSerializerOptions_CanCopySharedOptions()
    {
        // Arrange
        var converter = new System.Text.Json.Serialization.JsonStringEnumConverter();
        var shared = new System.Text.Json.JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString,
            WriteIndented = true,
            Converters = { converter },
        };
        var restApiOptions = Options();
        restApiOptions.ConfigureJsonSerializerOptions = o => shared.CopyTo(o);

        // Act
        var actual = MvcJsonOptions(restApiOptions);

        // Assert
        Assert.Null(actual.PropertyNamingPolicy);
        Assert.Equal(System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString, actual.NumberHandling);
        Assert.True(actual.WriteIndented);
        Assert.Same(converter, Assert.Single(actual.Converters));
    }

    [Fact]
    public void AddRestApi_ConfigureJsonSerializerOptions_RunsAfterTheFlags()
    {
        // Arrange
        var restApiOptions = Options();
        restApiOptions.ConfigureJsonSerializerOptions = o => o.WriteIndented = true;

        // Act
        var actual = MvcJsonOptions(restApiOptions);

        // Assert
        Assert.True(actual.WriteIndented);
        Assert.Equal(System.Text.Json.JsonNamingPolicy.CamelCase, actual.PropertyNamingPolicy);
    }

    [Fact]
    public void AddRestApi_WithoutConfigureJsonSerializerOptions_UsesTheFlags()
    {
        // Arrange
        var restApiOptions = Options();

        // Act
        var actual = MvcJsonOptions(restApiOptions);

        // Assert
        Assert.Equal(System.Text.Json.JsonNamingPolicy.CamelCase, actual.PropertyNamingPolicy);
        Assert.Equal(System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, actual.DefaultIgnoreCondition);
        Assert.IsType<System.Text.Json.Serialization.JsonStringEnumConverter>(Assert.Single(actual.Converters));
    }

    private static RestApiOptions Options()
        => new()
        {
            UseApplicationInsights = false,
            UseAutoRegistrateServices = false,
            UseValidateServiceRegistrations = false,
            UseHttpContextAccessor = false,
        };

    private static System.Text.Json.JsonSerializerOptions MvcJsonOptions(
        RestApiOptions restApiOptions)
    {
        var services = new ServiceCollection();
        services.AddRestApi<RestApiExtensionsJsonTests>(restApiOptions);

        using var provider = services.BuildServiceProvider();
        return provider
            .GetRequiredService<Microsoft.Extensions.Options.IOptions<JsonOptions>>()
            .Value
            .JsonSerializerOptions;
    }
}