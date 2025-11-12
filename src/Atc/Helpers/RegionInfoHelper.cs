namespace Atc.Helpers;

/// <summary>
/// RegionInfoHelper.
/// </summary>
public static class RegionInfoHelper
{
    private static readonly object Lock = new();
    private static List<RegionInfo>? allRegionInfos;

    /// <summary>
    /// Gets all region infos.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1031:Do not catch general exception types", Justification = "OK.")]
    public static List<RegionInfo> GetAllRegionInfos()
    {
        lock (Lock)
        {
            if (allRegionInfos is not null)
            {
                return allRegionInfos;
            }

            allRegionInfos = new List<RegionInfo>();
            var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var cultureInfo in cultureInfos)
            {
                try
                {
                    var regionInfo = new RegionInfo(cultureInfo.LCID);
                    if (!allRegionInfos.Contains(regionInfo))
                    {
                        allRegionInfos.Add(regionInfo);
                    }
                }
                catch
                {
                    // Dummy
                }
            }

            return allRegionInfos;
        }
    }

    /// <summary>
    /// Gets the region information by lcid.
    /// </summary>
    /// <param name="lcid">The lcid.</param>
    public static RegionInfo GetRegionInfoByLcid(int lcid)
        => new(lcid);

    /// <summary>
    /// Gets the region information by iso alpha3.
    /// </summary>
    /// <param name="isoAlpha3Code">The iso alpha3 code.</param>
    /// <exception cref="ArgumentNullException">isoAlpha3Code.</exception>
    public static RegionInfo? GetRegionInfoByIsoAlpha3(string isoAlpha3Code)
    {
        if (isoAlpha3Code is null)
        {
            throw new ArgumentNullException(nameof(isoAlpha3Code));
        }

        return GetAllRegionInfos()
            .Find(x => x.ThreeLetterISORegionName.Equals(isoAlpha3Code, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the culture information by iso alpha3.
    /// </summary>
    /// <param name="isoAlpha3Code">The iso alpha3 code.</param>
    /// <exception cref="ArgumentNullException">isoAlpha3Code.</exception>
    public static CultureInfo? GetCultureInfoByIsoAlpha3(string isoAlpha3Code)
    {
        if (isoAlpha3Code is null)
        {
            throw new ArgumentNullException(nameof(isoAlpha3Code));
        }

        if ("USA".Equals(isoAlpha3Code, StringComparison.OrdinalIgnoreCase))
        {
            return CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .FirstOrDefault(x => x.LCID == GlobalizationLcidConstants.UnitedStates);
        }

        if ("GBR".Equals(isoAlpha3Code, StringComparison.OrdinalIgnoreCase))
        {
            return CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .FirstOrDefault(x => x.LCID == GlobalizationLcidConstants.GreatBritain);
        }

        var regionInfo = GetRegionInfoByIsoAlpha3(isoAlpha3Code);
        return regionInfo is null
            ? null
            : CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .OrderBy(x => x.LCID)
                .FirstOrDefault(x =>
                    x.Name.EndsWith(regionInfo.TwoLetterISORegionName, StringComparison.OrdinalIgnoreCase) &&
                    x.EnglishName.Contains($"({regionInfo.EnglishName})", StringComparison.Ordinal));
    }

    /// <summary>
    /// Gets the lcid from region information.
    /// </summary>
    /// <param name="regionInfo">The region information.</param>
    /// <exception cref="ArgumentNullException">regionInfo.</exception>
    public static int GetLcidFromRegionInfo(RegionInfo regionInfo)
    {
        if (regionInfo is null)
        {
            throw new ArgumentNullException(nameof(regionInfo));
        }

        var cultures = CultureHelper.GetCultures();
        var culture = cultures.Find(x => x.CountryCodeA3.Equals(regionInfo.ThreeLetterISORegionName, StringComparison.Ordinal));
        if (culture is null)
        {
            return -1;
        }

        // Re-mapping
        return culture.Lcid switch
        {
            1116 => 1033,
            1106 => 2057,
            _ => culture.Lcid,
        };
    }

    /// <summary>
    /// Gets all region infos as lcids.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
    public static List<int> GetAllRegionInfosAsLcids()
    {
        lock (Lock)
        {
            var regionInfos = GetAllRegionInfos();
            var lcids = new List<int>();
            foreach (var lcid in regionInfos
                         .Select(GetLcidFromRegionInfo)
                         .Where(lcid => lcid != -1 && !lcids.Contains(lcid)))
            {
                try
                {
                    lcids.Add(new CultureInfo(lcid).LCID);
                }
                catch
                {
                    // Dummy
                }
            }

            return lcids
                .OrderBy(x => x)
                .ToList();
        }
    }
}