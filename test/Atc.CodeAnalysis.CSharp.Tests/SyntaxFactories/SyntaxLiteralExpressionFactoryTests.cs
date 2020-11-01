using System;
using System.Globalization;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxLiteralExpressionFactoryTests
    {
        [Theory]
        [InlineData("1.01")]
        [InlineData("1000.42")]
        [InlineData("0")]
        [InlineData("42")]
        [InlineData("-42")]
        [InlineData("12,345")]
        public void ShouldParseNumber(string value)
        {
            // Act
            var result = SyntaxLiteralExpressionFactory.Create(value, SyntaxKind.NumericLiteralExpression);

            // Assert
            Assert.Equal(SyntaxKind.NumericLiteralExpression, result.Kind());
            Assert.Equal(value.Replace(",", ".", StringComparison.Ordinal), result.ToString());
        }

        [Theory]
        [InlineData("1.0a")]
        [InlineData("ABC")]
        [InlineData("")]
        public void ShouldFailOnInvalidNumber(string value)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SyntaxLiteralExpressionFactory.Create(value, SyntaxKind.NumericLiteralExpression));
        }

        [Theory]
        [InlineData("1.0a")]
        [InlineData("ABC")]
        [InlineData("")]
        public void ShouldParseInvalidNumberAsString(string value)
        {
            // Act
            var result = SyntaxLiteralExpressionFactory.Create(value);

            // Assert
            Assert.Equal(SyntaxKind.StringLiteralExpression, result.Kind());
            Assert.Equal($"\"{value}\"", result.ToString());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(42)]
        [InlineData(-10)]
        public void ShouldParseInteger(int value)
        {
            // Act
            var result = SyntaxLiteralExpressionFactory.Create(value);

            // Assert
            Assert.Equal(SyntaxKind.NumericLiteralExpression, result.Kind());
            Assert.Equal(value.ToString(CultureInfo.InvariantCulture), result.ToString());
        }
    }
}