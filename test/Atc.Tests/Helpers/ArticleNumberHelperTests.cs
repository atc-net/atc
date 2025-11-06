namespace Atc.Tests.Helpers;

public class ArticleNumberHelperTests
{
    [Theory]
    [InlineData(ArticleNumberType.Unknown, null)]
    [InlineData(ArticleNumberType.Unknown, "B007KKKJY")]
    [InlineData(ArticleNumberType.ASIN, "B007KKKJYK")]
    [InlineData(ArticleNumberType.Unknown, "355155901")]
    [InlineData(ArticleNumberType.ISBN10, "3551559015")]
    [InlineData(ArticleNumberType.ISSN, "2229-5518")]
    [InlineData(ArticleNumberType.Unknown, "22295518")]
    [InlineData(ArticleNumberType.Unknown, "978-355155901")]
    [InlineData(ArticleNumberType.ISBN13, "978-3551559012")]
    [InlineData(ArticleNumberType.EAN13, "9783551559012")]
    [InlineData(ArticleNumberType.EAN13, "4002515289693")]
    [InlineData(ArticleNumberType.EAN13, "4039784974876")]
    [InlineData(ArticleNumberType.Unknown, "042100005260")]
    [InlineData(ArticleNumberType.GTIN, "00421000052644")]
    [InlineData(ArticleNumberType.UPC, "042100005264")]
    [InlineData(ArticleNumberType.UPC, "614141007349")]
    public void GetArticleNumberType(
        ArticleNumberType expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.GetArticleNumberType(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(true, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(true, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(false, "9783551559012")]
    [InlineData(false, "4002515289693")]
    [InlineData(false, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidAsin(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidAsin(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(true, "9783551559012")]
    [InlineData(true, "4002515289693")]
    [InlineData(true, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidEan(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidEan(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(false, "9783551559012")]
    [InlineData(false, "4002515289693")]
    [InlineData(false, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(true, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidGtin(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidGtin(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(true, "9783551559012")]
    [InlineData(true, "4002515289693")]
    [InlineData(true, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(true, "00421000052644")]
    [InlineData(true, "042100005264")]
    [InlineData(true, "614141007349")]
    public void TryConvertToGtin(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.TryConvertToGtin(input, out var _);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(true, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(false, "9783551559012")]
    [InlineData(false, "4002515289693")]
    [InlineData(false, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidIssn(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidIssn(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(true, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(false, "9783551559012")]
    [InlineData(false, "4002515289693")]
    [InlineData(false, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidIsbn10(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidIsbn10(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(true, "978-3551559012")]
    [InlineData(true, "9783551559012")]
    [InlineData(true, "4002515289693")]
    [InlineData(true, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(false, "042100005264")]
    [InlineData(false, "614141007349")]
    public void IsValidIsbn13(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidIsbn13(input);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(false, "B007KKKJY")]
    [InlineData(false, "B007KKKJYK")]
    [InlineData(false, "355155901")]
    [InlineData(false, "3551559015")]
    [InlineData(false, "2229-5518")]
    [InlineData(false, "22295518")]
    [InlineData(false, "978-355155901")]
    [InlineData(false, "978-3551559012")]
    [InlineData(false, "9783551559012")]
    [InlineData(false, "4002515289693")]
    [InlineData(false, "4039784974876")]
    [InlineData(false, "042100005260")]
    [InlineData(false, "00421000052644")]
    [InlineData(true, "042100005264")]
    [InlineData(true, "614141007349")]
    public void IsValidUpc(
        bool expected,
        string input)
    {
        // Act
        var actual = ArticleNumberHelper.IsValidUpc(input);

        // Assert
        Assert.Equal(expected, actual);
    }
}