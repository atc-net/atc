using Atc.Rest.Extended.Options;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Xunit;

namespace Atc.Rest.Extended.Tests.Options
{
    public class ConfigureAuthorizationOptionsTests
    {
        [Fact]
        public void Implements_IPostConfigureOptions_JwtBearerOptions()
            => typeof(ConfigureAuthorizationOptions)
                .Should()
                .Implement<IPostConfigureOptions<JwtBearerOptions>>();

        [Fact]
        public void Implements_IPostConfigureOptions_AuthenticationOptions()
            => typeof(ConfigureAuthorizationOptions)
                .Should()
                .Implement<IPostConfigureOptions<AuthenticationOptions>>();

        [Theory]
        [AutoData]
        public void PostConfigure_JwtBearerOptions_Sets_Authority(
            ConfigureAuthorizationOptions sut)
        {
            var options = new JwtBearerOptions();
            sut.PostConfigure(string.Empty, options);
            options.Authority.Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [AutoData]
        public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters(
            ConfigureAuthorizationOptions sut)
        {
            var options = new JwtBearerOptions();
            sut.PostConfigure(string.Empty, options);
            options.TokenValidationParameters.Should().NotBeNull();
        }

        [Theory]
        [AutoData]
        public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidateAudience(
            ConfigureAuthorizationOptions sut)
        {
            var options = new JwtBearerOptions();
            sut.PostConfigure(string.Empty, options);
            options.TokenValidationParameters.ValidateAudience.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidAudience(
            ConfigureAuthorizationOptions sut)
        {
            var options = new JwtBearerOptions();
            sut.PostConfigure(string.Empty, options);
            options.TokenValidationParameters.ValidAudience.Should().NotBeNullOrWhiteSpace();
        }

        [Theory]
        [AutoData]
        public void PostConfigure_JwtBearerOptions_Sets_TokenValidationParameters_ValidAudiences(
            ConfigureAuthorizationOptions sut)
        {
            var options = new JwtBearerOptions();
            sut.PostConfigure(string.Empty, options);
            options.TokenValidationParameters.ValidAudiences.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [AutoData]
        public void PostConfigure_AuthenticationOptions_Sets_DefaultScheme(
            ConfigureAuthorizationOptions sut)
        {
            var options = new AuthenticationOptions();
            sut.PostConfigure(string.Empty, options);
            options.DefaultScheme.Should().Be(JwtBearerDefaults.AuthenticationScheme);
        }
    }
}