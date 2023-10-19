namespace Atc.Helpers;

public static class CultureInfoHelper
{
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