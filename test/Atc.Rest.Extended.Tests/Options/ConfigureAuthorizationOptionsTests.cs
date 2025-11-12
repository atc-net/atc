namespace Atc.Rest.Extended.Tests.Options;

public class ConfigureAuthorizationOptionsTests
{
    [Fact]
    public void Implements_IPostConfigureOptions_JwtBearerOptions()
        => typeof(ConfigureAuthorizationOptions)
            .Should().Implement<IPostConfigureOptions<JwtBearerOptions>>();

    [Fact]
    public void Implements_IPostConfigureOptions_AuthenticationOptions()
        => typeof(ConfigureAuthorizationOptions)
            .Should().Implement<IPostConfigureOptions<AuthenticationOptions>>();

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_Sets_Authority(
        RestApiExtendedOptions apiOptions)
    {
        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.Authority.Should().NotBeNullOrWhiteSpace();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters(
        RestApiExtendedOptions apiOptions)
    {
        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.Should().NotBeNull();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidateAudience(
        RestApiExtendedOptions apiOptions)
    {
        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidateAudience.Should().BeTrue();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidAudience(
        RestApiExtendedOptions apiOptions)
    {
        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidAudience.Should().NotBeNullOrWhiteSpace();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidAudiences(
        RestApiExtendedOptions apiOptions)
    {
        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidAudiences.Should().NotBeNullOrEmpty();
    }

    [Theory, AutoData]
    public void PostConfigure_AuthenticationOptions_Sets_DefaultScheme(
        RestApiExtendedOptions apiOptions)
    {
        var options = new AuthenticationOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.DefaultScheme.Should().Be(JwtBearerDefaults.AuthenticationScheme);
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_ValidateIssuer_False_If_No_Issuers(
        RestApiExtendedOptions apiOptions)
    {
        apiOptions.Authorization = new AuthorizationOptions
        {
            Issuer = null!,
            ValidIssuers = new List<string>(),
        };

        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidateIssuer.Should().BeFalse();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_ValidateIssuer_True_With_Issuer(
        RestApiExtendedOptions apiOptions)
    {
        apiOptions.Authorization = new AuthorizationOptions
        {
            ValidIssuers = new List<string>(),
        };

        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidateIssuer.Should().BeTrue();
    }

    [Theory, AutoData]
    public void PostConfigure_JwtBearerOptions_ValidateIssuer_False_With_ValidIssuers_Null(
        RestApiExtendedOptions apiOptions)
    {
        apiOptions.Authorization = new AuthorizationOptions
        {
            Issuer = null!,
            ValidIssuers = null!,
        };

        var options = new JwtBearerOptions();
        new ConfigureAuthorizationOptions(apiOptions, null).PostConfigure(string.Empty, options);
        options.TokenValidationParameters.ValidateIssuer.Should().BeFalse();
    }
}