namespace Atc.Helpers;

/// <summary>
/// BarcodeHelper.
/// </summary>
/// <remarks>
/// https://en.wikipedia.org/wiki/International_Article_Number.
/// </remarks>
public static class ArticleNumberHelper
{
    /// <summary>
    /// Get ArticleNumberType.
    /// </summary>
    /// <param name="articleNumber">ASIN, EAN8, EAN13, GTIN, ISBN10, ISBN13, UPC.</param>
    public static ArticleNumberType GetArticleNumberType(string articleNumber)
    {
        var articleNumberType = AnalyzeArticleNumberType(articleNumber);
        if (articleNumberType != ArticleNumberType.Unknown)
        {
            return articleNumberType;
        }

        if (IsValidIsbn10(articleNumber))
        {
            return ArticleNumberType.ISBN10;
        }

        if (IsValidIsbn13(articleNumber))
        {
            return ArticleNumberType.ISBN13;
        }

        if (IsValidAsin(articleNumber))
        {
            return ArticleNumberType.ASIN;
        }

        if (IsValidIssn(articleNumber))
        {
            return ArticleNumberType.ISSN;
        }

        return ArticleNumberType.Unknown;
    }

    /// <summary>
    /// Validate ASIN.
    /// </summary>
    /// <param name="asin">The asin.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid asin] [the specified asin]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsValidAsin(string asin)
    {
        if (string.IsNullOrEmpty(asin))
        {
            return false;
        }

        if (asin.Length != 10)
        {
            return false;
        }

        var regex = new Regex("^B\\d{2}\\w{7}|\\d{9}(X|\\d)$", RegexOptions.None, TimeSpan.FromSeconds(1));
        return regex.IsMatch(asin);
    }

    /// <summary>
    /// Validate European Article Number.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid ean] [the specified code]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsValidEan(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return false;
        }

        var articleNumberType = AnalyzeArticleNumberType(code);
        return articleNumberType == ArticleNumberType.EAN8 || articleNumberType == ArticleNumberType.EAN13;
    }

    /// <summary>
    /// Validate Global Trade Item Number.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid gtin] [the specified code]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsValidGtin(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return false;
        }

        var articleNumberType = AnalyzeArticleNumberType(code);
        return articleNumberType == ArticleNumberType.GTIN;
    }

    /// <summary>
    /// Attempts to convert a UPC or EAN13 to a GTIN.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="gtin">The gtin.</param>
    public static bool TryConvertToGtin(string code, out string gtin)
    {
        if (string.IsNullOrEmpty(code))
        {
            gtin = string.Empty;
            return false;
        }

        var articleNumberType = AnalyzeArticleNumberType(code);

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (articleNumberType)
        {
            case ArticleNumberType.UPC:
                gtin = $"00{code}";
                return true;
            case ArticleNumberType.EAN13:
                gtin = $"0{code}";
                return true;
            case ArticleNumberType.GTIN:
                gtin = code;
                return true;
            default:
                gtin = string.Empty;
                return false;
        }
    }

    /// <summary>
    /// Validate ISSN.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid issn] [the specified code]; otherwise, <see langword="false" />.
    /// </returns>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static bool IsValidIssn(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return false;
        }

        if (code.Length != 9)
        {
            return false;
        }

        var checksum = 0;
        var multi = 8;
        try
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var c in code.Replace("-", string.Empty, StringComparison.Ordinal))
            {
                var number = c == 'X'
                    ? 10
                    : int.Parse(c.ToString(), GlobalizationConstants.EnglishCultureInfo);
                checksum += number * multi;
                multi--;
            }
        }
        catch
        {
            return false;
        }

        if (checksum % 11 != 0)
        {
            return false;
        }

        var regex = new Regex(@"^\d{4}-\d{3}[\dxX]{1}$", RegexOptions.None, TimeSpan.FromSeconds(1));
        return regex.IsMatch(code);
    }

    /// <summary>
    /// Validate ISBN10.
    /// </summary>
    /// <param name="isbn10">The isbn10.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid isbn10] [the specified isbn10]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsValidIsbn10(string isbn10)
    {
        if (string.IsNullOrEmpty(isbn10))
        {
            return false;
        }

        if (isbn10.Contains('-', StringComparison.Ordinal))
        {
            isbn10 = isbn10.Replace("-", string.Empty, StringComparison.Ordinal);
        }

        if (isbn10.Length != 10)
        {
            return false;
        }

        if (!long.TryParse(isbn10.AsSpan(0, isbn10.Length - 1), NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out _))
        {
            return false;
        }

        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += (isbn10[i] - '0') * (i + 1);
        }

        var result = false;
        var remainder = sum % 11;
        var lastChar = isbn10[^1];

        if (lastChar == 'X')
        {
            result = remainder == 10;
        }
        else if (int.TryParse(lastChar.ToString(), NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out sum))
        {
            result = remainder == lastChar - '0';
        }

        return result;
    }

    /// <summary>
    /// Validate ISBN13.
    /// </summary>
    /// <param name="isbn13">The isbn13.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid isbn13] [the specified isbn13]; otherwise, <see langword="false" />.
    /// </returns>
    [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "TODO: Fix, then we have a UT that covers the senearios")]
    public static bool IsValidIsbn13(string isbn13)
    {
        if (string.IsNullOrEmpty(isbn13))
        {
            return false;
        }

        if (isbn13.Contains('-', StringComparison.Ordinal))
        {
            isbn13 = isbn13.Replace("-", string.Empty, StringComparison.Ordinal);
        }

        if (isbn13.Length != 13)
        {
            return false;
        }

        if (!long.TryParse(isbn13, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out _))
        {
            return false;
        }

        var sum = 0;
        for (var i = 0; i < 12; i++)
        {
            sum += (isbn13[i] - '0') * (i % 2 == 1 ? 3 : 1);
        }

        var remainder = sum % 10;
        var checkDigit = 10 - remainder;
        if (checkDigit == 10)
        {
            checkDigit = 0;
        }

        var result = checkDigit == isbn13[12] - '0';
        return result;
    }

    /// <summary>
    /// Validate a UPC.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <returns>
    ///   <see langword="true" /> if [is valid upc] [the specified code]; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsValidUpc(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return false;
        }

        var articleNumberType = AnalyzeArticleNumberType(code);
        return articleNumberType == ArticleNumberType.UPC;
    }

    private static ArticleNumberType AnalyzeArticleNumberType(string code)
    {
        if (string.IsNullOrEmpty(code))
        {
            return ArticleNumberType.Unknown;
        }

        var articleNumberType = ArticleNumberType.Unknown;

        if (!long.TryParse(code, NumberStyles.Any, GlobalizationConstants.EnglishCultureInfo, out var temp))
        {
            return articleNumberType;
        }

        switch (code.Length)
        {
            case 8:
                // EAN-8
                articleNumberType = ArticleNumberType.EAN8;
                break;
            case 12:
                // UPC
                articleNumberType = ArticleNumberType.UPC;
                break;
            case 13:
                // EAN-13
                articleNumberType = ArticleNumberType.EAN13;
                break;
            case 14:
                // GTIN
                articleNumberType = ArticleNumberType.GTIN;
                break;
            default:
                // Wrong number of digits
                return articleNumberType;
        }

        code = $"{temp:00000000000000}";

        var a = new int[13];
        a[0] = (code[0] - '0') * 3;
        a[1] = code[1] - '0';
        a[2] = (code[2] - '0') * 3;
        a[3] = code[3] - '0';
        a[4] = (code[4] - '0') * 3;
        a[5] = code[5] - '0';
        a[6] = (code[6] - '0') * 3;
        a[7] = code[7] - '0';
        a[8] = (code[8] - '0') * 3;
        a[9] = code[9] - '0';
        a[10] = (code[10] - '0') * 3;
        a[11] = code[11] - '0';
        a[12] = (code[12] - '0') * 3;

        var sum = a.Sum();
        var check = (10 - (sum % 10)) % 10;

        // Last is check digit
        return check == code[13] - '0'
            ? articleNumberType
            : ArticleNumberType.Unknown;
    }
}