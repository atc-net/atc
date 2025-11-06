namespace Atc.Helpers;

/// <summary>
/// Provides utility methods for working with <see cref="CultureInfo"/> objects.
/// </summary>
public static class CultureInfoHelper
{
    /// <summary>
    /// Creates a list of <see cref="CultureInfo"/> objects from culture names or locale IDs (LCIDs).
    /// </summary>
    /// <param name="cultureNames">An enumerable collection of culture names (e.g., "en-US") or LCID strings (e.g., "1033").</param>
    /// <returns>A list of <see cref="CultureInfo"/> objects corresponding to the provided names or LCIDs.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="cultureNames"/> is <see langword="null"/>.</exception>
    public static IList<CultureInfo> GetCulturesFromNames(
        IEnumerable<string> cultureNames)
    {
        if (cultureNames is null)
        {
            throw new ArgumentNullException(nameof(cultureNames));
        }

        var cultures = new List<CultureInfo>();
        foreach (var cultureName in cultureNames)
        {
            if (cultureName.IsDigitOnly())
            {
                if (NumberHelper.TryParseToInt(cultureName, out var lcid))
                {
                    cultures.Add(new CultureInfo(lcid));
                }
            }
            else
            {
                cultures.Add(new CultureInfo(cultureName));
            }
        }

        return cultures;
    }
}